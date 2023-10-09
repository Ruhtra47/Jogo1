using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController2D : MonoBehaviour
{
	private const float DAMAGE_DELAY = 0.5f;
	private const float MOVE_SPEED = 5f;
	private const float DASH_AMOUNT = 5f;
	private CharacterBase characterBase;
	private HealthController healthController;
	private StaminaController staminaController;
	private Rigidbody2D rigidBody;
	private Vector3 moveDir;
	private bool isDashButtonDown;
	private bool damageOk;
	private float timeUntilDamageOk;

	private void Awake() {
		damageOk = true;
		timeUntilDamageOk = 0f;
		rigidBody = GetComponent<Rigidbody2D>();
		characterBase = GetComponentInChildren<CharacterBase>();
		healthController = GetComponent<HealthController>();
		staminaController = GetComponent<StaminaController>();
	}

	private void Update() {
		SetDamageOk();

		staminaController.RefillStamina();

		float moveX = 0f, moveY = 0f;

		if (Input.GetKey(KeyCode.W)) {
			moveY = 1f;
		}
		if (Input.GetKey(KeyCode.S)) {
			moveY = -1f;
		}
		if (Input.GetKey(KeyCode.D)) {
			moveX = 1f;
		}
		if (Input.GetKey(KeyCode.A)) {
			moveX = -1f;
		}

		moveDir = new Vector3(moveX, moveY).normalized;

		int runningDirection;
		bool isDashing = false;

		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			if (staminaController.SpendStamina()) {
				isDashButtonDown = true;
				isDashing = true;
			}
		}

		if ((moveX == 0f) && (moveY == 0f)) {
			runningDirection = 0;
		} else if (moveX < 0f) {
			runningDirection = -1;
		} else {
			runningDirection = 1;
		}

		characterBase.PlayMovementAnimation(runningDirection, isDashing);

	}

	private void FixedUpdate() {
		rigidBody.velocity = moveDir * MOVE_SPEED;
		if (isDashButtonDown) {
			rigidBody.MovePosition(transform.position + moveDir * DASH_AMOUNT);
			isDashButtonDown = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.CompareTag("Enemy")) {
			if (damageOk) {
				healthController.TakeDamage(1f);
				damageOk = false;
				timeUntilDamageOk = DAMAGE_DELAY;
			}
		}
	}

	private void SetDamageOk() {
		if (damageOk) return;
		timeUntilDamageOk -= Time.deltaTime;
		if (timeUntilDamageOk <= 0f) {
			damageOk = true;
		}
	}

	public Vector3 GetPosition() {
		return transform.position;
	}
}
