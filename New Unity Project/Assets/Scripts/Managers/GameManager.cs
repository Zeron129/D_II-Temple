using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
	public event System.Action<Player> OnLocalPlayerJoined;


	private GameObject gameObject;

	private static GameManager m_Instance;
	public static GameManager Instance{
		get{
			if(m_Instance == null){
				m_Instance = new GameManager ();
				m_Instance.gameObject = new GameObject ("_gameManager");
				m_Instance.gameObject.AddComponent<InputController> ();
				m_Instance.gameObject.AddComponent<CoinManager> ();
				m_Instance.gameObject.AddComponent<EnemyManager> ();
			}
			return m_Instance;
		}
	}

	private InputController m_inputControler;
	public InputController InputControler {
		get {
			if(m_inputControler == null)
				m_inputControler = gameObject.GetComponent<InputController> ();
			return m_inputControler;
		}
	}

	private Player m_LocalPlayer;
	public Player LocalPlayer {
		get {
			return m_LocalPlayer;
		}
		set {
			m_LocalPlayer = value;
			if (OnLocalPlayerJoined != null)
				OnLocalPlayerJoined (m_LocalPlayer);
		}
	}

	private EnemyManager m_enemyManager;
	public EnemyManager enemyManager {
		get {
			if(m_enemyManager == null)
				m_enemyManager = gameObject.GetComponent<EnemyManager> ();
			return m_enemyManager;
		}
	}

	private CoinManager m_coinManager;
	public CoinManager coinManager {
		get {
			if(m_coinManager == null)
				m_coinManager = gameObject.GetComponent<CoinManager> ();
			return m_coinManager;
		}
	}

}
