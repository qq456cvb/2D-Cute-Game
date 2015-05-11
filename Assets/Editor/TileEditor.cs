using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TileObject))]
public class TileEditor : Editor {

	protected bool editMode = false;
	protected TileObject tileObject;

	void OnEnable()
	{
		// 获得tile角本
		tileObject = (TileObject)target;
		// 获得Mesh
	}

	public void OnSceneGUI()
	{
		if (editMode)
		{
			// 取消编辑器的选择功能
			HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
			
			// 获取Input事件
			Event e = Event.current;
			
			//tileObject.showData = true;
			
			// 如果是鼠标左键
			if ( e.isMouse && e.button == 0 && e.clickCount == 1)
			{
				//Debug.Log("hello");
				// 获取由鼠标位置产生的射线
				Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
				//Debug.Log(ray.ToString());
				// 计算碰撞
				RaycastHit hitinfo;
				if (Physics.Raycast(ray, out hitinfo, 2000, tileObject.tileLayer))
				{
					Debug.Log(hitinfo.transform.name);
					var c = hitinfo.transform.GetComponent<TileObjectRawData> ();
					c.dataID = 1;
				}
			}
		}
		else
		{
			// 恢复编辑器的选择功能
			HandleUtility.Repaint();
			//tileObject.showData = false;
		}
	}
	
	public override void OnInspectorGUI()
	{
		//int maxcount = tileObject.GetComponent<MeshRenderer>().sharedMaterials.Length;
		
		GUILayout.Label("Tile Editor");
		EditorGUILayout.Separator();
		
		editMode = EditorGUILayout.Toggle("Edit", editMode);
		
		EditorGUILayout.Separator();
		
		DrawDefaultInspector();
	}
}
