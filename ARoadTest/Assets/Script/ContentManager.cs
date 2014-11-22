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
	private string trackingTarget;
	private bool nowShowPath;

	public MODE NowMode{
		set{
			nowMode = value;
		}
		get{
			return nowMode;
		}
	}
	public string TrackingTarget{
		set{
			trackingTarget = value;
		}
		get{
			return trackingTarget;
		}
	}
	public bool NowShowPath{
		set{
			nowShowPath = value;
		}
		get{
			return nowShowPath;
		}
	}
	public static ContentManager GetInstance(){
		if(instance == null){
			instance = new ContentManager();
			instance.nowMode = MODE.DefaultMode;
			instance.trackingTarget = "nothing";
			instance.nowShowPath = false;
		}
		return instance;
	}
}
