using UnityEngine;
using System.Collections;

public class GazeParachute : MonoBehaviour {

	bool isAnimating;
	bool start = false;
	bool looking = false;

	SplineController tankSpline;
	public GameObject Parachute;
	private bool didRecordTimes = false;
	private float startTime;

	public GameObject player;

	// Use this for initialization
	void Start () {
		isAnimating = false;
	}

	void Update(){

		float distance = Vector3.Distance (transform.position, player.transform.position);
		if(looking && distance < 5.0f){
			isAnimating = true;

			if(!start){
				foreach (Renderer r in Parachute.GetComponentsInChildren<Renderer>()){
					r.enabled = true;
				}
				Parachute.GetComponent<SplineController>().FollowSpline ();

				startTime = Time.time;
				start = true;
			}
		}

		if(isAnimating){

			if((startTime + 11.0f) < Time.time){
				foreach (Renderer r in Parachute.GetComponentsInChildren<Renderer>()){
					r.enabled = false;
				}
			}

			if((startTime + 14.0f) < Time.time){
				isAnimating = false;
				start = false;
			}
		}
	}

	// Update is called once per frame
	public void stareAtParachutePaper() {
		looking = true;

	}

	public void stopAtParachutePaper() {

		looking = false;
	}
}
