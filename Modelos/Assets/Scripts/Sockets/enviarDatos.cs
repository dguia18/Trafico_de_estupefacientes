using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviarDatos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float speed = 5f;
        //transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        //Debug.Log("Entro a colisionar");
        if (collision.gameObject.name.Length >= 6)
        {
            if (collision.gameObject.name.Substring(0,6).Equals("emisor")) {
                //Debug.Log("Entro a colisionar con el cube");
                PlayerControl.client.Send("Moving|"+ gameObject.name.Split('(')[0] + "|" + collision.gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
