using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	private void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}

	public void PlayMovementAnimation(int runningDirection) {
		if (runningDirection == 0) {
			animator.SetBool("Running", false);
			spriteRenderer.flipX = false;
		} else if (runningDirection == 1) {
			animator.SetBool("Running", true);
			spriteRenderer.flipY = false;
		} else {
			animator.SetBool("Running", true);
			spriteRenderer.flipX = true;
		}
	}
}
