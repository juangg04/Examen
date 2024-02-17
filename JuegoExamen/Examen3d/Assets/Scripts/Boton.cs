using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public bool apretado = false;
    public GameObject barrera1;
    public GameObject barrera2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (apretado)
        {
            //Logica para destruir las barreras al apretar el boton
            Destroy(barrera1, 1f);
            Destroy(barrera2, 1f);
        }
    }
}
