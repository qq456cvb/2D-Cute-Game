﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(qpGrid))]
public class qpGridEditor : Editor
{
    //[MenuItem("QuickPath/Prefabs/Waypoint")]
    //static void Waypoint()
    //{
    //    PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/QuickPath/Prefabs/Waypoint.prefab", typeof(GameObject)));
    //}
    private qpGrid _grid;
    private string spread = "1";
    public override void OnInspectorGUI()
    {
        //string[] strings =new [] { "foo", "foobar" };
        //EditorGUILayout.Popup(0, strings);
        
        if (GUILayout.Button("Bake", GUILayout.Height(40)))
        {
            _grid.Bake();
        }

        _grid = (qpGrid)target;

        _grid.DrawInEditor = (GUILayout.Toggle(_grid.DrawInEditor, "Draw In Editor"));
        GUIStyle style = new GUIStyle();
        style.fixedWidth = 200;
        style.contentOffset = new Vector2(300, 0);
        _grid.startCoordinate = EditorGUILayout.Vector2Field("Start point of Grid", _grid.startCoordinate);
        _grid.endCoordinate = EditorGUILayout.Vector2Field("End point of Grid", _grid.endCoordinate);

        GUILayout.Label("Up Direction");
        _grid.UpDirection = (qpGrid.Axis)EditorGUILayout.EnumPopup(_grid.UpDirection);
        _showHighestPoint();
        _showLowestPoint();
        _showNodeSpread();
        _showDisallowedTags();
        _showIgnoreTags();
        if (GUI.changed) EditorUtility.SetDirty(target);

    }
    private void _showHighestPoint()
    {
        float flo;
        string showstr = "";
        if (_grid.UpRaycastStart != 0) showstr = _grid.UpRaycastStart.ToString();
        GUILayout.Label("Highest Point");
        string str = GUILayout.TextField(showstr, EditorStyles.numberField);
        if (float.TryParse(str, out flo)) _grid.UpRaycastStart = flo;
        else _grid.UpRaycastStart = 0;
    }
    private void _showLowestPoint()
    {
        float flo;
        string showstr = "";
        if (_grid.UpRayCastEnd != 0) showstr = _grid.UpRayCastEnd.ToString();
        GUILayout.Label("Lowest Point");
        string str = GUILayout.TextField(showstr, EditorStyles.numberField);
        if (float.TryParse(str, out flo)) _grid.UpRayCastEnd = float.Parse(str);
        else _grid.UpRayCastEnd = 0;
    }
    private void _showNodeSpread()
    {
        float flo;
        string showstr = "";
        if (_grid.spread != 0) showstr = _grid.spread.ToString();
        GUILayout.Label("Node Spread");
        string str = GUILayout.TextField(showstr, EditorStyles.numberField);
        if (float.TryParse(str, out flo)) _grid.spread = float.Parse(str);
        else _grid.spread = 0;
        
    }
    private void _showDisallowedTags()
    {
        serializedObject.Update();
        EditorGUIUtility.LookLikeInspector();
        SerializedProperty tps = serializedObject.FindProperty("DisallowedTags");
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(tps, true);
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
    }
    private void _showIgnoreTags()
    {
        serializedObject.Update();
        EditorGUIUtility.LookLikeInspector();
        SerializedProperty tps = serializedObject.FindProperty("IgnoreTags");
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(tps, true);
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
    }
}
