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
    GameObject jugadorObject = GameObject.FindGameObjectWithTag("jugador");
    if (jugadorObject != null)
    {
        jugadorbola = jugadorObject.GetComponent<JugadorBola>();
        jugadorbola.MuerteJugador += ActivarMenu;
    }
    GameObject jugadorObject = GameObject.FindGameObjectWithTag("jugador");
    if (jugadorObject != null)
    {
        jugadorbola2 = jugadorObject.GetComponent<JugadorBola2>();
        jugadorbola2.MuerteJugador += ActivarMenu;
    }
    GameObject jugadorObject = GameObject.FindGameObjectWithTag("jugador");
    if (jugadorObject != null)
    {
        jugadorbola3 = jugadorObject.GetComponent<JugadorBola3>();
        jugadorbola3.MuerteJugador += ActivarMenu;
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
