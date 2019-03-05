using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCarro : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadInicial = 5f;
    public float velocidad;
    int desvio;
    bool acelerando;
    bool cruzando;
    int ruta;
    //int detenerCruce_25_2;
    //public Transform objetivo;
    //float alturaPare;
    void Start()
    {
        velocidad = velocidadInicial;
        ruta = 0;
        desvio = 0;
        acelerando = false;
        cruzando = false;
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
        //if (acelerando)
        //{
        //    print("ACELERANDO VELOCIDAD: " + velocidad);
        //    if (velocidad < 1f) velocidad = 1f;
        //    velocidad *= 1.5f;
        //    if (velocidad >= velocidadInicial)
        //    {
        //        velocidad = velocidadInicial;
        //        acelerando = false;
        //    }
        //}

        transform.Translate(0, 0, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, velocidad * Time.deltaTime);

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
            GameObject objParent = myParent.gameObject;
            if (collisioner.Substring(0, 6).Equals("espera"))
            {
                velocidad = velocidadInicial;
            } else if (collisioner.Substring(0, 3).Equals("fin"))
            {
                // Reiniciamos la velocidad, aceleración y ruta del auto
                velocidad = velocidadInicial;
                acelerando = false;
                ruta = 0;
                int finRuta = int.Parse(collisioner.Substring(9, 1));
                switch (finRuta)
                {
                    case 1:
                        objParent.GetComponent<controlCruces>().Ruta1 = false;
                        break;
                    case 2:
                        objParent.GetComponent<controlCruces>().Ruta2 = false;
                        break;
                    case 3:
                        objParent.GetComponent<controlCruces>().Ruta3 = false;
                        break;
                    case 4:
                        objParent.GetComponent<controlCruces>().Ruta4 = false;
                        break;
                    case 5:
                        objParent.GetComponent<controlCruces>().Ruta5 = false;
                        break;
                    case 6:
                        objParent.GetComponent<controlCruces>().Ruta6 = false;
                        break;
                    case 7:
                        objParent.GetComponent<controlCruces>().Ruta7 = false;
                        break;
                    case 8:
                        objParent.GetComponent<controlCruces>().Ruta8 = false;
                        break;
                    default:
                        Debug.Log("No se puede liberar, ruta desconocida.");
                        break;
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
            GameObject objParent = myParent.gameObject;
            // Si no se le ha asignado una ruta al auto, es decir, apenas está entrando a las rutas.
            if (ruta == 0)
            {
                //Debug.Log("El auto no tiene ruta asignada");
                if (collisioner.Substring(0, 5).Equals("ruta_"))
                {
                    // Qué hacemos cuando colisiona con una ruta...
                    ruta = int.Parse(collisioner.Substring(5, 1));
                    cruzando = false;
                    desvio = Random.Range(0, 3);
                    //Debug.Log("Al auto se le asignará la ruta " + ruta);
                    switch (ruta)
                    {
                        case 1:
                            if (desvio == 2) ruta = 3;
                            break;
                        case 2:
                            if (desvio == 2) ruta = 5;
                            break;
                        case 4:
                            if (desvio == 2) ruta = 7;
                            break;
                        case 6:
                            if (desvio == 2) ruta = 8;
                            break;
                        default:
                            break;
                    }
                }
            } else if (collisioner.Substring(0, 5).Equals("girar"))
            {
                velocidad = 1.5f * velocidadInicial;
                int giro = int.Parse(collisioner.Substring(6, 1));
                //Debug.Log("Girando " + transform.name + " de la RUTA: " + ruta + " con el GIRO: " + giro);
                if (giro == 1)
                {
                    if (ruta == 3 && !cruzando)
                    {
                        Cruzar(0f, 90f, 0f);
                    }
                }
                else if (giro == 2 && (ruta == 4 || ruta == 7))
                {
                    if (ruta == 4 && !cruzando)
                    {
                        Cruzar(0f, 90f, 0f);
                    }
                }
                else if (giro == 3)
                {
                    if (ruta == 5 && !cruzando)
                    {
                        Cruzar(0f, -90f, 0f);
                    }
                }
                else if (giro == 4)
                {
                    if (ruta == 6 && !cruzando)
                    {
                        Cruzar(0f, -90f, 0f);
                    }
                }
                else if (giro == 5 && (ruta == 4 || ruta == 7))
                {
                    // Caso especial, giro obligatorio en caso de 3 cruces.
                    Cruzar(0f, 90f, 0f);
                }
            }
            //Debug.Log("El auto tiene asignada la ruta " + ruta);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Transform myParent = collision.gameObject.transform.parent;
        if (myParent != null)
        {
            GameObject objParent = myParent.gameObject;
            string collisioner = collision.gameObject.name;
            if (collisioner == "ruta_1")
            {
                if (ruta == 3)
                {
                    objParent.GetComponent<controlCruces>().Ruta3 = true;
                } else if (ruta == 1)
                {
                    objParent.GetComponent<controlCruces>().Ruta1 = true;
                }
                //GameObject esconderPare = parent.transform.Find("Cruce_25_2").gameObject;
                //Debug.Log("Colision de auto con " + collisioner);
                //transformEsconderPare.position = new Vector3(esconderPare.transform.position.x, 0.035f, esconderPare.transform.position.z);
                //transformVelocidadCero.position = new Vector3(velocidadCero.transform.position.x, 0.035f, velocidadCero.transform.position.z);
            } else if (collisioner == "ruta_2")
            {
                if (ruta == 2)
                {
                    objParent.GetComponent<controlCruces>().Ruta2 = true;
                } else if(ruta == 5)
                {
                    objParent.GetComponent<controlCruces>().Ruta5 = true;
                }
            } else if (collisioner == "ruta_4")
            {
                print("Colisionando con ruta_4");
                if (ruta == 4)
                {
                    objParent.GetComponent<controlCruces>().Ruta4 = true;
                } else if (ruta == 7)
                {
                    objParent.GetComponent<controlCruces>().Ruta7 = true;
                }
            } else if (collisioner == "ruta_6")
            {
                if (ruta == 6)
                {
                    objParent.GetComponent<controlCruces>().Ruta6 = true;
                }
            }
            if (collisioner == "ruta_4")
            {
                print(transform.name + "Colisionado con " + collisioner);
                GameObject espera41 = objParent.transform.Find("espera_4_1").gameObject;
                Transform transform_espera41 = espera41.GetComponent<Transform>();
                GameObject espera42 = objParent.transform.Find("espera_4_2").gameObject;
                Transform transform_espera42 = espera42.GetComponent<Transform>();
                GameObject espera43 = objParent.transform.Find("espera_4_3").gameObject;
                Transform transform_espera43 = espera43.GetComponent<Transform>();
                if (objParent.GetComponent<controlCruces>().Ruta1)
                {
                    Debug.Log("Ruta 1 OCUPADA : " + objParent.GetComponent<controlCruces>().Ruta1);
                    transform_espera41.localPosition = new Vector3(espera41.transform.localPosition.x, espera41.transform.localPosition.y, -0.44f);
                    transform_espera42.localPosition = new Vector3(espera42.transform.localPosition.x, espera42.transform.localPosition.y, -0.44f);
                    transform_espera43.localPosition = new Vector3(espera43.transform.localPosition.x, espera43.transform.localPosition.y, -0.44f);
                    velocidad = 0.0003f;
                    acelerando = false;
                } else
                {
                    Debug.Log("Ruta 1 DESOCUPADA : " + objParent.GetComponent<controlCruces>().Ruta1);
                    transform_espera41.localPosition = new Vector3(espera41.transform.localPosition.x, espera41.transform.localPosition.y, -1f);
                    transform_espera42.localPosition = new Vector3(espera42.transform.localPosition.x, espera42.transform.localPosition.y, -1f);
                    transform_espera43.localPosition = new Vector3(espera43.transform.localPosition.x, espera43.transform.localPosition.y, -1f);
                    velocidad = velocidadInicial;
                    acelerando = true;
                }
            }
            else if (collisioner.Substring(0, 6).Equals("espera"))
            {
                int aceleracion = int.Parse(collisioner.Substring(9, 1));
                GameObject espera4 = objParent.transform.Find(collisioner).gameObject;
                Transform transform_espera42 = espera4.GetComponent<Transform>();
                velocidad = velocidadInicial * aceleracion * aceleracion / 10;
            }
        }
    }

    private void Cruzar(float x, float y, float z)
    {
        if (!cruzando)
        {
            transform.Rotate(new Vector3(x, y, z));
            cruzando = true;
            //Debug.Log("Está cruzando: " + cruzando);
            //Debug.Log("Cruzando " + transform.name + " con la ruta " + ruta);
        }
    }
}
