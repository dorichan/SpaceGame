using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour 
{
	public GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		if (gameObject.transform.name == "zMax" || gameObject.transform.name == "zMin") {

		}

		if (gameObject.transform.name == "xMax" || gameObject.transform.name == "xMin") {

		}
	}
}