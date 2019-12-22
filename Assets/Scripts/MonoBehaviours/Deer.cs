using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
	public float speed = 20.0f;
	private Rigidbody2D rb2D;
	public Vector2 velocity;

	// Use this for initialization
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		Destroy(this.gameObject, 3);
	}

	// Update is called once per frame
	void Update()
	{

		rb2D.velocity = velocity;
	}
}
