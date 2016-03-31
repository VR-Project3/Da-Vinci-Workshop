using UnityEngine;
using System.Collections;

public class GazePaddleBoat : MonoBehaviour {
	
	bool isLooking;


	// Use this for initialization
	void Start () {
		isLooking = false;
	}

	void Update(){

		if(isLooking){
			if(Input.GetButton("Fire1")){
				Application.LoadLevel("PaddleBoat");
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
