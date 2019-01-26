using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet;
	public GameObject shotgunShell;

	public Transform spawn;
	public Transform shotgunShellSpawn;

	public float fireRate;
	public float bulletForce;
	public float shotgunShellForce;
	public float recoil;

	private float cooldown;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

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

		GameObject s = Instantiate(shotgunShell, shotgunShellSpawn.position, shotgunShellSpawn.rotation) as GameObject;
		s.GetComponent<Rigidbody>().AddForce(s.transform.right * shotgunShellForce, ForceMode.Impulse);
		s.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * Random.Range(0, shotgunShellForce*2));
		Destroy(s.gameObject, 5f);

		rb.AddForce(-transform.forward * recoil, ForceMode.Impulse);
	}
}
