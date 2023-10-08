using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
	private Transform aimTransform;
	private Transform gunEndPoint;
	private PistolBase pistolBase;
	[SerializeField] private GameObject bulletPrefab;

	private void Awake() {
		aimTransform = transform.Find("Aim");
		gunEndPoint = transform.Find("Aim").Find("GunEndpoint");
		pistolBase = aimTransform.GetComponentInChildren<PistolBase>();
	}

	private void Update() {
		HandleAiming();
	}

	private void FixedUpdate() {
		HandleShooting();
	}

	private void HandleAiming() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0;

		Vector3 aimDirection = (mousePosition - transform.position).normalized;
		float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
		aimTransform.eulerAngles = new Vector3(0, 0, angle);

		Vector3 aimLocalScale = Vector3.one;
		if ((angle > 90f) || (angle < -90f)) {
			aimLocalScale.y = -1f;
		} else {
			aimLocalScale.y = 1f;
		}
		aimTransform.localScale = aimLocalScale;
	}

	private void HandleShooting() {
		if (Input.GetMouseButtonDown(0)) {
			Instantiate(bulletPrefab, gunEndPoint.position, gunEndPoint.rotation);
			pistolBase.PlayShootingAnimation(true);
		} else {
			pistolBase.PlayShootingAnimation(false);
		}
	}
}
