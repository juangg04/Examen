using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float rotacion = 200.0f;
    public float x, y;

    //Defino las varibales para el movimiento 

    public Vector3 PosIni;
    private Rigidbody rb;
    public bool Muerto = false;
    public int ContadorMuertes;
    //Creo un bool para saber cuando esta muerto el personaje
    //Guardo su Rigidbody y posicion para ponerlo en su estado inicial al morir

    public Boton boton;
    //Objeto boton para abrir las barreras al apretarlo con el ataque

    // Start is called before the first frame update
    void Start()
    {
        //Busca el RigidBody
        rb = GetComponent<Rigidbody>();
        PosIni = transform.position; 
        //Almacena posicion
    }

    // Update is called once per frame
    void Update()
    {
        //Uso los inputs verticales y horizontales para almacenarlos en las variables
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump")) //Este es el ataque que se hace con la tecla espacio para darle al boton
        {
            Collider[] Overlap = Physics.OverlapBox(this.transform.position, Vector3.one * 5); //Creo un overlap
            if (Overlap.Length > 0 )
            {
                boton.apretado = false;
                for (int i = 0; i < Overlap.Length && !boton.apretado; i++)
                {
                    if (Overlap[i].gameObject.CompareTag("Boton"))
                    {
                        boton.apretado = true;
                    }
                }
            }
        }

        //Con el vertical muevo en el eje y usando la velocidad que antes defini y el deltatime
        transform.Translate(y * Time.deltaTime * velocidad, 0, 0);
        //Lo mismo pero con la rotación
        transform.Rotate(0, x * Time.deltaTime * rotacion, 0);
        //Pongo el metodo morir para que compruebe
        Morir();
    }

    void Morir()
    {
        if(Muerto)
        {
            rb.position = PosIni; //Reset de posicion
            ContadorMuertes++;
            Muerto = false;
        }
    }
}
