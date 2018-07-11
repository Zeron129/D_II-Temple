using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
	[SerializeField] float fireRate;
	[SerializeField] Bullet bullet;
	/*[HideInInspector] */public Transform muzzle;
	float nextFireAllowed;
	public bool canFire;

	void Awake(){
		muzzle = transform.Find ("Muzzle"); 
	}

	public virtual void fire(){
		canFire = false;

		if (Time.time < nextFireAllowed)
			return;
		nextFireAllowed = Time.time + fireRate;

		//Instantiate bullet
		Instantiate(bullet, muzzle.position, muzzle.rotation);

		canFire = true;
	}
}