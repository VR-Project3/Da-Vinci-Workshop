using UnityEngine;
using System.Collections;

public class FlightController : MonoBehaviour 
{

	public float speed = 200f;
	public float accel = 10f;
	float rotationInt = 30f;
	private bool land = false;
	private float minSpeed = 100f;
	private float maxSpeed = 300f;

	public GameObject horse;

	void Start () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "fence") 
		{
			land = true;
		}

		if (other.tag == "ground") {
			speed = 0f;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
		}

		if (other.tag == "startHorse") {
			horse.GetComponent<SplineController>().FollowSpline ();
		}
	}
		
	// Update is called once per frame
	void Update () 
	{
		
		float rotat = rotationInt * Time.deltaTime;


		if (land) {
			transform.rotation = Quaternion.Euler (0, -90, 0);

			if (speed > 0f) { 
				speed -= .8f * accel;
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
			}
			if (transform.position.y > 30f) {
				transform.Translate (Vector3.down * 80f * Time.deltaTime);
				speed += accel;
			}else {
				Application.LoadLevel("workshop 1");
			}

		} else {
			
			transform.Rotate (rotat*Input.GetAxis ("PullUp"), 0, 0);
			transform.Rotate (0, rotat*Input.GetAxis ("Turn"), 0);

			if (Input.GetButton ("LeftTrigger")) {
				if (transform.eulerAngles.z > 45f) {
					transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 45);
				}else {
					transform.Rotate (0, 0, rotat);
				}
			}

			if (Input.GetButton ("RightTrigger")) {
				if (transform.eulerAngles.z < -45f) {
					transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -45);
				} else {
					transform.Rotate (0, 0, -rotat);
				}
			}

			if (Input.GetButton ("Fire1"))
			{
				Application.LoadLevel("workshop 1");
			}


			speed += accel * Input.GetAxis ("Vertical");

			if (speed > maxSpeed) {
				speed = maxSpeed;
			} else if (speed < minSpeed) {
				speed = minSpeed;
			}

			transform.Translate (Vector3.right * speed * Time.deltaTime);
			transform.Translate (Vector3.left * speed * Time.deltaTime);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
	}

}
