using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public Canvas meta;
    public Timer tiempo;
    public TextMeshProUGUI textofinal;
    public Personaje player;
    private int Score;
    // Start is called before the first frame update
    void Start()
    {
        meta.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meta.enabled = true; //Activa el canvas al llegar al final
            Score = 10 - player.ContadorMuertes;
            if(Score < 0 )
            {
                Score = 0;
            }
            //Calculo del Score
            textofinal.text = "Score: " + Score + "    " + "Tiempo: " + tiempo.tiempo;
            //Pongo el Score en el texto final y el tiempo que se ha tardado en acabar
        }
    }
}
