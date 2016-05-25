using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor (typeof(BuildingObject))]
public class BuildingObjectInspectorEditor : Editor {
	
	SerializedProperty objectProp;

	Transform selectedTransform;

	BuildingObject buildingObject;
	BuildingObjectsDatabase database;

	void OnEnable (){
		buildingObject = (BuildingObject) target;

		objectProp = serializedObject.FindProperty("objects");

		if(!buildingObject.IsObjectSet()){
			buildingObject.SetObject(DatabaseLoader.LoadDatabase<BuildingObjectsDatabase>());
			if(buildingObject.GetObject() != null){
				Debug.Log("BuildingObjectsDatabase loaded");
			}else{
				Debug.Log("BuildingObjectsDatabase not loaded");
				return;
			}
		}

		database = buildingObject.GetObject();

		selectedTransform = Selection.activeTransform;
		if(selectedTransform.GetComponent<DrawGizmo>() != null)
			selectedTransform.GetComponent<DrawGizmo>().modelType = DrawGizmo.ModelType.Building;
	}

	public override void OnInspectorGUI(){
		serializedObject.Update();

		EditorGUILayout.PropertyField(objectProp);

		GUILayout.Label("Models");
		HashSet<Object>.Enumerator enu = database.objects.GetEnumerator();
		bool hasNext = enu.MoveNext();
		while(hasNext){
			GUILayout.BeginHorizontal();
			for(int i = 0; i < 3 && hasNext; i++){
				Object obj = enu.Current;
				hasNext = enu.MoveNext();
				if(GUILayout.Button(obj.name)){

					foreach(Transform child in selectedTransform){
						DestroyImmediate(child.gameObject);
					}

					GameObject newObj = PrefabUtility.InstantiatePrefab(obj) as GameObject;
					newObj.transform.parent = selectedTransform;
					newObj.transform.position = selectedTransform.position;

					serializedObject.ApplyModifiedProperties();
				}
			}
			GUILayout.EndHorizontal();
		}
	}

}
