using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
	public WeaponType type;
	public Vector3 rotationSpeed;

	private void Update()
	{
		transform.Rotate(rotationSpeed * Time.deltaTime);
	}
}

public enum WeaponType
{
	Shotgun, MachineGun, TripleGun
};
