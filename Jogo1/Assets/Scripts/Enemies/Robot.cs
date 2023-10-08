using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Robot : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private int enemyLife;
	[SerializeField] private Rigidbody2D rigidBody;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Animator animator;

	private CharacterController2D characterController;
	private EnemySpawner enemySpawner;

	private Vector2 moveDirection;

	private void Awake() {
		characterController = GameObject.Find("Player").GetComponent<CharacterController2D>();
		enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
	}

	private void Update() {
		moveDirection = characterController.transform.position - transform.position;
		moveDirection = moveDirection.normalized;

		rigidBody.velocity = moveSpeed * moveDirection;

		if (rigidBody.velocity.x > 0) {
			spriteRenderer.flipX = false;
			animator.SetBool("Running", true);
		}
		if (rigidBody.velocity.x < 0) {
			spriteRenderer.flipX = true;
			animator.SetBool("Running", true);
		}

		if (enemyLife <= 0) {
			Destroy(gameObject);
			enemySpawner.enemyCounter--;
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Projectile")) {
			Destroy(collision.gameObject);
			enemyLife--;
		}
	}
}
