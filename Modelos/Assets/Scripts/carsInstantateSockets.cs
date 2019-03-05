using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameObject prefab = Resources.Load(name) as GameObject;
        Debug.Log(name);
        if (Time.time > nextInstance)
        {
            nextInstance = Time.time + instanceRate;
            if (emisor== "emisor25_1")
            {
                GameObject cubo1 = GameObject.Find("receptorGlorieta1");
                Instantiate(prefab.gameObject, cubo1.transform.position, cubo1.transform.rotation);
                Debug.Log(cubo1.transform.position.x);
                Debug.Log(cubo1.transform.position.y);
                Debug.Log(cubo1.transform.position.z);
            }
            if (emisor == "emisor25_2")
            {
                GameObject cubo2 = GameObject.Find("receptorGlorieta2");
                Instantiate(prefab.gameObject, cubo2.transform.position, cubo2.transform.rotation);
                Debug.Log(cubo2.transform.position.x);
                Debug.Log(cubo2.transform.position.y);
                Debug.Log(cubo2.transform.position.z);
            }
        }
    }
}
