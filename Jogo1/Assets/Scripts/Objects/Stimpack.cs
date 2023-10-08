using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stimpack : MonoBehaviour
{

	[SerializeField] private AudioSource sound;
    private HealthController healthController;

	private void Awake() {
		healthController = GameObject.Find("Player").GetComponent<HealthController>();
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            healthController.AddHealth(1f);
            sound.Play();
        }
    }
}
