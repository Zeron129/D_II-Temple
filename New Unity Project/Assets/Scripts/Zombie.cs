using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	bool IsActive;
	[SerializeField] float speed;
	[SerializeField] float distanciaIdle;
	[SerializeField] float distanciaWalk;
	[SerializeField] Player Food;


	void Start () {
		
	}

	void Update () {
		CharacterController z_characterControler = GetComponent<CharacterController>();
			//Check Distancia
			RaycastHit hit;
			if (Physics.Raycast (transform.position, Food.transform.position, out hit)) {
			CheckDistancia (hit.distance, z_characterControler);
			}
	}

	public void CheckDistancia(float distance, CharacterController charCon){
		if (distance > distanciaIdle) {
			Idle ();
		}
		else{ 
			if(distance>distanciaWalk){
				Walk (charCon);
			}
			else{ 
				Attack(charCon);
			}
		}
	}
	

	public void Idle(){
		Animator z_animator = GetComponent<Animator>();
		z_animator.SetBool("Idle", true);
		z_animator.SetBool("Walk", false);
		z_animator.SetBool("Attack", false);
	}
	public void Walk(CharacterController charCon){
		transform.LookAt (Food.transform);
		//move
		Vector3 direction = new Vector3 (0f, 0f, speed);
		direction = transform.TransformDirection(direction);
		charCon.Move(direction * Time.deltaTime);

		Animator z_animator = GetComponent<Animator>();
		z_animator.SetBool("Idle", false);
		z_animator.SetBool("Walk", true);
		z_animator.SetBool("Attack", false);
	}
	public void Attack(CharacterController charCon){
		transform.LookAt (Food.transform);
		Animator z_animator = GetComponent<Animator>();
		z_animator.SetBool("Idle", false);
		z_animator.SetBool("Walk", false);
		z_animator.SetBool("Attack", true);
	}
}
