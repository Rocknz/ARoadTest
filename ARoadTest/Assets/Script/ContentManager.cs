using UnityEngine;
using System.Collections;

public class ContentManager{
	private static ContentManager instance = null;
	private enum MODE{
		DefaultMode
	};
	private MODE nowMode;
	public static ContentManager getInstance(){
		if(instance == null){
			instance = new ContentManager();
			instance.nowMode = MODE.DefaultMode;
		}
		return instance;
	}
}
