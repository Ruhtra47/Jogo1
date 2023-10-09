using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
	[SerializeField] private float maximumStamina;
	[SerializeField] private UnityEngine.UI.Image staminaBarForeground;
	private const float REFILL_SPEED = 12.5f;
	private const float DASH_COST = 25f;
	private float currentStamina;

	private void Awake() {
		currentStamina = maximumStamina;
	}

	public void AddStamina(float amountToAdd) {
		if (currentStamina + amountToAdd >= maximumStamina) {
			currentStamina = maximumStamina;
		} else {
			currentStamina += maximumStamina;
		}
		staminaBarForeground.fillAmount = currentStamina / maximumStamina;
	}

	public bool SpendStamina() {
		if (DASH_COST > currentStamina) {
			return false;
		} else {
			currentStamina -= DASH_COST;
			staminaBarForeground.fillAmount = currentStamina / maximumStamina;
			return true;
		}
	}

	public void RefillStamina() {
		if (currentStamina >= maximumStamina) {
			return;
		} else {
			currentStamina += Time.deltaTime * REFILL_SPEED;
		}
		staminaBarForeground.fillAmount = currentStamina / maximumStamina;
	}
}
