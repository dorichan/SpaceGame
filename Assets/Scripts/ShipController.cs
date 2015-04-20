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

	public AudioClip laserSound;
	public AudioClip secLaserSound;

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
		// BOSS FIGHT / FREE FLIGHT MODE SECTION
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

		// TOP DOWN SECTION
		if (is2D) {
			translation = speedY * Time.deltaTime;
			sideways = speedX * Time.deltaTime;
			
			if (Input.GetKey (KeyCode.W)) {
				if (speed <= 10.0f) {
					speedY += 10.0f * Time.deltaTime;
				}
			}
			
			if (Input.GetKey (KeyCode.S)) {
				if (speed >= 0.0f) {
					speedY -= 10.0f * Time.deltaTime;
				}
			}

			if (Input.GetKey (KeyCode.A) || Input.acceleration.x > 0) {
				if (speed <= 10.0f) {
					speedX += 10.0f * Time.deltaTime;
				}
			}

			if (Input.GetKey (KeyCode.D) || Input.acceleration.x < 0) {
				if (speed >= 0.0f) {
					speedX -= 10.0f * Time.deltaTime;
				}
			}

			transform.Translate (sideways, translation, 0);
		}

		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			laser.freeze = false;
			audio.Play(laserSound);

			if(laser.elapsedTime >= 0.3) {
				laser.elapsedTime = 0;
			}

			RaycastHit hit;
			if(Physics.Raycast(transform.position, -Vector3.forward, out hit, 100.0f)) {
				hit.transform.gameObject.SendMessage("OnHit");
			}
		}
		if (Input.GetKeyDown(KeyCode.Mouse1)) {
			secLaser.freeze = false;
			audio.Play (secLaserSound);
			
			if(secLaser.elapsedTime >= 2) {
				secLaser.elapsedTime = 0;
			}

			RaycastHit hit;
			if(Physics.Raycast(transform.position, -Vector3.forward, out hit, 100.0f)) {
				hit.transform.gameObject.SendMessage("OnHit");
			}
		}
	}

	void LateUpdate()
	{
		// BOUNDARY SECTION
		if (transform.position.z > boundary.zMin) {
			SetNewPosition(1);
		}
		if (transform.position.z < boundary.zMax) {
			SetNewPosition(2);
		}
		if (transform.position.x > boundary.xMin) {
			SetNewPosition(3);
		}
		if (transform.position.x < boundary.xMax) {
			SetNewPosition(4);
		}
	}

	// Function to set a new position once the player goes over the screen boundary
	void SetNewPosition(int _args)
	{
		if (_args == 1) {
			transform.position = GameObject.FindGameObjectWithTag ("zMax").transform.position;
		}
		if (_args == 2) {
			transform.position = GameObject.FindGameObjectWithTag ("zMin").transform.position;
		}
		if (_args == 3) {
			transform.position = GameObject.FindGameObjectWithTag ("xMin").transform.position;
		}
		if (_args == 4) {
			transform.position = GameObject.FindGameObjectWithTag ("xMax").transform.position;
		}
	}
}