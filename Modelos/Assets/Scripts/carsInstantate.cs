using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carsInstantate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] autos;
    public float instanceRate = 15f;
    private float nextInstance = 0.0f;
    public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;
    void Start()
    {
        StartCoroutine(ThrowCars());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ThrowCars()
    {
        // Initial delay
        yield return new WaitForSeconds(3.0f);

        while (true)
        {


            GameObject auto = (GameObject)Instantiate(autos[Random.Range(0, autos.Length)], transform.position, transform.rotation);
            //stone.transform.position = new Vector3(Random.Range(minX, maxX), -30.0f, Random.Range(minZ, maxZ));
            //stone.transform.rotation = Random.rotation;

            //nextInstance = Time.time + instanceRate;
            //Instantiate(auto, transform.position, transform.rotation);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));

        }

    }
}
