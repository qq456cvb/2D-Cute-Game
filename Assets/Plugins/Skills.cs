using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skills : MonoBehaviour {

	private static Dictionary<string, string> skills = new Dictionary<string, string> ();
	// Use this for initialization
	void Start () {
		skills.Add ("w", "");
		skills.Add ("a", "");
		skills.Add ("s", "");
		skills.Add ("d", "");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetSkill(string key)
	{
//		Debug.Log (key);
//		Debug.Log (skills[key]);
		if (skills.ContainsKey(key)) {
			return skills[key];
		} else {
			return "";
		}
	}
	public void SetSkill(string key, string value)
	{
		skills [key] = value;
//		Debug.Log (key);
//		Debug.Log (value);
	}
	

}
