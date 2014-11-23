using UnityEngine;
using System.Collections;

public class CarControll : MonoBehaviour {
	// Use this for initialization
	public Texture AccelButton;
	public Texture BackButton;

	private const float velocity = 0.5f;
	private const float rotateVelocity = 0.1f;

	private bool Firsttouched = false;

	private Vector2 PresentTouchHandlePos;
	private Vector2 HandleCenter;

	private int tTouchMode1;
	private int tTouchMode2;

	private Rect AccelButtonRect;
	private Rect BackButtonRect;

	private Texture steering_Wheel;
	private float steering_Angle;

	void Start () {
		HandleCenter.y = 0;
		HandleCenter.x = Screen.width / 4;

		AccelButtonRect = new Rect (Screen.width-90, Screen.height-180,80,80);
		BackButtonRect = new Rect (Screen.width-90, Screen.height-90,80,80);

		steering_Wheel = Resources.Load<Texture>("steering_wheel");
		steering_Angle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//핸들 온으로 변경
		if (ContentManager.GetInstance ().NowMode == ContentManager.MODE.FirstPersonView || ContentManager.GetInstance ().NowMode == ContentManager.MODE.ThirdPersonView) {
			tTouchMode1 = tTouchMode2 = -1;			//mode initialize

			if(Input.GetMouseButton(0)){
				tTouchMode1 = CheckHandleORAccel(Input.GetTouch(0).position/*Input.mousePosition*/);
				ControllCar(tTouchMode1);
			}
			if(Input.GetMouseButton(1)){
				tTouchMode2 = CheckHandleORAccel(Input.GetTouch(1).position);
				ControllCar(tTouchMode2);
			}

			if(tTouchMode1 != 0 && tTouchMode2 != 0){
				Firsttouched = false;
			}
		}
	}

	//return accel 1, handle 0, back 2
	int CheckHandleORAccel(Vector2 TouchPoint){
		int ScreenCenter = Screen.width/2;

		if (InRectTouch(AccelButtonRect, TouchPoint))
						return 1;
		else if(InRectTouch(BackButtonRect, TouchPoint))
		        return 2;
		else {
			PresentTouchHandlePos = TouchPoint;
			if(Firsttouched == false){
				Firsttouched = true;
			}

			return 0;
		}
	}

	void MoveCar(){
		Vector3 tMove = GetModelDirection () * velocity;;
		this.transform.position += tMove;
	}

	void BackMoving(){
		Vector3 tMove = GetModelDirection () * velocity;;
		this.transform.position -= tMove;
	}

	void RotateCar(){
		Vector2 difVec = PresentTouchHandlePos - HandleCenter;
		Vector2 basisVec = new Vector2 (0, 1);
		difVec.Normalize ();
		//Debug.Log (PresentTouchHandlePos);

		float tAngle = Vector2.Angle (basisVec, difVec);
		Vector3 z_axis = new Vector3(0, 0, 1);
		//Quaternion presentRotation = this.transform.rotation;

		if (difVec.x < 0) {
			this.transform.localEulerAngles += Quaternion.AngleAxis(tAngle*(-rotateVelocity), Vector3.up).eulerAngles;
			steering_Angle = tAngle * (-rotateVelocity);
		}
		else {
			this.transform.localEulerAngles += Quaternion.AngleAxis(tAngle*(rotateVelocity), Vector3.up).eulerAngles;
			steering_Angle = tAngle * (rotateVelocity);
		}
	}

	void ControllCar(int mode){
		if (mode == 1) {
			MoveCar ();
		}
		else if (mode == 0) {
			if (Firsttouched == true) {
				RotateCar ();
			}
		}
		else if (mode == 2) {
			BackMoving();
		}
	}

	Vector3 GetModelDirection(){
		return this.transform.forward;
	}

	bool InRectTouch(Rect Box, Vector2 Touchpos){
		Vector2 tTouchPos = new Vector2 (Touchpos.x, Screen.height-Touchpos.y);
		if(Box.x < tTouchPos.x && Box.x+Box.width > tTouchPos.x)
			if(Box.y < tTouchPos.y && Box.y+Box.height > tTouchPos.y)
					return true;

			return false;
	}

	void OnGUI(){
		//Draw Handle;
		Matrix4x4 matrixBackup = GUI.matrix;
		GUIUtility.RotateAroundPivot(steering_Angle,new Vector2(Screen.width/4,Screen.height));
		GUI.DrawTexture (new Rect(0,Screen.height-Screen.width/4,Screen.width/2,Screen.width/2),steering_Wheel);
		GUI.matrix = matrixBackup;
		//accel button
		GUI.Button (AccelButtonRect, AccelButton);
		//back or break button
		GUI.Button (BackButtonRect, BackButton);
	}
}
