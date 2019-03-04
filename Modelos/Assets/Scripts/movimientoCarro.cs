using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCarro : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    int opcionMovimiento;
    int detenerCruce_25_2;
    bool acelerando;
    public Transform objetivo;
    //float alturaPare;
    void Start()
    {
        detenerCruce_25_2 = 0;
        acelerando = false;
        //opcionMovimiento = 0;
        //alturaPare = 0f;
    }
    void Update (){
        //GameObject esconderPare = GameObject.Find("Cruce_25_2");
        //Transform transformEsconderPare = esconderPare.GetComponent<Transform>();
        //if (opcionMovimiento == 2)
        //{
        //    transformEsconderPare.position = new Vector3(esconderPare.transform.position.x, -1f, esconderPare.transform.position.z);
        //}
        //else
        //{
        //    transformEsconderPare.position = new Vector3(esconderPare.transform.position.x, 0f, esconderPare.transform.position.z);
        //}
        //Debug.Log("Opcion Movimiento:" + opcionMovimiento);
        
    }

    private void FixedUpdate()
    {
        if (acelerando)
        {
            if (speed < 1f)
            {
                speed = 1f;
            }
            speed *= 1.05f;
            if (speed >= 5f)
            {
                speed = 5f;
                acelerando = false;
            }
        }

        transform.Translate(0, 0, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, speed * Time.deltaTime);

        //Debug.Log("Detener cruce " + detenerCruce_25_2);
        //if (this.transform.position.x <= 194.5f && this.transform.position.x >= 192f)
        //{
        //    opcionMovimiento = 0;
        //    opcionMovimiento = Random.Range(0, 3);
        //    if (opcionMovimiento == 2)
        //    {
        //        transform.Rotate(new Vector3(0f, 225f, 0f) * Time.deltaTime);
        //    }
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        // Para que luego de cruzar siga en linea paralela a la calle
        //if (collision.gameObject.name == "Cruce_25_5")
        //{
        //    GameObject guia = GameObject.Find("Cruce_25_6");
        //    objetivo = guia.GetComponent<Transform>();
        //    Vector3 direccion = transform.position - objetivo.position;
        //    Quaternion rotacion = Quaternion.LookRotation(direccion);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, objetivo.rotation, speed * Time.deltaTime);
        //}
        //else if (collision.gameObject.name == "Cruce_25_6")
        //{
        //    GameObject guia = GameObject.Find("Cruce_25_7");
        //    objetivo = guia.GetComponent<Transform>();
        //    Vector3 direccion = transform.position - objetivo.position;
        //    Quaternion rotacion = Quaternion.LookRotation(direccion);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, objetivo.rotation, speed * Time.deltaTime);
        //}
        GameObject esconderPare = GameObject.Find("Cruce_25_2");
        GameObject velocidadCero = GameObject.Find("Cruce_25_4");
        Transform transformEsconderPare = esconderPare.GetComponent<Transform>();
        Transform transformVelocidadCero = velocidadCero.GetComponent<Transform>();
        if (collision.gameObject.name == "Cruce_25_1")
        {
            Debug.Log(this.name + " colisionó con " + collision.gameObject.name);
           transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        if (collision.gameObject.name == "Cruce_25")
        {
            opcionMovimiento = Random.Range(0, 3);
            Debug.Log("Opcion Movimiento OnColision: "+opcionMovimiento);
            if(opcionMovimiento == 2)
            {
                transform.Rotate(new Vector3(0f, 90f, 0f));
            }
        } else if (collision.gameObject.name == "Cruce_25_3")
        {
            transformEsconderPare.position = new Vector3(esconderPare.transform.position.x, 0f, esconderPare.transform.position.z);
            transformVelocidadCero.position = new Vector3(velocidadCero.transform.position.x, 0f, velocidadCero.transform.position.z);
        } else if(collision.gameObject.name == "Cruce_25_2" || collision.gameObject.name == "Cruce_25_4")
        {
            acelerando = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject esconderPare = GameObject.Find("Cruce_25_2");
        GameObject velocidadCero = GameObject.Find("Cruce_25_4");
        Transform transformEsconderPare = esconderPare.GetComponent<Transform>();
        Transform transformVelocidadCero = velocidadCero.GetComponent<Transform>();
        if (collision.gameObject.name == "Cruce_25_3")
        {
            //Debug.Log("Colision de auto con " + collision.gameObject.name);
            transformEsconderPare.position = new Vector3(esconderPare.transform.position.x, 0.035f, esconderPare.transform.position.z);
            transformVelocidadCero.position = new Vector3(velocidadCero.transform.position.x, 0.035f, velocidadCero.transform.position.z);
        } else if (collision.gameObject.name == "Cruce_25_2")
        {
            speed = speed/1.015f;
            transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, speed * Time.deltaTime);
            acelerando = false;
        } else if (collision.gameObject.name == "Cruce_25_4")
        {
            speed = (speed) / (2);
            transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, speed * Time.deltaTime);
            acelerando = false;
        }
    }
}
