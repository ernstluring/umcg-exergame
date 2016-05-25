#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BuildingObjectsDatabase : ScriptableObject {

	public HashSet<Object> objects = new HashSet<Object>();

	public void FillHashSet(HashSet<Object> value){
		objects = value;
	}
}