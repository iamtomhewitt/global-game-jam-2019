using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
	public float bodyRotationSpeed;
	public float legsRotationSpeed;
	public float bodyRotationOffset;
	public float legsRotationOffset;

	private Vector3 isometricForward = new Vector3(1f, 0f, 1f);
	private Vector3 isometricRight = new Vector3(1f, 0f, -1f);

	public Transform body;
	public Transform legs;

	private string leftStickHorizontal = "Horizontal";
	private string leftStickVertical = "Vertical";
	private string rightStickHorizontal = "HorizontalRightStick";
	private string rightStickVertical = "VerticalRightStick";

	private void FixedUpdate()
	{
		transform.position += isometricForward * Time.deltaTime * moveSpeed * Input.GetAxis(leftStickVertical);
		transform.position += isometricRight * Time.deltaTime * moveSpeed * Input.GetAxis(leftStickHorizontal);

		if (IsRightJoystickInput())
		{
			float angle = (Mathf.Atan2(-Input.GetAxis(rightStickHorizontal), -Input.GetAxis(rightStickVertical)) * Mathf.Rad2Deg) + bodyRotationOffset;
			body.rotation = Quaternion.Slerp(body.rotation, Quaternion.Euler(new Vector3(0f, -angle, 0)), bodyRotationSpeed * Time.deltaTime);
		}

		if (IsLeftJoystickInput())
		{
			float angle = (Mathf.Atan2(-Input.GetAxis(leftStickHorizontal), Input.GetAxis(leftStickVertical)) * Mathf.Rad2Deg) + legsRotationOffset;
			legs.rotation = Quaternion.Slerp(legs.rotation, Quaternion.Euler(new Vector3(0f, -angle, 0)), legsRotationSpeed * Time.deltaTime);
		}
	}

	private bool IsLeftJoystickInput()
	{
		return (Input.GetAxis(leftStickVertical) == 0 && Input.GetAxis(leftStickHorizontal) == 0) ? false : true;
	}

	private bool IsRightJoystickInput()
	{
		return (Input.GetAxis(rightStickVertical) == 0 && Input.GetAxis(rightStickHorizontal) == 0) ? false : true;
	}
}
