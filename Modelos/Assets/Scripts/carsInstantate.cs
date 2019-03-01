using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carsInstantate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject car;
    public float instanceRate = 15f;
    private float nextInstance = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time> nextInstance)
        {
            nextInstance = Time.time + instanceRate;
            Instantiate(car,transform.position,transform.rotation);
        }
    }
}
