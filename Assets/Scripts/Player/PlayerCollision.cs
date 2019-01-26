﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		print(other.gameObject.tag);

		switch (other.gameObject.tag)
		{
			case "Weapon Pickup":
				WeaponPickup weaponPickup = other.gameObject.GetComponent<WeaponPickup>();
				switch (weaponPickup.type)
				{
					case WeaponType.MachineGun:
						GetComponent<PlayerShoot>().setCurrentWeaponForTime("Machine Gun", 5f);
						break;

					case WeaponType.TripleGun:
						GetComponent<PlayerShoot>().setCurrentWeapon("Triple Gun");
						break;
				}

				Destroy(other.gameObject);
				break;
		}
	}
}
