using UnityEngine;
using System.Collections;

public static class DatabaseLoader {
	public static T LoadDatabase<T> () where T : ScriptableObject{
		T[] resource = Resources.LoadAll<T>(@"Databases");

		if(resource.Length == 1){
			return resource[0] as T;
		}else if(resource.Length < 1){
			Debug.Log("There are no databases found, create one in the resources folder");
			return null;
		}else{
			Debug.Log("There are "+resource.Length+" of the same databases in the resources folder, there can only be one.");
			return null;
		}
	}
}
