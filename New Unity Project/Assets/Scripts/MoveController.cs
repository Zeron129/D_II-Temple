using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
	public void Move(CharacterController charCon, Vector3 direction, float jumpForce, float gravity){
        if (charCon.isGrounded){
            direction = transform.TransformDirection(direction);
            if (Input.GetButton("Jump"))
				direction.y = jumpForce;

        }
        direction.y -= gravity * Time.deltaTime;
        charCon.Move(direction * Time.deltaTime);
    }


    //charCon.Move(transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime);

}
/*if (m_characterControler.isGrounded) {
	verticalVelocity = -gravity * Time.deltaTime;
	if (Input.GetButton ("Jump")) {
		verticalVelocity = jumpForce;
	}
} else {
	verticalVelocity -= gravity * Time.deltaTime;
}*/