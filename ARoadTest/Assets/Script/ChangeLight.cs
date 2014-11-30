using UnityEngine;
using System.Collections;

public class ChangeLight : MonoBehaviour {

	private float rotVel;

	// Use this for initialization
	void Start () {
		//this.trans
		rotVel = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 LightRot = this.transform.localEulerAngles;
		LightRot.y += rotVel;
		this.transform.localEulerAngles = LightRot;
	}
}
