using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
	public Weapon[] weapons;
	
	public Weapon SwitchWeapon(string weaponName)
	{
		foreach (Weapon w in weapons)
		{
			w.gameObject.SetActive(false);
		}

		foreach (Weapon w in weapons)
		{
			if (w.name.Equals(weaponName))
			{
				w.gameObject.SetActive(true);
				return w;
			}
		}

		print("Could not find weapon: " + weaponName);
		return null;
	}
}
