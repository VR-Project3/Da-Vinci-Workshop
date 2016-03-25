using UnityEngine;
using System.Collections;

public class RotateWheels : MonoBehaviour {

	public int speed = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		foreach(Transform t in transform)
		{
			foreach(Transform child in t)
			{
				if (child.name == "Gear_1" || child.name == "Gear_2" || child.name == "paddle_1" || child.name == "paddle_2"){
					if (Input.GetKey(KeyCode.W)){
						child.Rotate(Vector3.left * speed * Time.deltaTime);
					}
					if (Input.GetKey(KeyCode.S)){
						child.Rotate(Vector3.left * -speed * Time.deltaTime);
					}
				}
				if (child.name == "Gear_3" || child.name == "Gear_4"){
					if (Input.GetKey(KeyCode.W)){
						child.Rotate(Vector3.left * -speed * Time.deltaTime);
					}
					if (Input.GetKey(KeyCode.S)){
						child.Rotate(Vector3.left * speed * Time.deltaTime);
					}
				}
				if(child.name == "Gear_5"){
					if (Input.GetKey(KeyCode.W)){
						child.Rotate(Vector3.forward * speed * Time.deltaTime);
					}
					if (Input.GetKey(KeyCode.S)){
						child.Rotate(Vector3.forward * -speed * Time.deltaTime);
					}
				}
			}
		}
	}
}
