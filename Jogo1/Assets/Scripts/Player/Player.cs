using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int playerDamage;

	[SerializeField] private UnityEngine.UI.Image healthBarForegroundImage;
	[SerializeField] private int maxHealth = 10;
	[SerializeField] private float invulnerabilityTime = 1;
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private Transform rotationPoint;
	[SerializeField] private Transform firingPoint;
	[SerializeField] private SpriteRenderer gunSpriteRenderer;
	[SerializeField] private SpriteRenderer spritePlayer;
	[SerializeField] private Animator animator;
	public static Player instance;

	private bool damageOk;
	private float timeUntilDamageOk;
	private int currentHealth;

	private Rigidbody2D rigidBody;
	private float moveX, moveY;

	private Vector2 mousePos;

	private void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		currentHealth = 10;
		damageOk = true;
		timeUntilDamageOk = 0;
		instance = this;
	}

	private void Update() {
		healthBarForegroundImage.fillAmount = (float) currentHealth / (float) maxHealth; 

		SetDamageOk();

		if (currentHealth <= 0) {
			Destroy(gameObject);
		}

		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");

		if (moveX > 0) {
			spritePlayer.flipX = false;
		}
		if (moveX < 0) {
			spritePlayer.flipX = true;
		}
		if ((Mathf.Abs(moveX) < 1e-9) && (Mathf.Abs(moveY) < 1e-9)) {
			animator.SetBool("Running", false);
		} else {
			animator.SetBool("Running", true);
		}

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		float angle = Mathf.Atan2(mousePos.y - rotationPoint.position.y, mousePos.x - rotationPoint.position.x) * Mathf.Rad2Deg;
		rotationPoint.rotation = Quaternion.Euler(0, 0, angle);

		if ((angle > 90f) || (angle < -90f)) {
			gunSpriteRenderer.flipY = true;
		} else {
			gunSpriteRenderer.flipY = false;
		}

		if (Input.GetMouseButtonDown(0)) {
			Shoot();
		}
	}

	private void SetDamageOk() {
		if (damageOk) return;
		timeUntilDamageOk -= Time.deltaTime;
		if (timeUntilDamageOk <= 0) {
			damageOk = true;
		}
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if ((collision.gameObject.CompareTag("Enemy")) && damageOk) {
			currentHealth--;
			damageOk = false;
			timeUntilDamageOk = invulnerabilityTime;
		}
	}

	private void Shoot() {
		Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
	}

	private void FixedUpdate() {
		rigidBody.velocity = new Vector2(moveX, moveY).normalized * moveSpeed;
	}

	public void heal() {
		if(currentHealth < maxHealth) {
			currentHealth = maxHealth;
		}
	}
}
