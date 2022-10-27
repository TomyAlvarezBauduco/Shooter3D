using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mortal : MonoBehaviour
{
    public float vidaTotal;
    private float vidaActual;
    public bool isAlive;

    public Image healthBar;


    protected virtual void Awake()
    {
        vidaActual = vidaTotal;
        isAlive = true;
    }

    public void RecibirAtaque(float damage)
    {
        vidaActual -= damage;

        healthBar.fillAmount = vidaActual / vidaTotal;

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    protected virtual void Morir()
    {
        isAlive = false;
    }


}
