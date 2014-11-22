using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public GameObject CarObj;
	public GameObject ImageTargetObj;
	public GameObject ARCam;
	public GameObject ObjGroup;
	public GameObject CarCam;

	// Use this for initialization
	private Texture[] buttonImage;
	void Start () {
		buttonImage = new Texture[3];
		buttonImage[0] = Resources.Load<Texture>("button_two");
		buttonImage[1] = Resources.Load<Texture>("button_one");
		buttonImage[2] = Resources.Load<Texture>("button_three");
	}

	void OnGUI () {

		//3인칭 모드
		if(GUI.Button(new Rect(50, 40, 80, 80),buttonImage[0])){
			if(ContentManager.GetInstance().NowMode == ContentManager.MODE.DefaultMode){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.ThirdPersonView;
				CarObj.SetActive(true);
				CarCam.SetActive(false);
			}
			else if(ContentManager.GetInstance().NowMode == ContentManager.MODE.ThirdPersonView){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.DefaultMode;
				CarObj.SetActive(false);
				CarCam.SetActive(false);
			}
			Debug.Log (ContentManager.GetInstance().NowMode);
		}
		//1인칭 모드
		if(GUI.Button(new Rect(50, 130, 80, 80), buttonImage[1])){
			if(ContentManager.GetInstance().NowMode == ContentManager.MODE.FirstPersonView){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.ThirdPersonView;
				ImageTargetObj.SetActive(true);
				CarObj.SetActive(true);
				ObjGroup.transform.parent = ImageTargetObj.transform;
				ARCam.SetActive(true);
				CarCam.SetActive(false);
			}
			else if(ContentManager.GetInstance().NowMode == ContentManager.MODE.ThirdPersonView){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.FirstPersonView;
				CarCam.transform.position = ARCam.transform.position;
				CarCam.transform.rotation = ARCam.transform.rotation;
				CarObj.SetActive(true);
				ObjGroup.transform.parent = this.transform.parent;
				CarCam.SetActive(true);
				SetCamPos tempScript = (SetCamPos)CarCam.GetComponent(typeof(SetCamPos));
				tempScript.Cam_posSet();
				ObjGroup.transform.parent = this.transform.parent;
				
				ImageTargetObj.SetActive(false);
				ARCam.SetActive(false);
			}
			else if(ContentManager.GetInstance().NowMode == ContentManager.MODE.DefaultMode){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.FirstPersonView;
				CarCam.transform.position = ARCam.transform.position;
				CarCam.transform.rotation = ARCam.transform.rotation;
				CarObj.SetActive(true);
				ObjGroup.transform.parent = this.transform.parent;
				CarCam.SetActive(true);
				SetCamPos tempScript = (SetCamPos)CarCam.GetComponent(typeof(SetCamPos));
				tempScript.Cam_posSet();
				ObjGroup.transform.parent = this.transform.parent;

				ImageTargetObj.SetActive(false);
				ARCam.SetActive(false);
			}
			Debug.Log (ContentManager.GetInstance().NowMode);
		}
		if(GUI.Button(new Rect(50, 220, 80, 80), buttonImage[2])){
			if(ContentManager.GetInstance().NowMode == ContentManager.MODE.DefaultMode){

			}
		}
		// On/Off Mode 
		/*
		    if(ContentManager.GetInstance().NowMode == ContentManager.MODE.DefaultMode){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.UnTrackingMode;
				ImageTargetObj.SetActive(false);
			}else if(ContentManager.GetInstance().NowMode == ContentManager.MODE.UnTrackingMode){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.DefaultMode;
				ImageTargetObj.SetActive(true);
			}
			Debug.Log (ContentManager.GetInstance().NowMode);
		*/

	}
}
