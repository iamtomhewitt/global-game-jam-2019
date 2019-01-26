using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
	private int currentScore = 0;
	private int zombiesKilled = 0;

	public static PlayerScore instance;

	private void Awake()
	{
		instance = this;
	}

	public void AddScore(int amount)
	{
		currentScore += amount;
	}

	public int GetScore()
	{
		return currentScore;
	}

	public void AddZombieKilled()
	{
		zombiesKilled++;

		if (zombiesKilled % 35 == 0)
			WeaponSpawner.instance.SpawnWeapon();
	}

	public int GetZombiesKilled()
	{
		return zombiesKilled;
	}
}
