using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructible {

	public override void Die ()
	{
		base.Die ();
		print ("we Died");
	}
	public override void TakeDamage (float amount)
	{
		base.TakeDamage (amount);
		print ("Remaning: " + HitPointsRemaning);
	}
}
