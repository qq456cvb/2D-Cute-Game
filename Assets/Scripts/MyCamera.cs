using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

	private Transform m_transform;
	// Use this for initialization
	void Start () {
		m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		bool press = Input.GetMouseButton (0);

		float mx = Input.GetAxis ("Mouse X");
		float my = Input.GetAxis ("Mouse Y");

		if (press)
			m_transform.Translate (-mx, -my, 0);
	}
}
