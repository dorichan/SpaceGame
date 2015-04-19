using UnityEngine;
using System.Collections;

public class RandomizePosition : MonoBehaviour 
{
	public float currentX;
	public float moveTime;
	
	void Start()
	{
		currentX = gameObject.transform.position.x;
		moveTime = 0.0f;
	}
	
	void Update()
	{
		moveTime += 1.0f * Time.deltaTime;
		
		if(moveTime >= 2.5f) {
			Move ();
			moveTime = 0.0f;
		}
	}
	
	void Move()
	{
		currentX = Random.Range (-8, 8);
		transform.position = new Vector3 (currentX, 0, -15);
	}
}