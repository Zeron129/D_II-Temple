using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour {

	[SerializeField] Shooter Gun;
	[SerializeField] GameObject LookTarget;
	[SerializeField] Vector3 offset;

    Transform target;

	void Start () {
	}
	void Awake (){

	}
	

	void Update () {

		Debug.DrawRay (transform.position, transform.forward, Color.red);
		//Rotation
		if (target != null)
			transform.LookAt (target);
		else
			transform.LookAt (LookTarget.transform);
		//Shooting
		/*if (cooldownRemaning < 0.1f) {
			if (bulletsRemaning > 0) {*/
				Gun.fire ();
				/*bulletsRemaning -= 1;
			} else {
				cooldownRemaning = cooldown;
				bulletsRemaning = shotsPerRound;
			}
		} else
			cooldownRemaning -= Time.deltaTime;*/
	}

	void OnTriggerStay(Collider other){
		target = other.gameObject.transform;
        //target.position.y += offset;

    }
	void OnTriggerExit(Collider other){
		target = null;
	}
}

