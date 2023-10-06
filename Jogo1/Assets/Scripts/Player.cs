using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private Transform rotationPoint;
	[SerializeField] private Transform firingPoint;

	private Rigidbody2D rigidBody;
	private float moveX, moveY;

	private Vector2 mousePos;

	private void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		float angle = Mathf.Atan2(mousePos.y - moveY, mousePos.x - moveX) * Mathf.Rad2Deg - 90f;
		rotationPoint.rotation = Quaternion.Euler(0, 0, angle);

		if (Input.GetMouseButtonDown(0)) {
			Shoot();
		}
	}

	private void Shoot() {
		Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation * Quaternion.Euler(0, 0, 90));
	}

	private void FixedUpdate() {
		rigidBody.velocity = new Vector2(moveX, moveY) * moveSpeed;
	}
}
