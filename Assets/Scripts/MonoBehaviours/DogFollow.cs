using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFollow : MonoBehaviour
{
	public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float gap = 1f;
		float buffer = .2f;
		bool updated = false;
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		Vector3 targetPos = new Vector3();
		if (target.transform.position.x > transform.position.x + gap + buffer ||
			target.transform.position.x < transform.position.x + gap + buffer)
		{
			x = target.transform.position.x - gap;
			updated = true;
		}

		if (target.transform.position.y > transform.position.y + buffer ||
	target.transform.position.y < transform.position.y + buffer)
		{
			y = target.transform.position.y;
			updated = true;
		}

		if (updated)
		{
			transform.position = new Vector3(x,y,z);
		}
    }
}
