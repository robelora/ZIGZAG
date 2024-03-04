using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cuentaAtras : MonoBehaviour
{   
    public Button boton;
   

    // Start is called before the first frame update
    /*void Start()
    {
        //boton = GameObject.FindWithTag("botonSalir").GetComponent<Button>();
        boton.onClick.AddListener(Empezar);
    }*/
    public void Empezar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
