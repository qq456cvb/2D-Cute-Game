using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Basic Node
/// </summary>
public abstract class qpNode  {

    /// <summary>
    /// The nodes with which this node is connected to.
    /// </summary>
    public List<qpNode> Contacts = new List<qpNode>();

    public List<qpNode> NonDiagonalContacts = new List<qpNode>();
    /// <summary>
    /// Whether or not objects may traverse this node.
    /// </summary>
    public bool traverseable = true;

    /// <summary>
    /// Whether or not this node is outdated.
    /// </summary>
    public bool outdated = false;

    private float _g = 1;
    private float _h;
    private float _total;
    private qpNode _parent;
    private Vector3 _coordinate;

    /// <summary>
    /// Gets the coordinate
    /// </summary>
    /// <returns>The coordinate</returns>
    public Vector3 GetCoordinate()
    {
        return _coordinate;
    }
    /// <summary>
    /// Creates a mutual connection between this node and another node.
    /// </summary>
    /// <param name="node">the other node.</param>
    /// <param name="diagonal">Is the other node diagonally placed from this?</param>
    public void SetMutualConnection(qpNode node,bool diagonal = false)
    {
        if (node != null)
        {
            if (!Contacts.Contains(node))
            {
                Contacts.Add(node);
            }
            if (!node.Contacts.Contains(this)) node.Contacts.Add(this);
            if (!diagonal)
            {
                if (!NonDiagonalContacts.Contains(node)) NonDiagonalContacts.Add(node);
                if(!node.NonDiagonalContacts.Contains(this))node.NonDiagonalContacts.Add(this);
            }
        }
    }

    /// <summary>
    /// Sets connection to another node.
    /// </summary>
    /// <param name="node">The other node</param>
    public void SetConnection(qpNode node)
    {
        if (node != null)
        {
            if (!Contacts.Contains(node))
            {
                Contacts.Add(node);
            }
        }
    }
    /// <summary>
    /// Remove a mutual connection between this node and another node.
    /// </summary>
    /// <param name="otherNode">The other node that this node is currently connected to.</param>
    public void RemoveMutualConnection(qpNode otherNode)
    {
        if (otherNode != null)
        {
            if (Contacts.Contains(otherNode))
            {
                Contacts.Remove(otherNode);
            }
            if(NonDiagonalContacts.Contains(otherNode))
            {
                NonDiagonalContacts.Remove(otherNode);
            }
            if (otherNode.Contacts.Contains(this))
            {
                otherNode.Contacts.Remove(this);
            }
            if (otherNode.NonDiagonalContacts.Contains(this))
            {
                otherNode.NonDiagonalContacts.Add(this);
            }
        }
    }
    protected void SetCoordinate(Vector3 newCoordinate)
    {
        _coordinate = newCoordinate;
    }

    #region Pathfinding
    /// <summary>
    /// Used for A*
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public float CalculateTotal(qpNode start, qpNode end)
    {
        _h = CalculateH(end);
        if (_parent != null) _g = CalculateG(_parent) + _parent.GetG();
        else _g = 1;
        _total = _g + _h;
        return _total;
    }
    /// <summary>
    /// Used for A*
    /// </summary>
    public float CalculateH(qpNode end)
    {
        return Vector3.Distance(_coordinate, end.GetCoordinate());
    }
    /// <summary>
    /// Used for A*
    /// </summary>
    public float CalculateG(qpNode parent)
    {
        return Vector3.Distance(_coordinate, parent.GetCoordinate());
    }
    /// <summary>
    /// Used for A*
    /// </summary>
    public float GetG()
    {
        return _g;
    }
    /// <summary>
    /// Used for A*
    /// </summary>
    public float GetTotal()
    {
        return _total;
    }
    /// <summary>
    /// Used for A*
    /// </summary>
    public void SetParent(qpNode parent)
    {
        _parent = parent;
    }
    /// <summary>
    /// Used for A*
    /// </summary>
    public qpNode GetParent()
    {
        return _parent;
    }

    #endregion
}
