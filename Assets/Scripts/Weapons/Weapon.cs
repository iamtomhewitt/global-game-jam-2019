using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public string weaponName;

	public GameObject bullet;
	public GameObject shell;
	public GameObject muzzleFlash;

	public Transform[] bulletSpawns;
	public Transform shellSpawn;

	public float fireRate;
	public float bulletForce;
	public float shellForce;
	public float recoil;
	public float cameraShakeIntensity, cameraShakeDuration;

	public int ammo;

	private float cooldown;

	public void Start()
	{
		cooldown = fireRate;
	}

	public void Shoot()
	{
		if (cooldown <= 0f && ammo > 0)
		{
			StartCoroutine(MuzzleFlash());
			cooldown = fireRate;

			foreach (Transform spawn in bulletSpawns)
			{
				GameObject b = Instantiate(bullet, spawn.position, spawn.rotation) as GameObject;
				b.GetComponent<Rigidbody>().AddForce(b.transform.forward * bulletForce, ForceMode.Impulse);
				ammo--;
				UIManager.instance.UpdateWeaponAmmoText(ammo);
			}

			GameObject s = Instantiate(shell, shellSpawn.position, shellSpawn.rotation) as GameObject;
			s.GetComponent<Rigidbody>().AddForce(s.transform.right * shellForce, ForceMode.Impulse);
			s.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * Random.Range(0, shellForce * 2));
			Destroy(s.gameObject, 5f);

			CameraController.instance.ShakeCamera(cameraShakeDuration, cameraShakeIntensity);
		}
	}

	private IEnumerator MuzzleFlash()
	{
		muzzleFlash.SetActive(true);
		yield return new WaitForSeconds(.05f);
		muzzleFlash.SetActive(false);
	}

	private void Update()
	{
		cooldown -= Time.deltaTime;
	}

	public float GetCooldown()
	{
		return cooldown;
	}
}
