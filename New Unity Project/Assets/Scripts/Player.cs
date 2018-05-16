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
	[SerializeField] float vida;
	[SerializeField] MouseInput MouseControl;

	private MoveController m_MoveController;
	public MoveController MoveController {
		get {
			if (m_MoveController == null)
				m_MoveController = GetComponent<MoveController> ();
			return m_MoveController;
		}
	}

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
		Vector2 direction = new Vector2 (playerInput.Vertical * speed, playerInput.Horizontal * speed);
		MoveController.Move(direction);

		mouseInput.x = Mathf.Lerp (mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
		transform.Rotate (Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
	}

	void OnTriggerEnter(Collider Other){
		if (Other.tag == "Reward") {
			Collectibles.SumarPuntos (Other.gameObject.GetComponent<coin>());
			Destroy (Other.gameObject);
		}
	}
}
