using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float distanciaIdle;
	[SerializeField] float distanciaAttack;
	[SerializeField] float lenght;
    [SerializeField] Player Food;
    [SerializeField] LayerMask layer;

    bool Attacar = false;

	void Start () {
		
	}

	void Update () {
        transform.LookAt(Food.transform);
        CharacterController z_characterControler = GetComponent<CharacterController>();
        Health z_health = GetComponent<Health>();
		//Check Distancia
		//RaycastHit hit;
        if(!Attacar)
            Walk(z_characterControler);
        else
            Attack(z_characterControler);

        /*if (Physics.Raycast (transform.position, transform.forward,out hit, lenght, layer)) {
            Debug.DrawLine(transform.position, Food.transform.position, Color.green);
            //CheckDistancia (hit.distance, z_characterControler);
            //print("distancia: " + hit.distance);
            Walk(z_characterControler);
        }*/
        //check Health

    }

	public void CheckDistancia(float distance, CharacterController charCon){
		if (distance > distanciaIdle) {
			Idle ();
		}
		else{ 
			if(distance < distanciaAttack){
                Attack(charCon);
			}
			else{
                Walk(charCon);
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
		Animator z_animator = GetComponent<Animator>();
		z_animator.SetBool("Idle", false);
		z_animator.SetBool("Walk", false);
		z_animator.SetBool("Attack", true);
	}


    private void OnTriggerEnter(Collider other)
    {
        Attacar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Attacar = false;
    }
}
