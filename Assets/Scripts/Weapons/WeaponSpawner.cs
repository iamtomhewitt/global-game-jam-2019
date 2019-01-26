using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
	public GameObject[] weaponPickups;
	public Transform[] spawns;

	public float spawnTime;

	private void Start()
	{
		InvokeRepeating("SpawnWeapon", spawnTime, spawnTime);
	}

	private void SpawnWeapon()
	{
		GameObject w = weaponPickups[Random.Range(0, weaponPickups.Length)];
		Transform s = spawns[Random.Range(0, spawns.Length)];

		Instantiate(w, s.position, s.rotation, this.transform);
	}
}
