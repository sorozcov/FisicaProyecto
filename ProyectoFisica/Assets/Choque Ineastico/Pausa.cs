using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour {

    public Rigidbody objeto1;
    public Rigidbody objeto2;
    private float velocidadInicial1;
    private float velocidadInicial2;
    public float coeficienteR;
    bool isPaused;
	// Use this for initialization
	void Start () {
        transform.Find("Panel").gameObject.SetActive(false);
        transform.Find("Panel3").gameObject.SetActive(false);
        transform.Find("Panel4").gameObject.SetActive(false);
        transform.Find("Panel5").gameObject.SetActive(false);
        isPaused = false;
        velocidadInicial1 = 0;
        velocidadInicial2 = 0;
        coeficienteR = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = isPaused ? Continuar() : Pausar();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (velocidadInicial1 == 0 || velocidadInicial2 == 0 || coeficienteR < 0 || coeficienteR > 1)
            {
                transform.Find("Panel4").gameObject.SetActive(true);
                Invoke("timerMessage", 3f);
            }
            else {
                objeto1.velocity = Vector3.right * Mathf.Abs(velocidadInicial1);
                objeto2.velocity = Vector3.right * -Mathf.Abs(velocidadInicial2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Start();
            Time.timeScale = 1f;
            SceneManager.LoadScene("SimuladorChoqueInelastico");
        }
    }

    bool Continuar() {
        transform.Find("Panel").gameObject.SetActive(false);
        transform.Find("Panel2").gameObject.SetActive(true);
        Time.timeScale = 1f;
        return false;
    }

    bool Pausar() {
        transform.Find("Panel").gameObject.SetActive(true);
        transform.Find("Panel2").gameObject.SetActive(false);
        Time.timeScale = 0f;
        return true;
    }

    public void ContinuarBoton()
    {
        try
        {
            velocidadInicial1 = float.Parse(transform.Find("Panel").Find("InputField").Find("Dato1").GetComponent<Text>().text);
            velocidadInicial2 = float.Parse(transform.Find("Panel").Find("InputField2").Find("Dato2").GetComponent<Text>().text);
            coeficienteR = float.Parse(transform.Find("Panel").Find("InputField3").Find("Dato3").GetComponent<Text>().text);
            if (coeficienteR > 1 || coeficienteR < 0) {
                transform.Find("Panel5").gameObject.SetActive(true);
                Invoke("timerMessage", 3f);
            }
        }
        catch
        {
            transform.Find("Panel3").gameObject.SetActive(true);
            Invoke("timerMessage", 3f);
        }
        transform.Find("Panel").gameObject.SetActive(false);
        transform.Find("Panel2").gameObject.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void timerMessage()
    {
        if (transform.Find("Panel3").gameObject.activeInHierarchy)
        {
            transform.Find("Panel3").gameObject.SetActive(false);
        }
        if (transform.Find("Panel4").gameObject.activeInHierarchy)
        {
            transform.Find("Panel4").gameObject.SetActive(false);
        }
        if (transform.Find("Panel5").gameObject.activeInHierarchy)
        {
            transform.Find("Panel5").gameObject.SetActive(false);
        }
    }
}
