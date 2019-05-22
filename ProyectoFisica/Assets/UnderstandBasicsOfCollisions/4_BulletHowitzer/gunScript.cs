// gunScript.cs
//
// Created by: Jimmy.M
// Company: Canopus 3D-creation (http://www.canopus3Dcreation.com)
//
// Version: 1.01
//
// Copyright © Canopus 3D-creation  2012 
//

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gunScript : MonoBehaviour {

    // the gun for fire
    public float initialVelocity;
    public GameObject gun;
	private bool shot = false;
	
	// private data
	private GameObject bullet=null;
	private float power;
	
	//------------------------------------------------------------
	// Use this for initialization
	void Start () {
		bullet = GameObject.Find("bullet");
				
	}
	
	//------------------------------------------------------------
	// Update is called once per frame
	// control of gun
	void Update () {
		// control of gun, just little rotatation left/right
		if( Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(0,-0.5f,0);
		
		
		// power of shot
		if( Input.GetKey("space") ) {
			power +=0.5f;
			
		}
        // power of shot
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("PerfectScene");

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");

        }
        // firing of the projectile
        if ( Input.GetKeyUp("space") && !shot ) {
            if ((GameObject.Find("cubemass").GetComponent<Text>().text)!= "" && (GameObject.Find("bulletmass").GetComponent<Text>().text)!="") {
                if ((float.Parse((GameObject.Find("cubemass").GetComponent<Text>().text))) > 0 && (float.Parse((GameObject.Find("bulletmass").GetComponent<Text>().text))) > 0) {
                    GameObject obj = Instantiate(bullet, gun.transform.position, gun.transform.rotation) as GameObject;

                    obj.GetComponent<Rigidbody>().useGravity = false;
                    obj.GetComponent<Rigidbody>().velocity = gun.transform.TransformDirection(Vector3.forward * power);
                    GameObject.Find("velocidadInicial").GetComponent<Text>().text = "VELOCIDAD INICIAL DE LA BALA : " + obj.GetComponent<Rigidbody>().velocity.z.ToString();
                    initialVelocity = obj.GetComponent<Rigidbody>().velocity.z;
                    obj.GetComponent<bulletScript>().bulletInitialVelocity = initialVelocity;
                    obj.name = "BulletClone";
                    obj.GetComponent<Rigidbody>().mass= (float.Parse((GameObject.Find("bulletmass").GetComponent<Text>().text)));
                    GameObject.Find("Cubo").GetComponent<Rigidbody>().mass = (float.Parse((GameObject.Find("cubemass").GetComponent<Text>().text)));
                    GameObject.Find("bulletmasa").GetComponent<InputField>().DeactivateInputField();
                    GameObject.Find("cubemasa").GetComponent<InputField>().DeactivateInputField();
                    power = 0.0f;
                    shot = true;
                }
            }
		}
	}
}
