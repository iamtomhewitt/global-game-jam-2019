using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
	public float health = 100;
	public Image healthBar;

	public GameObject deathEffect;

	public void DecreaseHealth(int amount, bool killedByPlayer)
	{
		health -= amount;

		healthBar.fillAmount = health / 100;

		if (health <= 0)
		{
			Die(killedByPlayer);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "Bullet":
				DecreaseHealth(50, true);
				AudioManager.instance.Play("Zombie Hit");
				break;

			case "Zombie Destination":
				DecreaseHealth(100, false);
				GameObject.FindObjectOfType<HouseHealth>().DecreaseHealth(5);
				break;

			default:
				//Debug.LogWarning("Unrecognised tag: " + other.gameObject.name);
				break;
		}
	}

	private void Die(bool killedByPlayer)
	{
		CameraController.instance.ShakeCamera(.25f, .15f);
		Instantiate(deathEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);

		UIManager.instance.UpdateZombiesRemainingText();

		AudioManager.instance.Play("Zombie Death");

		if (killedByPlayer)
		{
			PlayerScore.instance.AddScore(50);
			PlayerScore.instance.AddZombieKilled();

			UIManager.instance.UpdateScoreText(PlayerScore.instance.GetScore());
			UIManager.instance.UpdateZombiesKilledText(PlayerScore.instance.GetZombiesKilled());
		}
	}
}
