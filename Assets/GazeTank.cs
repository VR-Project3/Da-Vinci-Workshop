using UnityEngine;
using System.Collections;

public class GazeTank : MonoBehaviour {

	bool isAnimating;
	bool start = false;
	bool looking = false;

	//	public Transform projectile;
	//	public float bulletSpeed = 20;

	public GameObject player;


	SplineController tankSpline;
	public GameObject Tank;
	private bool didRecordTimes = false;
	private float startTime;

	public GameObject BulletPack1;
	public GameObject Bullet1;
	public GameObject Bullet2;
	public GameObject Bullet3;
	public GameObject Bullet4;
	private bool activeBullet1_4 = false;
	private float activateTimeBullet1_4;

	public GameObject BulletPack2;
	public GameObject Bullet5;
	public GameObject Bullet6;
	public GameObject Bullet7;
	public GameObject Bullet8;
	private bool activeBullet5_8 = false;
	private float activateTimeBullet5_8;

	public GameObject BulletPack3;
	public GameObject Bullet9;
	public GameObject Bullet10;
	public GameObject Bullet11;
	public GameObject Bullet12;
	private bool activeBullet9_12 = false;
	private float activateTimeBullet9_12;

	public GameObject BulletPackFinal;
	public GameObject Bullet13;
	public GameObject Bullet14;
	public GameObject Bullet15;
	public GameObject Bullet16;
	public GameObject Bullet17;
	public GameObject Bullet18;
	public GameObject Bullet19;
	public GameObject Bullet20;
	private bool activeBullet13_20 = false;
	private float activateTimeBullet13_20;

	// Use this for initialization
	void Start () {
		isAnimating = false;
	}

	void Update(){

		float distance = Vector3.Distance (transform.position, player.transform.position);
		if(looking && distance < 5.0f){
			isAnimating = true;

			if(!start){
				foreach (Renderer r in Tank.GetComponentsInChildren<Renderer>()){
					r.enabled = true;
				}
				Tank.GetComponent<SplineController>().FollowSpline ();

				startTime = Time.time;
				activateTimeBullet1_4 = Time.time + 3.0f;
				activateTimeBullet5_8 = Time.time + 10.0f;
				activateTimeBullet9_12 = Time.time + 23.0f;
				activateTimeBullet13_20 = Time.time + 31.0f;
				start = true;
			}
		}

		if(isAnimating){
			if(activateTimeBullet1_4 < Time.time){
				if(!activeBullet1_4){
					foreach (Renderer r in BulletPack1.GetComponentsInChildren<Renderer>()){
						r.enabled = true;
					}
					Bullet1.GetComponent<SplineController>().FollowSpline ();
					Bullet2.GetComponent<SplineController>().FollowSpline ();
					Bullet3.GetComponent<SplineController>().FollowSpline ();
					Bullet4.GetComponent<SplineController>().FollowSpline ();
					activeBullet1_4 = true;
				}
			} 
			if((activateTimeBullet1_4 + 2.0f) < Time.time){
				foreach (Renderer r in BulletPack1.GetComponentsInChildren<Renderer>()){
					r.enabled = false;
				}
			}
			if (activateTimeBullet5_8 < Time.time) {
				if(!activeBullet5_8){
					foreach (Renderer r in BulletPack2.GetComponentsInChildren<Renderer>()){
						r.enabled = true;
					}
					Bullet5.GetComponent<SplineController>().FollowSpline ();
					Bullet6.GetComponent<SplineController>().FollowSpline ();
					Bullet7.GetComponent<SplineController>().FollowSpline ();
					Bullet8.GetComponent<SplineController>().FollowSpline ();
					activeBullet5_8 = true;
				}
			}
			if((activateTimeBullet5_8 + 2.0f) < Time.time){
				foreach (Renderer r in BulletPack2.GetComponentsInChildren<Renderer>()){
					r.enabled = false;
				}
			}
			if (activateTimeBullet9_12 < Time.time) {
				if(!activeBullet9_12){
					foreach (Renderer r in BulletPack3.GetComponentsInChildren<Renderer>()){
						r.enabled = true;
					}
					Bullet9.GetComponent<SplineController>().FollowSpline ();
					Bullet10.GetComponent<SplineController>().FollowSpline ();
					Bullet11.GetComponent<SplineController>().FollowSpline ();
					Bullet12.GetComponent<SplineController>().FollowSpline ();
					activeBullet9_12 = true;
				}
			}
			if((activateTimeBullet9_12 + 2.0f) < Time.time){
				foreach (Renderer r in BulletPack3.GetComponentsInChildren<Renderer>()){
					r.enabled = false;
				}
			}
			if (activateTimeBullet13_20 < Time.time) {
				if(!activeBullet13_20){
					foreach (Renderer r in BulletPackFinal.GetComponentsInChildren<Renderer>()){
						r.enabled = true;
					}
					Bullet13.GetComponent<SplineController>().FollowSpline ();
					Bullet14.GetComponent<SplineController>().FollowSpline ();
					Bullet15.GetComponent<SplineController>().FollowSpline ();
					Bullet16.GetComponent<SplineController>().FollowSpline ();
					Bullet17.GetComponent<SplineController>().FollowSpline ();
					Bullet18.GetComponent<SplineController>().FollowSpline ();
					Bullet19.GetComponent<SplineController>().FollowSpline ();
					Bullet20.GetComponent<SplineController>().FollowSpline ();
					activeBullet13_20 = true;
				}
			}
			if((activateTimeBullet13_20 + 2.0f) < Time.time){
				foreach (Renderer r in BulletPackFinal.GetComponentsInChildren<Renderer>()){
					r.enabled = false;
				}
				foreach (Renderer r in Tank.GetComponentsInChildren<Renderer>()){
					r.enabled = false;
				}
			}

			if((startTime + 36.0f) < Time.time){
				isAnimating = false;
				start = false;
				activeBullet1_4 = false;
				activeBullet5_8 = false; 
				activeBullet9_12 = false;
				activeBullet13_20 = false;
			}
		}
	}

	// Update is called once per frame
	public void stareAtTankPaper() {

		looking = true;

	}

	public void stopAtTankPaper() {

		looking = false;
	}
}

