using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
	public void Move(CharacterController charCon, Vector3 direction){
        //if (charCon.isGrounded){
            direction = transform.TransformDirection(direction);
            /*if (Input.GetButton("Jump"))
                direction.y = jumpSpeed;*/

        //}
        //direction.y -= gravity * Time.deltaTime;
        charCon.Move(direction * Time.deltaTime);
    }


    //charCon.Move(transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime);

}
