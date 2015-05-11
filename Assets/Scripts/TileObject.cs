using UnityEngine;
//using UnityEditor;
using System.Collections;

public class TileObject : MonoBehaviour {

	public static TileObject get = null;

	public LayerMask tileLayer;

	//protected int editID;
	void Awake()
	{
		get = this;
	}


}
