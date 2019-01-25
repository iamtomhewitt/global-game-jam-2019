using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
		Destroy(this.gameObject, 5f);
    }

	private void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject);
	}
}
