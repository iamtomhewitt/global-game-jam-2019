using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
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
			case "Zombie":
				DecreaseHealth(10);
				break;

			default:
				Debug.LogWarning("Unrecognised tag on object: " + other.gameObject.name);
				break;
		}
	}

	private void Die()
	{
		CameraController.instance.ShakeCamera(.25f, .15f);
		Instantiate(deathEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);
		GameManager.instance.GameOver("GAME OVER! YOU DIED!");
	}
}
