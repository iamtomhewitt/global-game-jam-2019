using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	ZombieSpawner zombieSpawner;

	public static GameManager instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		zombieSpawner = GameObject.FindObjectOfType<ZombieSpawner>();
		zombieSpawner.SpawnWave();

		InvokeRepeating("CheckToSpawnNextZombieWave", 2, 2);
	}

	private void CheckToSpawnNextZombieWave()
	{
		if (zombieSpawner.finishedSpawningWave)
		{
			if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
			{
				//print("Spawning a new wave from the Game Manager");
				zombieSpawner.waveSize += 1;
				zombieSpawner.spawnRate -= .15f;
				zombieSpawner.SpawnWave();
			}
			//else
				//print("Cannot start the next wave as there are still zombies alive!");
		}
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene("Main Menu");
	}

	public void GameOver()
	{
		UIManager.instance.ShowGameOver();
		ZombieSpawner.instance.StopAllCoroutines();

		CancelInvoke("CheckToSpawnNextZombieWave");

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Zombie"))
		{
			g.GetComponent<ZombieHealth>().DecreaseHealth(100, false);
		}

	}
}
