using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	[SerializeField] float speedRotation;
	[SerializeField] int Value;

	public int GetValue(){
		return Value;
	}

	void Awake () {
		if (speedRotation == 0)
			speedRotation = 5;
		if (Value == 0)
			Value = 5;
	}
	

	void Update () {
		transform.Rotate (Vector3.up * speedRotation * Time.deltaTime);
	}
}
