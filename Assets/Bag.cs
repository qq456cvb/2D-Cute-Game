using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bag : MonoBehaviour {

	private static Dictionary<string, int> items = new Dictionary<string, int> ();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddItem(GameObject obj) {
		if (!items.ContainsKey (obj.name)) {
			items.Add (obj.name, 1);
		} else {
			items[obj.name]++;
		}
		Debug.Log (obj.name + " picked: now you have " + items[obj.name].ToString());
	}
}
