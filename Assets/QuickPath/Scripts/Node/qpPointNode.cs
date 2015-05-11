using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A point node(in other words a WayPoint node). Contained by NodeScript.
/// </summary>
public class qpPointNode : qpNode {
    /// <summary>
    /// The nodescript component which holds this node.
    /// </summary>
    public qpNodeScript nodescript;
    public qpPointNode()
    {
        
    }
    /// <summary>
    /// Initializes the node
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="connections"></param>
    public void Init(qpNodeScript parent,List<qpNodeScript> connections)
    {
        nodescript = parent;
        SetCoordinate(parent.transform.position);
        foreach (qpNodeScript ns in connections) SetConnection(ns.Node);
        qpManager.Instance.RegisterNode(this);
    }
}
