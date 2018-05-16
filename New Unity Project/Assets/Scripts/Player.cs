using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]

public class Player : MonoBehaviour {

	[System.Serializable]

	public class MouseInput {
		public Vector2 Damping;
		public Vector2 Sensitivity;
	}

	[SerializeField] float speed;
	//[SerializeField] float vida;
	[SerializeField] MouseInput MouseControl;

	private MoveController m_MoveController;
	public MoveController MoveController {
		get {
			if (m_MoveController == null)
				m_MoveController = GetComponent<MoveController> ();
			return m_MoveController;
		}
	}

   /* private CharacterController m_characterControler;
    public CharacterController characterController
    {
        get
        {
            if (m_characterControler == null)
                m_characterControler = GetComponent<CharacterController>();
            return m_characterControler;
        }
    }*/

    InputController playerInput;
	Vector2 mouseInput;
	CoinManager Collectibles;

	void Awake () {
		playerInput = GameManager.Instance.InputControler;
		Collectibles = GameManager.Instance.coinManager;
		GameManager.Instance.LocalPlayer = this;
		if (speed == 0)
			speed = 5;
	}

	void Update () {
        //Movement and Rotation
        CharacterController m_characterControler = GetComponent<CharacterController>();
        Vector3 direction = new Vector3 (playerInput.Horizontal * speed, 0, playerInput.Vertical * speed);
		MoveController.Move(m_characterControler, direction);

		mouseInput.x = Mathf.Lerp (mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
		transform.Rotate (Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
	}

	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.tag == "Reward") {
			Collectibles.SumarPuntos (Other.gameObject.GetComponent<coin>());
			Destroy (Other.gameObject);
		}
	}
}
