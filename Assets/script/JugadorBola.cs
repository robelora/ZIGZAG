using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JugadorBola : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camara;
    public GameObject suelo;
    public float velocidad=7.0f;


    private Vector3 offSet;
    private float ValX=0.0f, ValZ = 0.0f;
    private Vector3 DireccionActual;

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
            if(cont == 10){
                break;
            }
        }
    }

    void CambiarDireccion(){
        if(DireccionActual==Vector3.forward)
            DireccionActual=Vector3.right;
        else
            DireccionActual=Vector3.forward;
        
    }

    private void OnCollisionExit(Collision other){
        if(other.gameObject.tag =="suelo"){
            StartCoroutine(BorrarSuelo(other.gameObject));
        }
    }

    IEnumerator BorrarSuelo(GameObject suelo){
        float aleatorio= Random.Range(0.0f, 1.0f);
        if(aleatorio>0.5f)
            ValX += 6.0f;
        else
            ValZ += 6.0f;

        Instantiate(suelo, new Vector3(ValX,0,ValZ), Quaternion.identity);
        yield return new WaitForSeconds(2);  
        suelo.gameObject.GetComponent<Rigidbody>().isKinematic=false;
        suelo.gameObject.GetComponent<Rigidbody>().useGravity=true;
        yield return new WaitForSeconds(2);
        Destroy(suelo);

    }
}