using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
	public GameObject[] bodyPieces;
	public float force;

	private void Start()
	{
		foreach (GameObject g in bodyPieces)
		{
			Rigidbody rb = g.GetComponent<Rigidbody>();
			Vector3 torque = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
			rb.AddForce(transform.up * force, ForceMode.Impulse);
			rb.AddTorque(torque);
		}

		StartCoroutine(Shrink());
	}

	private IEnumerator Shrink()
	{
		yield return new WaitForSeconds(2f);
		float duration = 1f;

		foreach (GameObject g in bodyPieces)
		{
			StartCoroutine(ShrinkPiece(g.transform, duration));
		}

		yield return new WaitForSeconds(duration+1f);
		Destroy(this.gameObject);
	}

	private IEnumerator ShrinkPiece(Transform t, float duration)
	{
		Vector3 originalScale = t.localScale;
		Vector3 targetScale = Vector3.zero;

		float timer = 0f;

		do
		{
			t.localScale = Vector3.Lerp(originalScale, targetScale, timer / duration);
			timer += Time.deltaTime;
			yield return null;
		}
		while (timer <= duration);

		t.localScale = targetScale;
	}
}
