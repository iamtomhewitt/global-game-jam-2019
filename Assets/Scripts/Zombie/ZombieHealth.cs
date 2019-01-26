using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
	public float health = 100;
	public Image healthBar;

	public GameObject deathEffect;

	public void DecreaseHealth(int amount)
	{
		health -= amount;

		healthBar.fillAmount = health / 100;

		if (health <= 0)
		{
			Die();
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "Bullet":
				DecreaseHealth(50);
				break;

			case "Zombie Destination":
				DecreaseHealth(100);
				other.gameObject.GetComponent<HouseHealth>().DecreaseHealth(5);
				break;

			default:
				Debug.LogWarning("Unrecognised tag: " + other.gameObject.name);
				break;
		}
	}

	private void Die()
	{
		print("Zombie is DEAD!");
		CameraController.instance.ShakeCamera(.25f, .15f);
		Instantiate(deathEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
}
