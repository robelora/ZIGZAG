using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JugadorBola : MonoBehaviour
{   
    // Start is called before the first frame update
    public Camera camara;
    public GameObject suelo;
    public GameObject meta;
    public float velocidad=7.0f;
    public int nsuelos=0, totalsuelos=0,boolmeta=0;
    private Vector3 offSet;
    private float ValX=0.0f, ValZ = 0.0f;
    private Vector3 DireccionActual;
    private int miPuntuacion = 0;
    [SerializeField] private TMP_Text textoPuntuacion;
    [SerializeField] private TMP_Text textoPuntuacionTotal; //para asgnar el valor de la puntuacion total de la pantalla del gameover!
    [SerializeField] private ParticleSystem particulas;
    [SerializeField] private GameObject estrella;
    private int aleatorio2;
    void Start()
    {       
        
        offSet = camara.transform.position - transform.position;
        CrearSueloInicial();
        DireccionActual = Vector3.forward;
    }

    void Update()
    {
        camara.transform.position = transform.position + offSet;
        if(Input.GetKeyUp(KeyCode.Space)){
            CambiarDireccion();
        }
        transform.Translate(DireccionActual*velocidad*Time.deltaTime);
    }

    void CrearSueloInicial(){
        
        int cont = 0;
        for(int i=0;i<3;i++){
            cont++;
            ValZ += 6.0f;
            Instantiate(suelo, new Vector3(ValX,0,ValZ), Quaternion.identity);
            
                       
        }
          
        
    }

    void CambiarDireccion(){
        if(DireccionActual==Vector3.forward)
            DireccionActual=Vector3.right;
        else
            DireccionActual=Vector3.forward;
        SumarPuntuacion();   
    }

    private void OnCollisionExit(Collision other){
        if(other.gameObject.tag =="suelo" && totalsuelos<20){
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
        if(other.gameObject.tag=="suelo" && totalsuelos==20){
           StartCoroutine(LlegadaMeta());
             
        }
    }
    IEnumerator LlegadaMeta(){
        if(boolmeta==0){
            boolmeta=1;
            meta.gameObject.SetActive(true);
            float aleatorio= Random.Range(0.0f, 1.0f);
            if(aleatorio>0.5f)
                ValX += 3.0f;
            else
                ValZ += 6.0f;
            Instantiate(meta, new Vector3(ValX,0.1f,ValZ), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            Time.timeScale= 0f;
        }
        
        
    }


    IEnumerator BorrarSuelo(GameObject suelo){
        if(nsuelos<11 && totalsuelos!=20){
            float aleatorio= Random.Range(0.0f, 1.0f);
            if(aleatorio>0.5f)
                ValX += 3.0f;
            else
                ValZ += 6.0f;

            Instantiate(suelo, new Vector3(ValX,0,ValZ), Quaternion.identity);
            nsuelos++;
           float probabilidad = Random.value; // Genera un número aleatorio entre 0 y 1

            if (probabilidad <= 0.1f) { // Si la probabilidad es menor o igual a 0.1(10%)
                float aleatorioValorX = Random.Range(1.0f, 2.0f);
                estrella.SetActive(true);
                Instantiate(estrella, new Vector3(aleatorioValorX+ValX, 1.0f, ValZ), estrella.transform.rotation);   
            }
            yield return new WaitForSeconds(1);  
            suelo.gameObject.GetComponent<Rigidbody>().isKinematic=false;
            suelo.gameObject.GetComponent<Rigidbody>().useGravity=true;
            yield return new WaitForSeconds(1);
            Destroy(suelo);
            nsuelos--;
            totalsuelos++;
          
            
        }
    }
    void SumarPuntuacion(){
        miPuntuacion++;
        textoPuntuacion.text = miPuntuacion.ToString();
        textoPuntuacionTotal.text = textoPuntuacion.text;

    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("coin")){
            //particulas.SetActive(true);
            particulas.Play();
            miPuntuacion = miPuntuacion + 10;
            Destroy(other.gameObject);
            
            }
        }
    
}