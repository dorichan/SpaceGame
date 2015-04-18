using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public int maxHealth;
	public int currentHealth;

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
}