using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet;

	public Transform spawn;

	public float fireRate;
	public float bulletForce;

	private float cooldown;

	private void Update()
	{
		cooldown -= Time.deltaTime;

		if (Input.GetAxis("RightTrigger") >= 0.95f && cooldown <= 0)
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		cooldown = fireRate;

		GameObject b = Instantiate(bullet, spawn.position, spawn.rotation) as GameObject;
		b.GetComponent<Rigidbody>().AddForce(b.transform.forward * bulletForce, ForceMode.Impulse);
	}
}
