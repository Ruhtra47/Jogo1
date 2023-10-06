using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public int enemyCounter = 0;
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private float minSpawnTime;
	[SerializeField] private float maxSpawnTime;
	[SerializeField] private int maxCounter;
	[SerializeField] private List<Transform> spawns = new List<Transform>();

	private float timeUntilSpawn;
	private int spawnPoint;

	private void Awake() {
		SetNextSpawn();
	}

	private void Update() {
		timeUntilSpawn -= Time.deltaTime;

		if ((timeUntilSpawn <= 0) && (enemyCounter < maxCounter)) {
			Instantiate(enemyPrefab, spawns[spawnPoint].position, Quaternion.identity);
			enemyCounter++;
			SetNextSpawn();
		}
	}

	private void SetNextSpawn() {
		timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
		spawnPoint = Random.Range(0, 3);
	}
}
