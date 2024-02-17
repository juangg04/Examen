using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Trampa : MonoBehaviour
{
    public float velocidadtrampa = 5; //Velocidad de la trampa
    public bool lado = false; //Bool para saber hacia que lado va la trampa
    public Personaje player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de la trampa
        if(transform.position.x > -12.9 && lado == false)
        {
            transform.Translate(-1 * velocidadtrampa * Time.deltaTime, 0, 0);
        }
        else
        {
            lado = true;
        }
        if (transform.position.x < -1.51 && lado == true)
        {
            transform.Translate(velocidadtrampa * Time.deltaTime, 0, 0);
        }
        else
        {
            lado = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Compruebo el tag del player
        {
            player.transform.position = player.PosIni;
            player.Muerto = true;
        }
    }
}
