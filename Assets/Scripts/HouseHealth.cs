using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseHealth : MonoBehaviour
{
	public float health = 100;
	public Image healthBar;

	public void DecreaseHealth(int amount)
	{
		health -= amount;

		healthBar.fillAmount = health / 100;

		UIManager.instance.ShowHouseUnderAttack();

		if (health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		print("GAME OVER!");
	}
}
