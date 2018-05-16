using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	[SerializeField] int PuntosTotales;

	public void SumarPuntos(coin Collectibles){

		PuntosTotales += Collectibles.GetValue();
	}
	public int GetPuntosTotales(){
		return PuntosTotales;
	}
	void Update () {
	}
}
