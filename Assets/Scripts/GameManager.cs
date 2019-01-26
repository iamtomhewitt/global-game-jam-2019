using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		ZombieSpawner.instance.SpawnWave();

		InvokeRepeating("CheckToSpawnNextZombieWave", 2, 2);
	}

	private void CheckToSpawnNextZombieWave()
	{
		if (ZombieSpawner.instance.finishedSpawningWave)
		{
			if (GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
			{
				//print("Spawning a new wave from the Game Manager");
				ZombieSpawner.instance.waveSize += 8;
				ZombieSpawner.instance.spawnRate -= .2f;
				if (ZombieSpawner.instance.spawnRate < 0.75f) ZombieSpawner.instance.spawnRate = 0.75f;
				ZombieSpawner.instance.SpawnWave();
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
