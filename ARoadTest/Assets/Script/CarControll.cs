using UnityEngine;
using System.Collections;

public class CarControll : MonoBehaviour {
	// Use this for initialization
	private const float velocity = 0.5f;
	private const float rotateVelocity = 1.0f;

	private bool Firsttouched = false;

	private Vector2 PresentTouchHandlePos;
	private Vector2 HandleCenter;

	private int tTouchMode1;
	private int tTouchMode2;

	void Start () {
		HandleCenter.y = 0;
		HandleCenter.x = Screen.width / 4;
	}
	
	// Update is called once per frame
	void Update () {
		//핸들 온으로 변경
		if (ContentManager.GetInstance ().NowMode == ContentManager.MODE.FirstPersonView || ContentManager.GetInstance ().NowMode == ContentManager.MODE.ThirdPersonView) {
			tTouchMode1 = tTouchMode2 = -1;			//mode initialize

			if(Input.GetMouseButton(0)){
				tTouchMode1 = CheckHandleORAccel(/*Input.GetTouch(0).position*/Input.mousePosition);
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

	//return accel 1, handle 0
	int CheckHandleORAccel(Vector2 TouchPoint){
		int ScreenCenter = Screen.width/2;

		if (TouchPoint.x > ScreenCenter)
						return 1;
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

	void RotateCar(){
		Vector2 difVec = PresentTouchHandlePos - HandleCenter;
		Vector2 basisVec = new Vector2 (0, 1);
		difVec.Normalize ();
		//Debug.Log (PresentTouchHandlePos);

		float tAngle = Vector2.Angle (basisVec, difVec);

		if (difVec.x < 0) {

		}
		else {
		}
	}

	void ControllCar(int mode){
		if (mode == 1) {
			MoveCar ();
		} else if (mode == 0) {
			if(Firsttouched == true){
				RotateCar ();
			}
		}
	}

	Vector3 GetModelDirection(){
		return this.transform.forward;
	}
}
