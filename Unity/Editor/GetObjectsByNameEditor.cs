using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class GetObjectsByNameEditor {
	
	[MenuItem("Tools/Get GameObject By Name #g")]
	static void GetObjects(){
		List<GameObject> goList = new List<GameObject>();
		string objName;
		
		objName = Selection.activeGameObject.name;
		
		foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))){
			if(go.name == objName)
				goList.Add(go);
		}
		
		Selection.objects = goList.ToArray();
	}
	
	[MenuItem("Tools/Get GameObject by Name #g", true)]
	static bool GetObjectValidator(){
		return Selection.activeGameObject != null;
	}
	
}
