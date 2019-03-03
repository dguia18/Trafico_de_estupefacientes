using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCarro : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    void Start()
    {

    }
    void Update (){
        
        
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, speed * Time.deltaTime);

        //if (this.transform.position.x <= 194.5f && this.transform.position.x >= 192f)
        //{
        //    int opcionMovimiento = 0;
        //    opcionMovimiento = Random.Range(0, 3);
        //    if (opcionMovimiento == 2)
        //    {
        //        transform.Rotate(new Vector3(0f, 225f, 0f) * Time.deltaTime);
        //    }
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Girar1")
        {            
                transform.Rotate(new Vector3(0f, 90f, 0f));
        }        
        if (collision.gameObject.name == "Girar")
        {
            int opcionMovimiento = 0;
            opcionMovimiento = Random.Range(0, 3);
            Debug.Log(opcionMovimiento);
            if (opcionMovimiento == 2)
                transform.Rotate(new Vector3(0f, 90f, 0f));
        }        
    }
}
