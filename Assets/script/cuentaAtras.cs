using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cuentaAtras : MonoBehaviour
{   
    public Button boton;
    public UnityEngine.UI.Image imagen;   
    public Sprite[] numeros;
    // Start is called before the first frame update
    void Start()
    {
        //boton = GameObject.FindWithTag("botonSalir").GetComponent<Button>();
        boton.onClick.AddListener(Empezar);
    }
    void Empezar(){
        imagen.gameObject.SetActive(true);
        //boton.gameObject.SetActive(false);

        //StartCoroutine(PonerNumeros());
        //SceneManager.LoadScene("Nivel1");
    }
    
    void Update()
    {
        
    }
}
