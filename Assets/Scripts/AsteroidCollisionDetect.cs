using UnityEngine;
using System.Collections;

public class AsteroidCollisionDetect : MonoBehaviour 
{
	public GameObject explosion;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Hit player!");
			gameObject.SetActive (false);
			other.SendMessage("OnDamage", 20);
		}
	}

	public void OnHit()
	{
		GameObject exp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
		gameObject.SetActive (false);
	}
}