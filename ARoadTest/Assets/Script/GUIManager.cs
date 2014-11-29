using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public GameObject CarObj;
	public GameObject ImageTargetObj;
	public GameObject ARCam;
	public GameObject ObjGroup;
	public GameObject CarCam;
	public GameObject ImgPlane;

	// Use this for initialization
	private Texture[] button_Off_Image;
	private Texture[] button_On_Image;
	private Texture[] buttonImage;

	private GameObject tObjGroup;
	void Start () {
		button_Off_Image = new Texture[4];
		button_Off_Image[0] = Resources.Load<Texture>("thirdperson_off");
		button_Off_Image[1] = Resources.Load<Texture>("firstperson_off");
		button_Off_Image[2] = Resources.Load<Texture>("course_off");
		button_Off_Image[3] = Resources.Load<Texture>("off");
		button_On_Image = new Texture[4];
		button_On_Image[0] = Resources.Load<Texture>("thirdperson_L");
		button_On_Image[1] = Resources.Load<Texture>("firstperson_L");
		button_On_Image[2] = Resources.Load<Texture>("course_L");
		button_On_Image[3] = Resources.Load<Texture>("on");
	}

	void OnGUI () {
		buttonImage = new Texture[4];
		if(ContentManager.GetInstance().NowMode == ContentManager.MODE.ThirdPersonView)
			buttonImage[0] = button_On_Image[0];
		else 
			buttonImage[0] = button_Off_Image[0];
		if(ContentManager.GetInstance().NowMode == ContentManager.MODE.FirstPersonView)
			buttonImage[1] = button_On_Image[1];
		else 
			buttonImage[1] = button_Off_Image[1];

		if(ContentManager.GetInstance().NowShowPath)
			buttonImage[2] = button_On_Image[2];
		else 
			buttonImage[2] = button_Off_Image[2];
		if(ContentManager.GetInstance().NowMode == ContentManager.MODE.UnTrackingMode)
			buttonImage[3] = button_Off_Image[3];
		else 
			buttonImage[3] = button_On_Image[3];
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
				Destroy((Object)tObjGroup);
				//ObjGroup.transform.parent = ImageTargetObj.transform;
				ImgPlane.SetActive(false);
				ARCam.SetActive(true);
				CarCam.SetActive(false);
			}
			else if(ContentManager.GetInstance().NowMode == ContentManager.MODE.ThirdPersonView){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.FirstPersonView;
				CarCam.transform.position = ARCam.transform.position;
				CarCam.transform.rotation = ARCam.transform.rotation;
				CarObj.SetActive(true);
				CarCam.SetActive(true);
				SetCamPos tempScript = (SetCamPos)CarCam.GetComponent(typeof(SetCamPos));
				tempScript.Cam_posSet();
				ImgPlane.SetActive(true);
				tObjGroup = (GameObject)Instantiate(ObjGroup);
				tObjGroup.transform.name = "Obj";
				tObjGroup.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				tObjGroup.transform.parent = ImgPlane.transform;
				ImageTargetObj.SetActive(false);
				ARCam.SetActive(false);
			}
			else if(ContentManager.GetInstance().NowMode == ContentManager.MODE.DefaultMode){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.FirstPersonView;
				CarCam.transform.position = ARCam.transform.position;
				CarCam.transform.rotation = ARCam.transform.rotation;
				CarObj.SetActive(true);
				CarCam.SetActive(true);
				SetCamPos tempScript = (SetCamPos)CarCam.GetComponent(typeof(SetCamPos));
				tempScript.Cam_posSet();
				ImgPlane.SetActive(true);
				tObjGroup = (GameObject)Instantiate(ObjGroup);
				tObjGroup.transform.name = "Obj";
				tObjGroup.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				tObjGroup.transform.parent = ImgPlane.transform;
				ImageTargetObj.SetActive(false);
				ARCam.SetActive(false);
			}
			Debug.Log (ContentManager.GetInstance().NowMode);
		}
		if(GUI.Button(new Rect(50, 220, 80, 80), buttonImage[2])){
//			if(ContentManager.GetInstance().NowMode == ContentManager.MODE.DefaultMode){
			if(ContentManager.GetInstance ().NowMode != ContentManager.MODE.FirstPersonView){
				if(!ContentManager.GetInstance ().TrackingTarget.Equals("nothing")){
					GameObject now = GameObject.Find (ContentManager.GetInstance().TrackingTarget);
					now = now.transform.FindChild("Obj").FindChild("Path").gameObject;
					now.GetComponent<Pathes>().ShowPath();
				}
			}
			else{
				GameObject now = GameObject.Find ("ImagePlane");
				now = now.transform.FindChild("Obj").FindChild("Path").gameObject;
				now.GetComponent<Pathes>().ShowPath ();
			}
//			}
		}
		// On/Off Mode 
		if(GUI.Button (new Rect(50,310,80,80), buttonImage[3])){
		    if(ContentManager.GetInstance().NowMode == ContentManager.MODE.DefaultMode){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.UnTrackingMode;
				ImageTargetObj.SetActive(false);
			}else if(ContentManager.GetInstance().NowMode == ContentManager.MODE.UnTrackingMode){
				ContentManager.GetInstance().NowMode = ContentManager.MODE.DefaultMode;
				ImageTargetObj.SetActive(true);
			}
		}
	}
}
