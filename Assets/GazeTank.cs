using UnityEngine;
using System.Collections;

public class GazeTank : MonoBehaviour {

	bool isAnimating;

//	public Transform projectile;
//	public float bulletSpeed = 20;

	SplineController tankSpline;

	// Use this for initialization
	void Start () {
		isAnimating = false;
	}

	// Update is called once per frame
	public void stareAtTankPaper() {
		print ("hey");
		foreach(Transform t in transform)
		{   
			if(t.name == "Tank"){
				isAnimating = true;
				t.gameObject.active = true;
				tankSpline = t.GetComponent<SplineController>();
				tankSpline.FollowSpline ();
			
			}
			if(t.name == "Bullet"){
				t.gameObject.active = true;
				tankSpline = t.GetComponent<SplineController>();
				tankSpline.FollowSpline ();

			}
		}
	}
}
