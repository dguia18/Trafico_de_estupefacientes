using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carsInstantateSockets : MonoBehaviour
{
    public float instanceRate = 15f;
    private float nextInstance = 0.0f;
    public GameObject taxi;
    void Start()
    {

    }
    void Update()
    {

    }
    public void recibirCarro(string name, string emisor)
    {
        Debug.Log("Nombre del prfats " + name.Split('(')[0]);
        GameObject prefab = Resources.Load(name.Split('(')[0]) as GameObject;
        //Debug.Log("Escena Cargada " + SceneManager.GetSceneByName("Glorieta").isLoaded);
        //GameObject[] gameObjects = SceneManager.GetSceneByName("Glorieta").GetRootGameObjects();
       
        //foreach (var item in gameObjects)
        //{
        //    Debug.Log(item.name);
        //}
        nextInstance = Time.time + instanceRate;
        Debug.Log("emisor es " + emisor);
        Debug.Log("nombre del prefact creado" + prefab.gameObject.name);
        string receptor = "receptor" + emisor.Substring(6, 4);
        print("Receptor : " + receptor);
        GameObject generador = GameObject.Find(receptor);
        Debug.Log("generador " + generador);
        if (generador != null)
        {
            Instantiate(prefab.gameObject, generador.transform.position, generador.transform.rotation);
            Debug.Log(generador.transform.position.x);
            Debug.Log(generador.transform.position.y);
            Debug.Log(generador.transform.position.z);
        }
    }
}