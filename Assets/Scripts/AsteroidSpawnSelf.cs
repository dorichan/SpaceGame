using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawnSelf : MonoBehaviour 
{
	public float spawnTime;
	public GameObject asteroid;
	public int maxAsteroids;

	public List<GameObject> asteroids;

	void Start()
	{
		spawnTime = 2.0f;
		maxAsteroids = 10;

		// Create pooled objects
		asteroids = new List<GameObject> ();
		for (int i = 0; i < maxAsteroids; i++) {
			GameObject obj = (GameObject)Instantiate(asteroid);
			obj.SetActive(false);
			asteroids.Add(obj);
		}

		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn()
	{
		for (int i = 0; i < asteroids.Count; i++) {
			if(!asteroids[i].activeInHierarchy) {
				asteroids[i].transform.position = transform.position;
				asteroids[i].transform.rotation = transform.rotation;
				asteroids[i].SetActive(true);
				break;
			}
		}
	}
}