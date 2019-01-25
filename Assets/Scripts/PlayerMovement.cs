using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;

	public KeyCode forwardKey, leftKey, rightKey, backwardKey;

	private void FixedUpdate()
	{
		if (Input.GetKey(forwardKey))
		{
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(backwardKey))
		{
			transform.position -= transform.forward * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(leftKey))
		{
			transform.position -= transform.right * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(rightKey))
		{
			transform.position += transform.right * moveSpeed * Time.deltaTime;
		}
	}
}
