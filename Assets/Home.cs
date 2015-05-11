using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Home : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LifeToGUI(int life)
	{	
		GameObject textObj = GameObject.Find ("LifeTxt");
		Text txt = textObj.GetComponent<Text> ();
		string life_str = life.ToString() + " / 10";
		txt.text = life_str;
	}
}
