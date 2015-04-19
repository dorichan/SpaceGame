using UnityEngine;
using System.Collections;

public class AsteroidBehavior : MonoBehaviour 
{
	public float speed = 1.0f;
	public float rotationSpeed = 2.0f;
	public Vector3 randDir;
	public int num;

	void OnEnable()
	{
		Invoke ("GetRandomDirection", 0.1f);
	}

	void Update()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		transform.Rotate (randDir * rotationSpeed * Time.deltaTime, Space.World);
	}

	Vector3 GetRandomDirection()
	{
		num = Random.Range (-1, 2);

		if (num > 0) {
			randDir = Vector3.up;
		} else if (num < 0) {
			randDir = -Vector3.up;
		} else {
			randDir = Vector3.zero;
		}

		return randDir;
	}
}