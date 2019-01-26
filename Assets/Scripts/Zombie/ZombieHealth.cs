using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
	public int health = 100;

	public void DecreaseHealth(int amount)
	{
		health -= amount;

		if (health <= 0)
		{
			print("Zombie is DEAD!");
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "Bullet":
				DecreaseHealth(5);
				break;

			default:
				Debug.LogError("Unrecognised tag: " + other.gameObject.name);
				break;
		}
	}
}
