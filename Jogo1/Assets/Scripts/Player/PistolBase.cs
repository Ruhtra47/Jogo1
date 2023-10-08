using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBase : MonoBehaviour
{
	private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

	public void PlayShootingAnimation(bool isShooting) {
		if (isShooting) {
			animator.SetBool("Shooting", true);
		} else {
			animator.SetBool("Shooting", false);
		}
	}
}
