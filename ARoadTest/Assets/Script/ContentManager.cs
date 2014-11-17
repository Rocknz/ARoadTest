using UnityEngine;
using System.Collections;

public class ContentManager{
	private static ContentManager instance = null;
	public enum MODE{
		UnTrackingMode,
		DefaultMode,
		ThirdPersonView,
		FirstPersonView
	};
	private MODE nowMode;

	public MODE NowMode{
		set{
			nowMode = value;
		}
		get{
			return nowMode;
		}
	}
	public static ContentManager GetInstance(){
		if(instance == null){
			instance = new ContentManager();
			instance.nowMode = MODE.DefaultMode;
		}
		return instance;
	}
}
