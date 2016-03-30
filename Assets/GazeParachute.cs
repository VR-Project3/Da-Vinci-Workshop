using UnityEngine;
using System.Collections;

public class GazeParachute : MonoBehaviour {

	bool isAnimating;

	SplineController tankSpline;
	public GameObject Parachute;
	private bool didRecordTimes = false;
	private float startTime;

	// Use this for initialization
	void Start () {
		isAnimating = false;
	}

	void Update(){

		if(isAnimating){

			if((startTime + 11.0f) < Time.time){
				foreach (Renderer r in Parachute.GetComponentsInChildren<Renderer>()){
					r.enabled = false;
				}
			}

			if((startTime + 14.0f) < Time.time){
				isAnimating = false;
			}
		}
	}

	// Update is called once per frame
	public void stareAtParachutePaper() {

		print ("test");
		if(!isAnimating){
			isAnimating = true;
			foreach (Renderer r in Parachute.GetComponentsInChildren<Renderer>()){
				r.enabled = true;
			}
			Parachute.GetComponent<SplineController>().FollowSpline ();

			startTime = Time.time;
		}
	}
}
