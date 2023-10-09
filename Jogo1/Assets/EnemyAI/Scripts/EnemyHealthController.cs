using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
	private float currentHealth;
	private const float MAXIMUM_HEALTH = 5f;

	private void Awake() {
		currentHealth = MAXIMUM_HEALTH;
	}

	private void Update() {
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Projectile")) {
			currentHealth--;
			Destroy(collision.gameObject);
		}
	}
}
