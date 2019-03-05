using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCruces : MonoBehaviour
{
    private bool ruta1, ruta2, ruta3, ruta4, ruta5, ruta6, ruta7, ruta8;

    public bool Ruta1 { get => ruta1; set => ruta1 = value; }
    public bool Ruta2 { get => ruta2; set => ruta2 = value; }
    public bool Ruta3 { get => ruta3; set => ruta3 = value; }
    public bool Ruta4 { get => ruta4; set => ruta4 = value; }
    public bool Ruta5 { get => ruta5; set => ruta5 = value; }
    public bool Ruta6 { get => ruta6; set => ruta6 = value; }
    public bool Ruta7 { get => ruta7; set => ruta7 = value; }
    public bool Ruta8 { get => ruta8; set => ruta8 = value; }

    // Start is called before the first frame update
    void Start()
    {
        Ruta1 = false;
        Ruta2 = false;
        Ruta3 = false;
        Ruta4 = false;
        Ruta5 = false;
        Ruta6 = false;
        Ruta7 = false;
        Ruta8 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
