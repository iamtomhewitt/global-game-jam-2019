using System.Collections;
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
						PlayerWeaponManager.instance.FindWeapon("Machine Gun").ammo += 75;
						UIManager.instance.UpdateWeaponAmmoText(PlayerWeaponManager.instance.FindWeapon("Machine Gun").ammo);
						break;

					case WeaponType.TripleGun:
						PlayerWeaponManager.instance.FindWeapon("Triple Gun").ammo += 90;
						UIManager.instance.UpdateWeaponAmmoText(PlayerWeaponManager.instance.FindWeapon("Triple Gun").ammo);
						break;
				}

				AudioManager.instance.Play("Weapon Pikup Collected");

				Destroy(other.gameObject);
				break;
		}
	}
}
