using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class ShipController : MonoBehaviour 
{
	private float translation;
	private float sideways;
	private float roll;
	private float pitch;
	private float yaw;
	public float speed;
	public float speedX;
	public float speedY;
	public float rotationSpeed;

	public Boundary boundary;

	public ArcReactor_Arc laser;
	public ArcReactor_Arc secLaser;

	public bool is3D;
	public bool is2D;

	void Awake()
	{
		laser = GameObject.FindGameObjectWithTag ("Laser").GetComponent<ArcReactor_Arc> ();
		secLaser = GameObject.FindGameObjectWithTag ("SecondaryLaser").GetComponent<ArcReactor_Arc> ();
	}

	void Start()
	{
		speed = 0.0f;
		rotationSpeed = 100.0f;
		is3D = false;
		is2D = true;
	}

	void Update()
	{
		if (is3D) {
			translation = speed * Time.deltaTime;
			roll = Input.GetAxis ("Vertical") * rotationSpeed * Time.deltaTime;
			yaw = Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
		
			if (Input.GetKey (KeyCode.Space)) {
				if (speed <= 10.0f) {
					speed += 1.0f * Time.deltaTime;
				}
			} else if (!Input.GetKeyDown (KeyCode.Space)) {
				if (speed >= 0.0f) {
					speed -= 1.0f * Time.deltaTime;
				}
			}
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				// Hit the brakes, son!
				speed = 0.0f;
			}
		}

		if (is2D) {
			translation = speedY * Time.deltaTime;
			sideways = speedX * Time.deltaTime;

			if (Input.GetKey (KeyCode.W)) {
				if (speed <= 10.0f) {
					speedY += 10.0f * Time.deltaTime;
				}
				if (transform.position.z < boundary.zMin) {
					speedY = 0.0f;
					Debug.Log ("Z Min Boundary Reached.");
				}
			}
			
			if (Input.GetKey (KeyCode.S)) {
				if (speed >= 0.0f) {
					speedY -= 10.0f * Time.deltaTime;
				}
			}

			if (Input.GetKey (KeyCode.A)) {
				if (speed <= 10.0f) {
					speedX += 10.0f * Time.deltaTime;
				}
			}

			if (Input.GetKey (KeyCode.D)) {
				if (speed >= 0.0f) {
					speedX -= 10.0f * Time.deltaTime;
				}
			}

			transform.Translate (sideways, translation, 0);
		}

		if (Input.GetKey(KeyCode.Mouse0)) {
			laser.freeze = false;

			if(laser.elapsedTime >= 0.3) {
				laser.elapsedTime = 0;
			}
		}
		if (Input.GetKey(KeyCode.Mouse1)) {
			secLaser.freeze = false;
			
			if(secLaser.elapsedTime >= 2) {
				secLaser.elapsedTime = 0;
			}
		}
	}
}