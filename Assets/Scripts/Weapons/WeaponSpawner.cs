using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
	public GameObject[] weaponPickups;
	public Transform[] spawns;

	public static WeaponSpawner instance;

	private void Awake()
	{
		instance = this;
	}

	public void SpawnWeapon()
	{
		GameObject w = weaponPickups[Random.Range(0, weaponPickups.Length)];
		Transform s = spawns[Random.Range(0, spawns.Length)];

		Instantiate(w, s.position, s.rotation, this.transform);

		AudioManager.instance.Play("Weapon Pickup Spawn");
	}
}
