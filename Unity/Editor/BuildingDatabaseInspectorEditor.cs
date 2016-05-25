using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CustomEditor (typeof (BuildingObjectsDatabase))]
public class BuildingDatabaseInspectorEditor : Editor {
	
	BuildingObjectsDatabase database;
	List<Object> list;

	private void OnEnable () {

		database = (BuildingObjectsDatabase)target;

		database.FillHashSet(ScriptableObjectUtility.FillAsset(DatabaseLoader.LoadDatabase<PathsDatabase>().friesland.gebouwen));

		if(list == null)
			list = database.objects.ToList();
	}

	public override void OnInspectorGUI () {
		serializedObject.Update();

		foreach(Object item in list){
			EditorGUILayout.ObjectField(item, typeof(GameObject));
		}

		serializedObject.ApplyModifiedProperties();
	}
}
