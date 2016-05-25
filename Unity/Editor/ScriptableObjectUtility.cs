using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public static class ScriptableObjectUtility {
	/// <summary>
	//	This makes it easy to create, name and place unique new ScriptableObject asset files.
	/// </summary>

	public static void CreateAsset<T> () where T : ScriptableObject {
		T asset = ScriptableObject.CreateInstance<T>();
		
		string savePath = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (savePath == ""){
			savePath = "Assets";
		} 
		else if (Path.GetExtension (savePath) != ""){
			savePath = savePath.Replace(Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
		}
		
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(savePath + "/" + typeof(T).ToString() + ".asset");
		
		AssetDatabase.CreateAsset(asset, assetPathAndName);
		
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
		
		Debug.Log("Created ObjectDatabase");
	}


	/// <summary>
	//	Extending the use of the ScriptableObjectUtility class.
	// 	This function makes it easy to automaticly fill a created ScriptableObject if wanted.
	//
	//	Ernst Luring, 2015
	/// </summary>

	public static HashSet<Object> FillAsset(string path) {
		string[] allAssetPaths;
		List<string> correctPaths = new List<string>();
		HashSet<Object> objects = new HashSet<Object>();

		allAssetPaths = AssetDatabase.GetAllAssetPaths();

		if(path == null){
			Debug.Log("No path is set!");
			return null;
		}

		foreach(string paths in allAssetPaths){

			if(paths.Contains(path) && paths.Contains(".prefab")){
				correctPaths.Add(paths);
			}
		}
		
		foreach(string s in correctPaths){
			Object resource = AssetDatabase.LoadMainAssetAtPath(s);
			
			if(!objects.Contains(resource)){
				objects.Add(resource);
			}
		}
		Debug.Log("Created ObjectDatabase");
		return objects;
	}
}