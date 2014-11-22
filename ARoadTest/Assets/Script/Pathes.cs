using UnityEngine;
using System.Collections;

public class Pathes : MonoBehaviour {
	private int length;
	private YieldInstruction waiting;
	// Use this for initialization
	void Start () {
		length = 36;
		waiting = new WaitForSeconds(0.1f);
	}
	public void ShowPath(){
		if(!ContentManager.GetInstance().NowShowPath){
			StartCoroutine("showthepath");
		}
	}
	private void show(string name){
		if(this.transform.FindChild(name) != null)
		this.transform.FindChild(name).gameObject.SetActive(true);
	}
	private void shade(string name){
		this.transform.FindChild(name).gameObject.SetActive(false);
	}
	public IEnumerator showthepath(){
		ContentManager.GetInstance().NowShowPath = true;
		int i;
		show("1");
		yield return waiting;
		show("2");
		yield return waiting;
		for(i=3;i<=length;i++){
			show (i.ToString ());
			yield return waiting;
			shade((i-2).ToString());
		}
		yield return waiting;
		shade((length-1).ToString());
		yield return waiting;
		shade((length).ToString());
		yield return waiting;
		ContentManager.GetInstance().NowShowPath = false;
		yield return null;
	}
}
