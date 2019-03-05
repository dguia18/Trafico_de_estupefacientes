using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCarro : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    int opcionMovimiento;
    bool acelerando;
    bool cruzando;
    int ruta;
    //int detenerCruce_25_2;
    //public Transform objetivo;
    //float alturaPare;
    void Start()
    {
        ruta = 0;
        opcionMovimiento = 0;
        //detenerCruce_25_2 = 0;
        acelerando = false;
        cruzando = false;
        //opcionMovimiento = 0;
        //alturaPare = 0f;
    }
    void Update()
    {
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
                speed = 10f;
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
        Transform myParent = collision.gameObject.transform.parent;
        if (myParent != null)
        {
            string collisioner = collision.gameObject.name;
            if (collisioner.Substring(0, 6).Equals("girar_"))
            {
                int giro = int.Parse(collisioner.Substring(6, 1));
                print("GIRO : " + giro);
                print("RUTA : " + ruta);
                if (giro == 1)
                {
                    if (ruta == 3 && !cruzando)
                    {
                        transform.Rotate(new Vector3(0f, 90f, 0f));
                        cruzando = true;
                    }
                } else if (giro == 2)
                {
                    if (ruta == 4 && !cruzando)
                    {
                        transform.Rotate(new Vector3(0f, 90f, 0f));
                        cruzando = true;
                    }
                } else if (giro == 3)
                {
                    if (ruta == 5 && !cruzando)
                    {
                        transform.Rotate(new Vector3(0f, -90f, 0f));
                        cruzando = true;
                    }
                } else if (giro == 4)
                {
                    if (ruta == 6 && !cruzando)
                    {
                        transform.Rotate(new Vector3(0f, -90f, 0f));
                        cruzando = true;
                    }
                }
            }
            //GameObject parent = myParent.gameObject;
            //Transform myPare = parent.transform.Find("Cruce_25_2");
            //Transform myVelocidadCero = parent.transform.Find("Cruce_25_4");
            //if (myPare != null && myVelocidadCero != null)
            //{
            //    GameObject esconderPare = myPare.gameObject;
            //    GameObject velocidadCero = myVelocidadCero.gameObject;
            //    Transform transformEsconderPare = esconderPare.GetComponent<Transform>();
            //    Transform transformVelocidadCero = velocidadCero.GetComponent<Transform>();

            //    //if (collisioner == "Cruce_25_5")
            //    //{
            //    //    //parent = collision.transform.parent.gameObject;
            //    //    GameObject guia = parent.transform.Find("Cruce_25_6").gameObject;
            //    //    objetivo = guia.GetComponent<Transform>();
            //    //    Vector3 direccion = transform.position - objetivo.position;
            //    //    Quaternion rotacion = Quaternion.LookRotation(direccion);
            //    //    transform.rotation = Quaternion.Slerp(transform.rotation, objetivo.rotation, speed * Time.deltaTime);
            //    //}
            //    //else if (collisioner == "Cruce_25_6")
            //    //{
            //    //    //parent = collision.transform.parent.gameObject;
            //    //    GameObject guia = parent.transform.Find("Cruce_25_7").gameObject;
            //    //    objetivo = guia.GetComponent<Transform>();
            //    //    Vector3 direccion = transform.position - objetivo.position;
            //    //    Quaternion rotacion = Quaternion.LookRotation(direccion);
            //    //    transform.rotation = Quaternion.Slerp(transform.rotation, objetivo.rotation, speed * Time.deltaTime);
            //    //}
            //    if (collisioner == "Cruce_25_1")
            //    {
            //        //Debug.Log(this.name + " colisionó con " + collision.gameObject.transform.parent.gameObject.name);
            //        transform.Rotate(new Vector3(0f, 90f, 0f));
            //    }
            //    if (collisioner == "girar_1")
            //    {
            //        //opcionMovimiento = Random.Range(0, 3);
            //        //Debug.Log("Opcion Movimiento OnColision: "+opcionMovimiento);
            //        Debug.Log("Movimiento " + opcionMovimiento);
            //        if (opcionMovimiento == 2 && !cruzando)
            //        {
            //            transform.Rotate(new Vector3(0f, 90f, 0f));
            //            cruzando = true;
            //        }
            //    }
            //    else if (collisioner == "Cruce_25_3")
            //    {
            //        //Debug.Log("Dejó de colisionar, no detener");
            //        transformEsconderPare.position = new Vector3(esconderPare.transform.position.x, 0f, esconderPare.transform.position.z);
            //        transformVelocidadCero.position = new Vector3(velocidadCero.transform.position.x, 0f, velocidadCero.transform.position.z);
            //    }
            //    else if (collisioner == "Cruce_25_2" || collisioner == "Cruce_25_4")
            //    {
            //        acelerando = true;
            //    }
            //}
            //Para que luego de cruzar siga en linea paralela a la calle
            //Debug.Log(this.name + " dejó de colisionar con el padre -> " + collision.gameObject.transform.parent.gameObject.name);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Transform myParent = collision.gameObject.transform.parent;
        if (myParent != null)
        {
            string collisioner = collision.gameObject.name;
            GameObject parent = myParent.gameObject;
            if (ruta == 0)
            {
                if (collisioner.Substring(0, 5).Equals("ruta_"))
                {
                    ruta = int.Parse(collisioner.Substring(5, 1));
                    //print("Entrando : RUTA : " + ruta);
                    cruzando = false;
                    opcionMovimiento = Random.Range(0, 3);
                    //print(ruta);
                    if (ruta == 1)
                    {
                        if (opcionMovimiento == 2) ruta = 3;
                    } else if (ruta == 2)
                    {
                        if (opcionMovimiento == 2) ruta = 5;
                    } else if (ruta == 4)
                    {
                        if (collisioner == "ruta_4_") opcionMovimiento = 0;
                        if (opcionMovimiento == 2) ruta = 7;
                    } else if (ruta == 6)
                    {
                        if (opcionMovimiento == 2) ruta = 8;
                    }
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Transform myParent = collision.gameObject.transform.parent;
        if (myParent != null)
        {

            GameObject parent = myParent.gameObject;
            string collisioner = collision.gameObject.name;
                //GameObject esconderPare = myPare.gameObject;
                //GameObject velocidadCero = myVelocidadCero.gameObject;
                //Transform transformEsconderPare = esconderPare.GetComponent<Transform>();
                //Transform transformVelocidadCero = velocidadCero.GetComponent<Transform>();
            if (collisioner == "ruta_1")
            {
                print("Ruta1 del padre: " + parent.GetComponent<controlCruces>().Ruta1);
                if (opcionMovimiento == 2)
                {
                    parent.GetComponent<controlCruces>().Ruta3 = 1;
                } else
                {
                    parent.GetComponent<controlCruces>().Ruta1 = 1;
                }
                //Debug.Log("Ruta 1: " + parent.GetComponent<controlCruces>().Ruta1);
                //Debug.Log("Ruta 2: " + parent.GetComponent<controlCruces>().Ruta2);
                //Debug.Log("Ruta 3: " + parent.GetComponent<controlCruces>().Ruta3);
                //Debug.Log("Ruta 4: " + parent.GetComponent<controlCruces>().Ruta4);
                //GameObject esconderPare = parent.transform.Find("Cruce_25_2").gameObject;
                //Debug.Log("Colision de auto con " + collisioner);
                //transformEsconderPare.position = new Vector3(esconderPare.transform.position.x, 0.035f, esconderPare.transform.position.z);
                //transformVelocidadCero.position = new Vector3(velocidadCero.transform.position.x, 0.035f, velocidadCero.transform.position.z);
            } else if (collisioner == "ruta_2")
            {
                parent.GetComponent<controlCruces>().Ruta2 = 1;
            } else if (collisioner == "ruta_2")
            {
                parent.GetComponent<controlCruces>().Ruta3 = 1;
            }
            else if (collisioner == "Cruce_25_2")
            {
                speed = speed / 1.015f;
                transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, speed * Time.deltaTime);
                acelerando = false;
            }
            else if (collisioner == "espera_4_1")
            {
                if (parent.GetComponent<controlCruces>().Ruta1 == 1)
                {
                    GameObject espera42 = parent.transform.Find("espera_4_2").gameObject;
                    Transform transform_espera42 = espera42.GetComponent<Transform>();
                    speed = (speed) / (1.5f);
                    transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, speed * Time.deltaTime);
                    acelerando = false;
                    transform_espera42.position = new Vector3(espera42.transform.position.x, 0.04f, espera42.transform.position.z);
                } else
                {
                    GameObject espera42 = parent.transform.Find("espera_4_2").gameObject;
                    Transform transform_espera42 = espera42.GetComponent<Transform>();
                    transform_espera42.position = new Vector3(espera42.transform.position.x, 0f, espera42.transform.position.z);
                    GameObject espera43 = parent.transform.Find("espera_4_3").gameObject;
                    Transform transform_espera43 = espera43.GetComponent<Transform>();
                    transform_espera43.position = new Vector3(espera43.transform.position.x, 0f, espera43.transform.position.z);
                }
            } else if (collisioner == "espera_4_2")
            {
                GameObject espera43 = parent.transform.Find("espera_4_3").gameObject;
                Transform transform_espera43 = espera43.GetComponent<Transform>();
                speed = (speed) / (1.5f);
                transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, speed * Time.deltaTime);
                acelerando = false;
                transform_espera43.position = new Vector3(espera43.transform.position.x, 0.04f, espera43.transform.position.z);
            }
        }
    }
}
