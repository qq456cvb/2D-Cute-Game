using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public ArrayList enemies = new ArrayList();

	// Use this for initialization
	void Awake()
	{
		Instance = this;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool FindEnemy () 
	{
		if (enemies.Count == 0)
			return false;
		return true;
	}
}
