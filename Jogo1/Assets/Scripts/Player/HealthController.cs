using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	[SerializeField] private float maximumHealth;
	[SerializeField] private UnityEngine.UI.Image healthBarForeground;
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
		healthBarForeground.fillAmount = currentHealth / maximumHealth;
	}

	public void TakeDamage(float amoutOfDamage) {
		currentHealth -= amoutOfDamage;
		healthBarForeground.fillAmount = currentHealth / maximumHealth;
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}
}
