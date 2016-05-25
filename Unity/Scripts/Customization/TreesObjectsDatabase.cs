using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;
using System.Collections.Generic;

public class TreesObjectsDatabase : ScriptableObject{
	public List<Object> objects = new List<Object>();
	
	private string[] _allAssetPaths;
	private List<string> _correctPaths = new List<string>();
	private string _path = "Assets/Prefabs/Flora";

#if UNITY_EDITOR
	void OnEnable(){
		
		_allAssetPaths = AssetDatabase.GetAllAssetPaths();
		Debug.Log("onenable");
		if(_path == null){
			Debug.Log("No path is set!"); 
			return;
		}
		
		foreach(string paths in _allAssetPaths){
			if(paths.Contains(_path) && paths.Contains(".prefab")){
				_correctPaths.Add(paths);
			}
		}
		
		foreach(string s in _correctPaths){
			Object resource = AssetDatabase.LoadMainAssetAtPath(s);
			
			if(!objects.Contains(resource)){
				objects.Add(resource);
			}
		}
		
	}
#endif
	
}