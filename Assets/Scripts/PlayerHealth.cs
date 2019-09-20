using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] float playerHitPoints = 100f;

	public void TakeDamage(float damage) {
		Debug.Log("Player is hit");
		playerHitPoints -= damage;
		if(playerHitPoints <= 0) {
			Debug.Log("You are dead.. ");
		}
	}
}
