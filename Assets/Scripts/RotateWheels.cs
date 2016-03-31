using UnityEngine;
using System.Collections;

public class RotateWheels : MonoBehaviour {

	public float speed = 0f;
	public float maxSpeed = 5.0f;
	public float maxSpeedReverse = -5.0f;
	public float accel = .05f;
	public float slowDown = .0075f;
	float rotationSpeed;
	public float trunSpeed = 0f;

	public bool shouldLeave = false;

	public AudioSource paddling;

	public GameObject rotor;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (speed > 0 && speed + -1 * speed * slowDown < 0.04) {
			speed = 0;
		} else if (speed < 0 && speed + -1 * speed * slowDown > -0.04) {
			speed = 0;
		} else {
			speed += -1 * speed * slowDown;
		}

		//		if (Input.GetKey(KeyCode.W)) {
		//			speed += accel;
		//		} else if(Input.GetKey(KeyCode.S)){
		//			speed -= accel;
		//		}

		speed += (accel * Input.GetAxis ("Vertical"));

		paddling.volume = 0.5f * (Mathf.Abs(speed) / 5f);

		if (speed > maxSpeed) {
			speed = maxSpeed;
		} else if (speed < maxSpeedReverse) {
			speed = maxSpeedReverse;
		}

		rotationSpeed = speed * 2;

		foreach(Transform t in transform)
		{   
			foreach(Transform child in t)
			{
				if (child.name == "Gear_1" || child.name == "Gear_2" || child.name == "paddle_1" || child.name == "paddle_2"){
					child.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
				}
				if (child.name == "Gear_3" || child.name == "Gear_4"){
					child.Rotate(Vector3.right * -rotationSpeed * Time.deltaTime);
				}
				if(child.name == "Gear_5"){
					child.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
				}
			}
		}

		//		if (Input.GetKey (KeyCode.A)) {
		//			trunSpeed = -2f;
		//		} else if (Input.GetKey (KeyCode.D)) {
		//			trunSpeed = 2f;
		//		}

		trunSpeed = (2 * Input.GetAxis ("Horizontal"));

		transform.Rotate(Vector3.up*trunSpeed*speed*Time.deltaTime);
//		print (transform.eulerAngles.y);
//		rotor.transform.Rotate(Vector3.up*trunSpeed*speed*Time.deltaTime);
		rotor.transform.rotation = Quaternion.AngleAxis(180 + (Input.GetAxis ("Horizontal") * -40) + transform.eulerAngles.y, Vector3.up);
		transform.Translate(Vector3.forward*speed*Time.deltaTime);

		if (Input.GetButton ("Fire1") || shouldLeave)
		{
			Application.LoadLevel("workshop 1");
		}
	}

	void OnTriggerEnter(Collider other){
		print ("exit");
		if (other.tag == "Exit") {
			shouldLeave = true;
		}
	}
}