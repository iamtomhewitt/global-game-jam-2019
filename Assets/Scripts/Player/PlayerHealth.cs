using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public float health = 100;
	public Image healthBar;

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
		print("YOU is DEAD!");
		CameraController.instance.ShakeCamera(.25f, .15f);
		Destroy(this.gameObject);
	}
}
