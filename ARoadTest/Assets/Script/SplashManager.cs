using UnityEngine;
using System.Collections;

public class SplashManager : MonoBehaviour {
	private Texture splashImage;
	private AsyncOperation async;
	private Texture inLoadBar;
	private Texture outLoadBar;
	void Start () {
		splashImage = Resources.Load<Texture>("splashs");
		StartCoroutine (LoadNextScene());

		Screen.orientation = ScreenOrientation.LandscapeRight;

		inLoadBar = Resources.Load<Texture>("loadingbar_in");
		outLoadBar = Resources.Load<Texture>("loadingbar_out");
	}
	// Update is called once per frame
	void OnGUI () {

		float screenCenter = Screen.width / 2;
		float inLoadbarLeft = screenCenter - inLoadBar.width / 2;
		float outLoadbarLeft = screenCenter - outLoadBar.width / 2;
		float inLoadbarTop = Screen.height - 100;
		float outLoadbarTop = Screen.height - 100;
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), splashImage);
//		GUI.DrawTexture(new Rect(outLoadbarLeft, outLoadbarTop, outLoadBar.width, outLoadBar.height), outLoadBar);
//		GUI.DrawTexture(new Rect(inLoadbarLeft + 10, inLoadbarTop + 10, inLoadBar.width * async.progress, inLoadBar.height * 0.75F), inLoadBar);
	}
	IEnumerator LoadNextScene()
	{
		async = Application.LoadLevelAsync("Main");
		yield return async;
	}
}
