using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
	public GameObject[] zombies;
	public Transform[] spawnPoints;

	public float spawnRate;

	private void Start()
	{
		InvokeRepeating("SpawnZombie", 3, spawnRate);
	}

	private void SpawnZombie()
	{
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		GameObject zombie = zombies[Random.Range(0, zombies.Length)];

		Instantiate(zombie, spawnPoint.position, spawnPoint.rotation);
	}
}
