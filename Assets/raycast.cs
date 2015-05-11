using UnityEngine;
using System.Collections;

public class raycast : MonoBehaviour {

	Camera camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Camera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject RayCol (float x, float y) {
		Ray ray = camera.ScreenPointToRay(new Vector3(x, y, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 500f)) {
			Debug.Log("hit something");
			return hit.collider.gameObject;
		}
		return null;
	}
}
