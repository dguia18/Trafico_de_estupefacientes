using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCarro : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadInicial;
    public float velocidad;
    int desvio;
    bool cruzando;
    int ruta;
    void Start()
    {
        velocidadInicial = 8f;
        velocidad = velocidadInicial;
        ruta = 0;
        desvio = 0;
        cruzando = false;
    }
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, velocidad * Time.deltaTime);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "giro_glorieta_2")
        {
            cruzando = false;
            Cruzar(0f, 90f, 0f);
        }
        Transform myParent = collision.gameObject.transform.parent;
        if (myParent != null)
        {
            string collisioner = collision.gameObject.name;
            GameObject objParent = myParent.gameObject;
            if (collisioner.Substring(0, 6).Equals("espera") || collisioner.Substring(0, 4).Equals("ruta"))
            {
                velocidad = velocidadInicial;
            } else if (collisioner.Substring(0, 3).Equals("fin"))
            {
                // Reiniciamos la velocidad, aceleración y ruta del auto
                velocidad = velocidadInicial;
                int finRuta = int.Parse(collisioner.Substring(9, 1));
                switch (finRuta)
                {
                    case 1:
                        if (ruta == 1) objParent.GetComponent<controlCruces>().Ruta1 = false;
                        break;
                    case 2:
                        if (ruta == 2) objParent.GetComponent<controlCruces>().Ruta2 = false;
                        break;
                    case 3:
                        if (ruta == 3) objParent.GetComponent<controlCruces>().Ruta3 = false;
                        break;
                    case 4:
                        if (ruta == 4) objParent.GetComponent<controlCruces>().Ruta4 = false;
                        break;
                    case 5:
                        if (ruta == 5) objParent.GetComponent<controlCruces>().Ruta5 = false;
                        break;
                    case 6:
                        if (ruta == 6) objParent.GetComponent<controlCruces>().Ruta6 = false;
                        break;
                    case 7:
                        if (ruta == 7) objParent.GetComponent<controlCruces>().Ruta7 = false;
                        break;
                    case 8:
                        if (ruta == 8) objParent.GetComponent<controlCruces>().Ruta8 = false;
                        break;
                    default:
                        Debug.Log("No se puede liberar, ruta desconocida.");
                        break;
                }
                ruta = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        string collisioner = collision.gameObject.name;
        if (collisioner.Substring(0, 2).Equals("__"))
        {
            Destroy(collision.gameObject);
            Destroy(this);
            Debug.Log("Accidentes");
        } else if (collisioner == "salida")
        {
            Destroy(this);
        }
        if (collisioner == "giro_glorieta_1")
        {
            int cruce = Random.Range(0, 2);
            if (cruce == 1)
            {
                cruzando = false;
                Cruzar(0f, 90f, 0f);
            }
        }
        else if (collision.gameObject.name == "giro_esquina")
        {
            cruzando = false;
            Cruzar(0f, -90f, 0f);
        }
        Transform myParent = collision.gameObject.transform.parent;
        if (myParent != null)
        {
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
                            // Mayor probabilidad de salir del sistema y evitar congestionamiento
                            if (desvio == 0 || desvio == 1) ruta = 3;
                            break;
                        case 2:
                            // Este cruce mantiene los vehículos más tiempo en el sistema
                            if (desvio == 0) ruta = 5;
                            break;
                        case 4:
                            if (desvio == 0 || desvio == 1) ruta = 7;
                            break;
                        case 6:
                            if (desvio == 0 || desvio == 1) ruta = 8;
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
                        objParent.GetComponent<controlCruces>().Ruta3 = false;
                    }
                }
                else if (giro == 2 && (ruta == 4 || ruta == 7))
                {
                    if (ruta == 4 && !cruzando)
                    {
                        Cruzar(0f, 90f, 0f);
                        objParent.GetComponent<controlCruces>().Ruta4 = false;
                    }
                }
                else if (giro == 3)
                {
                    if (ruta == 5 && !cruzando)
                    {
                        Cruzar(0f, -90f, 0f);
                        objParent.GetComponent<controlCruces>().Ruta5 = false;
                    }
                }
                else if (giro == 4)
                {
                    if (ruta == 6 && !cruzando)
                    {
                        Cruzar(0f, -90f, 0f);
                        objParent.GetComponent<controlCruces>().Ruta6 = false;
                    }
                }
                else if (giro == 5 && (ruta == 4 || ruta == 7))
                {
                    // Caso especial, giro obligatorio en caso de 3 cruces.
                    Cruzar(0f, 90f, 0f);
                } else if (giro == 6 && (ruta == 6 || ruta == 8))
                {
                    // Caso especial, giro obligatorio en caso de 3 cruces.
                    Cruzar(0f, -90f, 0f);
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
            if (collisioner.Substring(0, 4).Equals("ruta"))
            {
                int iniRuta = int.Parse(collisioner.Substring(5,1));
                switch (iniRuta)
                {
                    case 1:
                        if (ruta == 3)
                        {
                            objParent.GetComponent<controlCruces>().Ruta3 = true;
                        }
                        else if (ruta == 1)
                        {
                            objParent.GetComponent<controlCruces>().Ruta1 = true;
                        }
                        break;
                    case 2:
                        if (ruta == 2)
                        {
                            objParent.GetComponent<controlCruces>().Ruta2 = true;
                        } else if(ruta == 5)
                        {
                            objParent.GetComponent<controlCruces>().Ruta5 = true;
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        print(transform.name + "Colisionado con " + collisioner);
                        GameObject espera41 = objParent.transform.Find("espera_4_1").gameObject;
                        Transform transform_espera41 = espera41.GetComponent<Transform>();
                        GameObject espera42 = objParent.transform.Find("espera_4_2").gameObject;
                        Transform transform_espera42 = espera42.GetComponent<Transform>();
                        GameObject espera43 = objParent.transform.Find("espera_4_3").gameObject;
                        Transform transform_espera43 = espera43.GetComponent<Transform>();
                        if (ruta == 4)
                        {
                            objParent.GetComponent<controlCruces>().Ruta4 = true;
                            if (objParent.GetComponent<controlCruces>().Ruta1)
                            {
                                transform_espera41.localPosition = new Vector3(espera41.transform.localPosition.x, espera41.transform.localPosition.y, -0.44f);
                                transform_espera42.localPosition = new Vector3(espera42.transform.localPosition.x, espera42.transform.localPosition.y, -0.44f);
                                transform_espera43.localPosition = new Vector3(espera43.transform.localPosition.x, espera43.transform.localPosition.y, -0.44f);
                                EsperarRuta();
                            }
                            else
                            {
                                transform_espera41.localPosition = new Vector3(espera41.transform.localPosition.x, espera41.transform.localPosition.y, -1f);
                                transform_espera42.localPosition = new Vector3(espera42.transform.localPosition.x, espera42.transform.localPosition.y, -1f);
                                transform_espera43.localPosition = new Vector3(espera43.transform.localPosition.x, espera43.transform.localPosition.y, -1f);
                                velocidad = velocidadInicial;
                            }
                        }
                        else if (ruta == 7)
                        {
                            objParent.GetComponent<controlCruces>().Ruta7 = true;
                            if (objParent.GetComponent<controlCruces>().Ruta1 || objParent.GetComponent<controlCruces>().Ruta2 || objParent.GetComponent<controlCruces>().Ruta6)
                            {
                                transform_espera41.localPosition = new Vector3(espera41.transform.localPosition.x, espera41.transform.localPosition.y, -0.44f);
                                transform_espera42.localPosition = new Vector3(espera42.transform.localPosition.x, espera42.transform.localPosition.y, -0.44f);
                                transform_espera43.localPosition = new Vector3(espera43.transform.localPosition.x, espera43.transform.localPosition.y, -0.44f);
                                EsperarRuta();
                            }
                            else
                            {
                                transform_espera41.localPosition = new Vector3(espera41.transform.localPosition.x, espera41.transform.localPosition.y, -1f);
                                transform_espera42.localPosition = new Vector3(espera42.transform.localPosition.x, espera42.transform.localPosition.y, -1f);
                                transform_espera43.localPosition = new Vector3(espera43.transform.localPosition.x, espera43.transform.localPosition.y, -1f);
                                velocidad = velocidadInicial;
                            }
                        }
                        break;
                    case 5:
                        break;
                    case 6:
                        GameObject espera61 = objParent.transform.Find("espera_6_1").gameObject;
                        Transform transform_espera61 = espera61.GetComponent<Transform>();
                        GameObject espera62 = objParent.transform.Find("espera_6_2").gameObject;
                        Transform transform_espera62 = espera62.GetComponent<Transform>();
                        GameObject espera63 = objParent.transform.Find("espera_6_3").gameObject;
                        Transform transform_espera63 = espera63.GetComponent<Transform>();
                        
                        if (ruta == 6)
                        {
                            objParent.GetComponent<controlCruces>().Ruta6 = true;
                            if (objParent.GetComponent<controlCruces>().Ruta2)
                            {
                                transform_espera61.localPosition = new Vector3(espera61.transform.localPosition.x, espera61.transform.localPosition.y, -0.44f);
                                transform_espera62.localPosition = new Vector3(espera62.transform.localPosition.x, espera62.transform.localPosition.y, -0.44f);
                                transform_espera63.localPosition = new Vector3(espera63.transform.localPosition.x, espera63.transform.localPosition.y, -0.44f);
                                EsperarRuta();
                            } else
                            {
                                transform_espera61.localPosition = new Vector3(espera61.transform.localPosition.x, espera61.transform.localPosition.y, -1f);
                                transform_espera62.localPosition = new Vector3(espera62.transform.localPosition.x, espera62.transform.localPosition.y, -1f);
                                transform_espera63.localPosition = new Vector3(espera63.transform.localPosition.x, espera63.transform.localPosition.y, -1f);
                                velocidad = velocidadInicial;
                            }
                        }
                        else if (ruta == 8)
                        {
                            objParent.GetComponent<controlCruces>().Ruta8 = true;
                            if (objParent.GetComponent<controlCruces>().Ruta1 || objParent.GetComponent<controlCruces>().Ruta2)
                            {
                                transform_espera61.localPosition = new Vector3(espera61.transform.localPosition.x, espera61.transform.localPosition.y, -0.44f);
                                transform_espera62.localPosition = new Vector3(espera62.transform.localPosition.x, espera62.transform.localPosition.y, -0.44f);
                                transform_espera63.localPosition = new Vector3(espera63.transform.localPosition.x, espera63.transform.localPosition.y, -0.44f);
                                EsperarRuta();
                            }
                            else
                            {
                                transform_espera61.localPosition = new Vector3(espera61.transform.localPosition.x, espera61.transform.localPosition.y, -1f);
                                transform_espera62.localPosition = new Vector3(espera62.transform.localPosition.x, espera62.transform.localPosition.y, -1f);
                                transform_espera63.localPosition = new Vector3(espera63.transform.localPosition.x, espera63.transform.localPosition.y, -1f);
                                velocidad = velocidadInicial;
                            }

                        }
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
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
        }
    }

    private void EsperarRuta()
    {
        if (velocidad <= 0f)
        {
            velocidad = -velocidad / 1.01f;
        } else
        {
            velocidad = -velocidad * 1.01f;
        }
    }
}
