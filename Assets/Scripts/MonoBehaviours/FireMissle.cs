using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissle : MonoBehaviour
{
	public Animator anim;
	private bool isTriggered = false;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		print("FireMissle COLLISION: " + collision.name + " " + collision.gameObject.CompareTag("Player"));
		if (collision.gameObject.CompareTag("Player") && !isTriggered)
		{
			isTriggered = true;
			StartCoroutine(PerformAnimRoutine());
		}
		if (collision.gameObject.CompareTag("Deer") && !isTriggered)
		{
			isTriggered = true;
			gameObject.SetActive(false);
			Destroy(this.gameObject, 1);
		}

	}

	private IEnumerator PerformAnimRoutine()
	{
		anim.SetInteger("AnimationState", 0);

		yield return new WaitForSeconds(2);

		gameObject.SetActive(false);
		Destroy(this.gameObject, 2);
	}
}
