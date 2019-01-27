using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
	private NavMeshAgent agent;

	private Vector3 destination;

	bool chasePlayer;

	private void Start()
	{
		chasePlayer = (Random.value < 0.3f);
		StartCoroutine(Initialise());
		InvokeRepeating("Groan", 0f, Random.Range(20f, 60f));
	}

	private void Groan()
	{
		int i = Random.Range(1, 4);
		AudioManager.instance.Play("Zombie " + i);
	}

	IEnumerator Initialise()
	{
		float duration = 1f;
		Vector3 targetScale = transform.localScale;
		Vector3 originalScale = Vector3.zero;

		float timer = 0f;

		do
		{
			transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / duration);
			timer += Time.deltaTime;
			yield return null;
		}
		while (timer <= duration);

		transform.localScale = targetScale;

		// For some reason need to do set destination here otherwise it does not work if called in the Start() method.
		agent = GetComponent<NavMeshAgent>();
		destination = chasePlayer ? GameObject.FindGameObjectWithTag("Player").transform.position : GameObject.FindGameObjectWithTag("Zombie Destination").transform.position;
		agent.SetDestination(destination);

		if (chasePlayer)
		{
			InvokeRepeating("UpdateDestination", 0f, 0.5f);
		}
	}

	private void UpdateDestination()
	{
		agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
	}
}
