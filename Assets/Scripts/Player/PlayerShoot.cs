using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet;
	public GameObject shotgunShell;
	public GameObject muzzleFlash;

	public Transform spawn;
	public Transform shotgunShellSpawn;

	public float fireRate;
	public float bulletForce;
	public float shotgunShellForce;
	public float recoil;

	public string startingWeapon;

	private float cooldown;

	private Rigidbody rb;

	private Weapon currentWeapon;

	private void Start()
	{
		muzzleFlash.SetActive(false);
		setCurrentWeapon(startingWeapon);
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		cooldown -= Time.deltaTime;

		if (Input.GetAxis("RightTrigger") >= 0.95f && currentWeapon.GetCooldown() <= 0)
		{
			currentWeapon.Shoot();
			rb.AddForce(-transform.forward * currentWeapon.recoil, ForceMode.Impulse);
		}
	}

	public void setCurrentWeapon(string weaponName)
	{
		currentWeapon = GetComponent<PlayerWeaponManager>().SwitchWeapon(weaponName);
	}

	public void setCurrentWeaponForTime(string weaponName, float duration)
	{
		print("Stopping coroutine");
		StopCoroutine("setCurrentWeaponForDuration");
		print("starting new coroutine ");
		StartCoroutine(setCurrentWeaponForDuration(weaponName, duration));
	}

	private IEnumerator setCurrentWeaponForDuration(string weaponName, float duration)
	{
		setCurrentWeapon(weaponName);
		yield return new WaitForSeconds(duration);
		setCurrentWeapon(startingWeapon);
	}
}
