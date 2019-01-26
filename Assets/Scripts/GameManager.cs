using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	ZombieSpawner zombieSpawner;

	private void Start()
	{
		zombieSpawner = GameObject.FindObjectOfType<ZombieSpawner>();

		zombieSpawner.SpawnWave();

		InvokeRepeating("CheckToSpawnNextZombieWave", 2, 2);
	}

	void CheckToSpawnNextZombieWave()
	{
		if (zombieSpawner.finishedSpawningWave)
		{
			if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
			{
				//print("Spawning a new wave from the Game Manager");
				zombieSpawner.waveSize += 3;
				zombieSpawner.spawnRate -= .25f;
				zombieSpawner.SpawnWave();
			}
			//else
				//print("Cannot start the next wave as there are still zombies alive!");
		}
	}
}
