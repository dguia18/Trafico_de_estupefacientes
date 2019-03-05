﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
    public static RaycastResult LastRayHit;
    public static GameObject map;
    public static Client client;
    public Button spawnButton;

    private void Awake()
    {
        GameObject go = GameObject.Find("Client");
        if (go == null)
        {
            Debug.Log("Client object not found");
            SceneManager.LoadScene("ClientLogin".Trim());
            return;
        }
        client = go.GetComponent<Client>();
        if (client == null)
        {
            Debug.Log("Couldn't find client script");
            return;
        }
        map = GameObject.Find("plane");
        if (map == null)
        {
            Debug.Log("Couldn't find map");
            return;
        }

        client.Send("SynchronizeRequest|");

        //client.Send("SpawnUnit|");
    
    }



    public void SpawnUnit()
    {
        client.Send("SpawnUnit|");
        spawnButton.interactable = false;
        
    }
}
