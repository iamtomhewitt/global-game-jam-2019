using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
	public GameObject[] zombies;
	public Transform[] spawnPoints;

	public int waveSize = 5;
	public float spawnRate = 5;

	public bool finishedSpawningWave;

	public static ZombieSpawner instance;

	private void Awake()
	{
		instance = this;
	}

	public void SpawnWave()
	{
		StartCoroutine(WaveSpawn());
	}

	private IEnumerator WaveSpawn()
	{
		finishedSpawningWave = false;
		yield return Intermission();

		for (int i = 0; i < waveSize; i++)
		{
			yield return new WaitForSeconds(spawnRate);
			SpawnZombie();
		}

		finishedSpawningWave = true;
	}

	private IEnumerator Intermission()
	{
		print("Intermission");
		yield return new WaitForSeconds(5f);
		print("Intermission complete");
	}

	private void SpawnZombie()
	{
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		GameObject zombie = zombies[Random.Range(0, zombies.Length)];

		Instantiate(zombie, spawnPoint.position, spawnPoint.rotation);

		UIManager.instance.UpdateZombiesRemainingText();
	}
}
