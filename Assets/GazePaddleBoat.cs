using UnityEngine;
using System.Collections;

public class GazePaddleBoat : MonoBehaviour {
	
	bool isLooking;

	public GameObject player;

	// Use this for initialization
	void Start () {
		isLooking = false;
	}

	void Update(){

		float distance = Vector3.Distance (transform.position, player.transform.position);
		if (distance < 7.0f) {
			if (isLooking) {
				if (Input.GetButton ("AButton") || Input.GetButton ("Fire1")) {
					Application.LoadLevel ("PaddleBoat");
				}
			}
		}
	}

	// Update is called once per frame
	public void startStareAtPaddleBoatPaper() {
		isLooking = true;
	}

	public void stopStareAtPaddleBoatPaper() {

		isLooking = false;
	}
}
