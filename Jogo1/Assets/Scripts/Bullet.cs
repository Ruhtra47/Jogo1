using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[Range(1f, 10f)]
	[SerializeField] private float moveSpeed = 10f;
	[Range(1f, 10f)]
	[SerializeField] private float lifeTime = 3f;

	private Rigidbody2D rigidBody;

	private void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		Destroy(gameObject, lifeTime);
	}

	private void FixedUpdate() {
		rigidBody.velocity = transform.right * moveSpeed;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
		{
			collision.gameObject.GetComponent<robot>().tomoudano();
			Destroy(gameObject);
		}
	}
}
