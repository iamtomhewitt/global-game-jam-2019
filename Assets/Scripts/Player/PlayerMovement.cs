using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
	public float rotationSpeed;
	public float rotationOffset;

	public Vector3 isometricForward = new Vector3(1f, 0f, 1f);
	public Vector3 isometricRight = new Vector3(1f, 0f, -1f);

	private string leftStickHorizontal = "Horizontal";
	private string leftStickVertical = "Vertical";
	private string rightStickHorizontal = "HorizontalRightStick";
	private string rightStickVertical = "VerticalRightStick";

	private PlayerAnimationController animationController;

	private void Start()
	{
		animationController = GetComponent<PlayerAnimationController>();
	}

	private void FixedUpdate()
	{
		if (!IsLeftJoystickInput())
		{
			animationController.ChangeAnimation(PlayerAnimationController.ANIMATION_IDLE);
		}
		else
		{
			transform.position += isometricForward * Time.deltaTime * moveSpeed * Input.GetAxis(leftStickHorizontal);
			transform.position += isometricRight * Time.deltaTime * moveSpeed * Input.GetAxis(leftStickVertical);
			animationController.ChangeAnimation(PlayerAnimationController.ANIMATION_RUN);
		}

		if (IsRightJoystickInput())
		{
			float angle = (Mathf.Atan2(Input.GetAxis(rightStickHorizontal), Input.GetAxis(rightStickVertical)) * Mathf.Rad2Deg) + rotationOffset;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0f, -angle, 0)), rotationSpeed * Time.deltaTime);
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
