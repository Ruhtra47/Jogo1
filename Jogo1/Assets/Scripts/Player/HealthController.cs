using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	[SerializeField] private float maximumHealth;

	private float currentHealth;

	private void Awake() {
		currentHealth = maximumHealth;
	}

	public void AddHealth(float amountToAdd) {
		if (currentHealth + amountToAdd >= maximumHealth) {
			currentHealth = maximumHealth;
		} else {
			currentHealth += amountToAdd;
		}
	}

	public void TakeDamage(float amoutOfDamage) {
		currentHealth -= amoutOfDamage;
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}
}
