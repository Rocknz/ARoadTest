using UnityEngine;
using System.Collections;

public class ContentManager{
	private static ContentManager instance = null;
	private enum MODE{
		DefaultMode,
		ThirdPersonView,
		FirstPersonView
	};
	private MODE nowMode;

	public void SetMode(MODE inputMode){
		nowMode = inputMode;
	}
	public static ContentManager GetInstance(){
		if(instance == null){
			instance = new ContentManager();
			instance.nowMode = MODE.DefaultMode;
		}
		return instance;
	}
}
