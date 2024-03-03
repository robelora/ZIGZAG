using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private JugadorBola jugadorbola;

    private void Start()
{
    GameObject jugadorObject = GameObject.FindGameObjectWithTag("jugador");
    if (jugadorObject != null)
    {
        jugadorbola = jugadorObject.GetComponent<JugadorBola>();
        jugadorbola.MuerteJugador += ActivarMenu;
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
