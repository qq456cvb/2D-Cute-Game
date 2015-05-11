using UnityEngine;
using System.Collections;

public class EnableCollider : MonoBehaviour {

	Transform transform;
	// Use this for initialization
	void Start () {
		transform = GameObject.Find ("MapNav").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnableRay () {
		foreach (Transform child in transform) {
//			Debug.Log(child.gameObject.name);
			if (child.gameObject.GetComponent<BoxCollider>() != null)
				child.gameObject.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
