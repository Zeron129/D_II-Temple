using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

	[SerializeField]float speed;
	[SerializeField]float timeToLive;
	[SerializeField]float damage;
	[SerializeField]float range;
	[SerializeField] GameObject hole;

	void Start(){
		Destroy (gameObject, timeToLive);
	}

	void Update(){
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, range)) {
			CheckDestructible (hit.transform);
			Instantiate (hole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
		}
	}

	void CheckDestructible(Transform other){
		var destructible = other.GetComponent<Destructible> ();
		if (destructible == null)
			return;
		destructible.TakeDamage (damage); 
		Destroy (this);
	}
}
