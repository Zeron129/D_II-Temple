using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] float MovementSpeed = 10;
    [SerializeField] float RotationSpeed = 10;
    Time t;

	// Use this for initialization
	void Start () {
     

	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(MovementSpeed * horizontal * Time.deltaTime, 0, MovementSpeed * vertical * Time.deltaTime);
	}
}
