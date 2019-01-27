using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI zombiesKilledText;
	public TextMeshProUGUI zombiesRemainingText;
	public TextMeshProUGUI weaponNameText;
	public TextMeshProUGUI weaponAmmoText;
	public TextMeshProUGUI gameOverText;

	public static UIManager instance;

	public Animator animator;
	public AnimationClip underAttack;
	public AnimationClip gameOver;

	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
		UpdateZombiesRemainingText();
	}

	public void UpdateScoreText(int score)
	{
		scoreText.SetText("SCORE: " + score);
	}

	public void UpdateZombiesKilledText(int zombiesKilled)
	{
		zombiesKilledText.SetText("KILLED: " + zombiesKilled);
	}

	public void UpdateZombiesRemainingText()
	{
		int remaining = GameObject.FindGameObjectsWithTag("Zombie").Length;
		zombiesRemainingText.SetText("REMAINING: " + remaining);
	}

	public void UpdateWeaponNameText(string weaponName)
	{
		weaponNameText.SetText(weaponName.ToUpper());
	}

	public void UpdateWeaponAmmoText(int ammo)
	{
		weaponAmmoText.SetText(""+ammo);
	}

	public void ShowHouseUnderAttack()
	{
		animator.Play(underAttack.name, -1, 0f);
	}

	public void ShowGameOver(string reason)
	{
		gameOverText.SetText(reason);
		animator.Play(gameOver.name, -1, 0f);
	}
}
