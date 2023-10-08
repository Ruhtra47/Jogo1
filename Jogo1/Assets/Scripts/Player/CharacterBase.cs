using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
	private Animator animator;
	private SpriteRenderer spriteRenderer;

	private void Awake() {
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void PlayMovementAnimation(int runningDirection, bool isDashing) {
		if (runningDirection == 0) {
			animator.SetBool("Running", false);
			return;
		}
		if (runningDirection == 1) {
			animator.SetBool("Running", true);
			spriteRenderer.flipX = false;
		}
		if (runningDirection == -1) {
			animator.SetBool("Running", true);
			spriteRenderer.flipX = true;
		}

		if (isDashing) {
			animator.SetBool("Dashing", true);
		} else {
			animator.SetBool("Dashing", false);
		}
    }
}
