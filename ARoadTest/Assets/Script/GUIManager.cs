using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	// Use this for initialization
	private Texture[] buttonImage;
	void Start () {
		buttonImage = new Texture[3];
		buttonImage[0] = Resources.Load<Texture>("button_walk");
		buttonImage[1] = Resources.Load<Texture>("button_light");
		buttonImage[2] = Resources.Load<Texture>("button_on");
	}

	void OnGUI () {
		if(GUI.Button(new Rect(50, 40, 80, 80),buttonImage[0])){

		}
		if(GUI.Button(new Rect(50, 130, 80, 80), buttonImage[1])){

		}
		if(GUI.Button(new Rect(50, 220, 80, 80), buttonImage[2])){

		}
	}
}
