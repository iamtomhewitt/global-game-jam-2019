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

	public static UIManager instance;

	private void Awake()
	{
		instance = this;
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

	private void Update()
	{
		UpdateZombiesRemainingText();
	}
}
