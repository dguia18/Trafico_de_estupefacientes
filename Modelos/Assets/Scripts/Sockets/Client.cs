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
    carsInstantateSockets Car = new carsInstantateSockets();
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

            case "UnitMoved":
                Debug.Log("Llego al Cliente Glorieta");
                Car.recibirCarro("TinyCar/Prefabs/" + aData[2], aData[3]);

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

