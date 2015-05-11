using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("QuickPath/WayPointScript")]
/// <summary>
/// A script that creates a node at its position
/// </summary>
public class qpNodeScript : MonoBehaviour
{
    /// <summary>
    /// The created node
    /// </summary>
    public qpPointNode Node = new qpPointNode();

    /// <summary>
    /// The connections/contacts of the node
    /// </summary>
    public List<qpNodeScript> connections = new List<qpNodeScript>();

    /// <summary>
    /// Use this for initialization
    /// </summary>
	void Awake () {
        Node.Init(this,connections);
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
            if(GetComponent<Renderer>().material !=null)GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }
	}
}
