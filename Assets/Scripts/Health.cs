using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public int maxHealth;
	public int currentHealth;

	public GameObject explosion;

	void Start()
	{
		maxHealth = 100;
		currentHealth = maxHealth;
	}

	void OnDamage(int _damage)
	{
		currentHealth -= _damage;
	}

	void GainHealth(int _health)
	{
		currentHealth += _health;
	}

	void Update()
	{
		if (currentHealth <= 0) {
			GameObject exp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
			Destroy(gameObject);
		}
	}
}