using UnityEngine;
using System.Collections;

public class AsteroidDisableSelf : MonoBehaviour 
{
	void OnEnable()
	{
		Invoke ("Destroy", 7f);
	}

	public void Destroy()
	{
		gameObject.SetActive (false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}
}