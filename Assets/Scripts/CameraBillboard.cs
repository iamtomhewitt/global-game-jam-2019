using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBillboard : MonoBehaviour
{
	public Vector3 rotation = new Vector3(0f, 45f, 0f);

	private void Update()
	{
		transform.rotation = Quaternion.Euler(rotation);
	}
}
