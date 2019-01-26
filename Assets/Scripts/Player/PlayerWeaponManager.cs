using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
	public Weapon[] weapons;
	private int index = 0;

	public static PlayerWeaponManager instance;

	private void Awake()
	{
		instance = this;
	}

	public Weapon SwitchToSpecificWeapon(string weaponName)
	{
		TurnOffAllWeapons();
		Weapon w = FindWeapon(weaponName);
		if (w != null)
		{
			w.gameObject.SetActive(true);
			return w;
		}
		return null;
	}

	public Weapon SwitchToNextWeapon()
	{
		TurnOffAllWeapons();

		index = (index++ >= weapons.Length - 1) ? 0 : index;

		foreach (Weapon w in weapons)
		{
			if (w == weapons[index])
			{
				w.gameObject.SetActive(true);
				UIManager.instance.UpdateWeaponNameText(w.weaponName);
				UIManager.instance.UpdateWeaponAmmoText(w.ammo);
				return w;
			}
		}

		return null;
	}

	public Weapon FindWeapon(string weaponName)
	{
		foreach (Weapon w in weapons)
		{
			if (w.name.Equals(weaponName))
			{
				return w;
			}
		}

		print("Could not find weapon: " + weaponName);
		return null;
	}

	private void TurnOffAllWeapons()
	{
		foreach (Weapon w in weapons)
		{
			w.gameObject.SetActive(false);
		}
	}
}
