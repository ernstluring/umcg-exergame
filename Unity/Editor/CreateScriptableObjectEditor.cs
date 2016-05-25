using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateScriptableObjectEditor {

	[MenuItem ("Assets/Create/PathsDatabase")]
	public static void CreatePathDatabase () {
		ScriptableObjectUtility.CreateAsset<PathsDatabase>();
	}
	
	[MenuItem ("Assets/Create/BuildingDatabase")]
	public static void CreateBuildingScriptableObject () {
		ScriptableObjectUtility.CreateAsset<BuildingObjectsDatabase>();
	}

	[MenuItem ("Assets/Create/TreesDatabase")]
	public static void CreateTreesScriptableObject () {
		ScriptableObjectUtility.CreateAsset<TreesObjectsDatabase>();
	}
}