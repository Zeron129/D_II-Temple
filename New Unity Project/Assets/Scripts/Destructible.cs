using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	[SerializeField]float hitPoints;

	public event System.Action OnDeath;
	public event System.Action OnDamageRecived;

	float damageTaken;

	public float HitPointsRemaning{
		get{
			return hitPoints - damageTaken;
		}
	}

	public bool IsAlive{
		get{ 
			return HitPointsRemaning > 0;
		}
	}

	public virtual void Die(){
		if (!IsAlive)
			return;
		if (OnDeath != null)
			OnDeath ();
	}

	public virtual void TakeDamage(float amount){
		damageTaken += amount;

		if (OnDamageRecived != null)
			OnDamageRecived ();

		if (HitPointsRemaning <= 0) {
			Die ();
		}
	}

	public void Reset(){
		damageTaken=0;
	}


}