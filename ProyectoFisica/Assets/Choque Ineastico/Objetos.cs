using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetos : MonoBehaviour {


    private float velocidadInicial1;
    private float velocidadInicial2;
    public GameObject ui;
    // Use this for initialization
    void Start () {
        velocidadInicial1 = 0;	
        velocidadInicial2 = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Objeto1").GetComponent<Rigidbody>().velocity.x != 0 && velocidadInicial1 == 0) {
            velocidadInicial1 = GameObject.Find("Objeto1").GetComponent<Rigidbody>().velocity.x;
        }
        if (GameObject.Find("Objeto2").GetComponent<Rigidbody>().velocity.x != 0 && velocidadInicial2 == 0)
        {
            velocidadInicial2 = GameObject.Find("Objeto2").GetComponent<Rigidbody>().velocity.x;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Object")
        {
            float coeficienteR = ui.GetComponent<Pausa>().coeficienteR;

            float velocidadFinal1 = ((((1 - coeficienteR) * velocidadInicial1) + ((1 + coeficienteR) * velocidadInicial2)) / (1 + 1));
            float velocidadFinal2 = ((((1 + coeficienteR) * velocidadInicial1) + ((1 - coeficienteR) * velocidadInicial2)) / (1 + 1));
            
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * velocidadFinal1;
            GameObject.Find("Objeto2").GetComponent<Rigidbody>().velocity = Vector3.right * velocidadFinal2;

            GameObject.Find("Velocidad1").GetComponent<Text>().text = "Velocidad Final Objeto 1: " + Mathf.Abs(velocidadFinal1);
            GameObject.Find("Velocidad2").GetComponent<Text>().text = "Velocidad Final Objeto 2: " + Mathf.Abs(velocidadFinal2);
        }
    }
}
