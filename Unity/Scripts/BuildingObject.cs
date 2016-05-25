using UnityEngine;
using System.Collections;

[RequireComponent (typeof(DrawGizmo))]
public class BuildingObject : MonoBehaviour {

	[SerializeField]
	private BuildingObjectsDatabase objects;

	public void SetObject(BuildingObjectsDatabase database){
		if(database != null){
			objects = database;
		}
	}

	public bool IsObjectSet(){
		return objects != null;
	}
	
	public BuildingObjectsDatabase GetObject(){
		return objects;
	}
}
