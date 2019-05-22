// bulletScrip.cs
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

public class bulletScript : MonoBehaviour {

    public float bulletInitialVelocity;
    float velocity = 0;
    float newMass;
    float bulletMultVelocity1;
    Rigidbody bullet;
    Rigidbody cube;
    //------------------------------------------------------------
    // Use this for initialization
    void Start () {
	
	}


	
	//------------------------------------------------------------
	// CollisionEnter callback
	void OnTriggerEnter(Collider other)
	{	
		// see if a cube is touched by our bullet.
		// if our bullet hit one of the cubes, 
		// it is destroyed and the bullet itself.
		// 
		// it will detect the object touched either by name or by its tag
		// 
		// by tag:
		if(other.gameObject.tag == "Cube")	
		//
		// or by name	
		//	if(other.gameObject.name.Contains("Cube"))	
		{
            bullet = gameObject.GetComponent<Rigidbody>();
            bullet.velocity = Vector3.zero;
            
             cube = other.gameObject.GetComponent<Rigidbody>();
            this.gameObject.transform.SetParent(other.gameObject.transform);
            newMass = bullet.mass + cube.mass;
            bulletMultVelocity1 = bullet.mass * bulletInitialVelocity;
            velocity = (bulletMultVelocity1 /newMass);
            bullet.transform.localPosition = new Vector3(0, 0,-0.650f);
           
            Invoke("newVelocity", 0.01f);
			
			
		}
	}

    void newVelocity() {


        bullet.velocity = new Vector3(0, 0, velocity);
        cube.velocity = new Vector3(0, 0, velocity);
        GameObject.Find("velocidadFinal").GetComponent<Text>().text = "VELOCIDAD FINAL DE LA BALA Y CUBO: " + (velocity);
    }
}


