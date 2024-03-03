using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private JugadorBola jugadorbola;
    private JugadorBolaNivel2 jugadorbola2;
    private JugadorBolaNivel3 jugadorbola3;

    private void Start()
{
    if(SceneManager.GetActiveScene().name=="Nivel1"){
        GameObject jugadorObject1 = GameObject.FindGameObjectWithTag("jugador");
         if (jugadorObject1 != null)
        {
            jugadorbola = jugadorObject1.GetComponent<JugadorBola>();
            jugadorbola.MuerteJugador += ActivarMenu;
        }
    }

    if(SceneManager.GetActiveScene().name=="nivel2"){
        GameObject jugadorObject2 = GameObject.FindGameObjectWithTag("jugador");
         if (jugadorObject2 != null)
        {
            jugadorbola2 = jugadorObject2.GetComponent<JugadorBolaNivel2>();
            jugadorbola2.MuerteJugador += ActivarMenu;
        }
    }

    if(SceneManager.GetActiveScene().name=="nivel 3"){
        GameObject jugadorObject3 = GameObject.FindGameObjectWithTag("jugador");
         if (jugadorObject3 != null)
        {
            jugadorbola3 = jugadorObject3.GetComponent<JugadorBolaNivel3>();
            jugadorbola3.MuerteJugador += ActivarMenu;
        }

    }
}

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }
   
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
