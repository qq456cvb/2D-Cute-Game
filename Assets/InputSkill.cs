using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputSkill : MonoBehaviour {

	Skills skills;
	// Use this for initialization
	void Start () {
		skills = GameObject.Find ("SkillController").GetComponent<Skills> ();
		AutoGenSkill ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InputToSkill () {
//		Debug.Log(this.name.Substring (5));
		skills.SetSkill (this.name.Substring (5), this.gameObject.GetComponent<InputField>().text);
//		Debug.Log (this.gameObject.GetComponent<InputField>().text);
	}

	public void AutoGenSkill () {
		switch (this.name.Substring (5)) {
		case "w":
			this.gameObject.GetComponent<InputField>().text = "MoveUp();";
			break;
		case "a":
			this.gameObject.GetComponent<InputField>().text = "MoveLeft();";
			break;
		case "s":
			this.gameObject.GetComponent<InputField>().text = "MoveDown();";
			break;
		case "d":
			this.gameObject.GetComponent<InputField>().text = "MoveRight();";
			break;
		}
		InputToSkill ();
	}
}
