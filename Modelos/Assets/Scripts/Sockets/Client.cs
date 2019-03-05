using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using UnityEngine.AI;


public class Client : MonoBehaviour
{
    private string clientName;
    private int portToConnect = 6321;
    private string password;
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;
    public InputField clientNameInputField;
    public InputField serverAddressInputField;
    public InputField passwordInputField;
    private List<Unit> unitsOnMap = new List<Unit>();
    private CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
    carsInstantate Car;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        culture.NumberFormat.NumberDecimalSeparator = ".";
    }

    public bool ConnectToServer(string host, int port)
    {
        if (socketReady)
            return false;

        try
        {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error " + e.Message);
        }

        return socketReady;
    }

    private void Update()
    {
        if (socketReady)
        {
            if (stream.DataAvailable)
            {
                string data = reader.ReadLine();
                if (data != null)
                    OnIncomingData(data);
            }
        }
    }

    // Sending message to the server
    public void Send(string data)
    {
        if (!socketReady)
            return;

        writer.WriteLine(data);
        writer.Flush();
    }

    // Read messages from the server
    private void OnIncomingData(string data)
    {
        string[] aData = data.Split('|');
        Debug.Log("Received from server: " + data);

        switch (aData[0])
        {
            case "WhoAreYou":
                Send("Iam|" + clientName + "|" + password);
                break;
            case "Authenticated":
                switch (clientName) {
                    case "admin": SceneManager.LoadScene("25-to-21"); break;
                    case "admin2": SceneManager.LoadScene("21_to_18E"); break;
                    case "admin3": SceneManager.LoadScene("Glorieta"); break;
                    default: Debug.Log("Opcion Invalida"); break;
                }
                
                break;
            case "UnitSpawned":
                GameObject prefab = Resources.Load("Prefabs/Unit1") as GameObject;
                GameObject go = Instantiate(prefab);
                float parsedX = float.Parse(aData[3], culture);
                float parsedY = float.Parse(aData[4], culture);
                float parsedZ = float.Parse(aData[5], culture);
                go.GetComponent<NavMeshAgent>().Warp(new Vector3(parsedX, parsedY, parsedZ));
                Unit un = go.AddComponent<Unit>();
                unitsOnMap.Add(un);
                int parsed;
                Int32.TryParse(aData[2], out parsed);
                un.unitID = parsed;

                if (aData[1] == clientName)
                {
                    un.isPlayersUnit = true;
                }
                else
                {
                    un.isPlayersUnit = false;
                }
                break;
            case "UnitMoved":
                if (aData[1] == clientName)
                {
                    return;
                }
           
                break;
            case "Synchronizing":
                        
                        //prefab = Resources.Load("TinyCar/Prefabs/"+aData[0]) as GameObject;
                        //GameObject Carro = Instantiate(prefab);
                        //go = Instantiate(prefab);
                        //Car.recibirCarro(go);
                Debug.Log("instancio a la escena 2");
                break;
            default:
                Debug.Log("Unrecognizable command received");
                break;
        }
    }

 

    private void OnApplicationQuit()
    {
        CloseSocket();
    }
    private void OnDisable()
    {
        CloseSocket();
    }
    private void CloseSocket()
    {
        if (!socketReady)
            return;

        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }


    public void ConnectToServerButton()
    {
        password = passwordInputField.text;
        clientName = clientNameInputField.text;
        CloseSocket();
        try
        {
            ConnectToServer(serverAddressInputField.text, portToConnect);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}

