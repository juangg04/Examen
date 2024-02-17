using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float tiempo;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime; //Calcula el tiempo
    }
}
