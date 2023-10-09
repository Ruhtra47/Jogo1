using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	private const float REACHED_POSITION = 1f;
	private const float MOVE_SPEED = 5f;
	private const float TARGET_RANGE = 10f;
	private bool isChasing;
	private EnemyBase enemyBase;
	private Rigidbody2D rigidBody;
	private Transform playerTransform;
	private Vector3 startingPosition;
	private Vector3 roamPosition;

	private void Awake() {
		playerTransform = GameObject.Find("Player").transform;
		enemyBase = GetComponentInChildren<EnemyBase>();
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Start() {
		startingPosition = transform.position;
		roamPosition = GetRoamingPosition();
	}

	private void Update() {
        if (rigidBody.velocity == new Vector2(0, 0)) {
			enemyBase.PlayMovementAnimation(0);
        } else if (rigidBody.velocity.x < 0f) {
			enemyBase.PlayMovementAnimation(-1);
		} else {
			enemyBase.PlayMovementAnimation(1);
		}
    }

	private void FixedUpdate() {
		if (isChasing) {
			rigidBody.velocity = (playerTransform.position - transform.position).normalized * MOVE_SPEED;
		} else {
			rigidBody.velocity = (roamPosition - transform.position).normalized * MOVE_SPEED;

			if (Vector3.Distance(transform.position, roamPosition) < REACHED_POSITION) {
				roamPosition = GetRoamingPosition();
			}

			FindTarget();
		}
	}

	private Vector3 GetRoamingPosition() {
		return startingPosition + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * Random.Range(3f, 10f);
	}

	private void FindTarget() {
		if (Vector3.Distance(transform.position, playerTransform.position) < TARGET_RANGE) {
			isChasing = true;
		}
	}
}
