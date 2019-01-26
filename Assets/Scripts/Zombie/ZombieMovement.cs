using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
	private NavMeshAgent agent;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(GameObject.FindGameObjectWithTag("Zombie Destination").transform.position);
	}
}
