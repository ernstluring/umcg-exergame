using UnityEngine;
using UnityEditor;
using System.Collections;

public class ReplaceGameObjects : ScriptableWizard {

	public bool isNewObjectPrefab = true;
	public bool copyVales = true;
	public GameObject newObject;
	public GameObject[] oldObjects;

	[MenuItem("Tools/Replace GameObjects")]

	static void CreateWizard(){
		ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace and Close", "Replace");
	}

	private void OnWizardCreate(){
		if(errorString != "")
			return;
		Replace();
	}

	private void OnWizardOtherButton(){
		if(errorString != "")
			return;
		Replace();
		newObject = null;
		oldObjects = null;
	}

	private void OnWizardUpdate(){
		errorString = "";
		isValid = true;

		if (oldObjects == null){
			errorString += "Assign the old objects, so they can be replaced\n";
			isValid = false;
		}

		if (newObject == null){
			errorString += "What is the new / replacement object?";
			isValid = false;
		}
	}

	private void Replace(){
		foreach (GameObject g in oldObjects){
			GameObject obj;
			if(isNewObjectPrefab){
				obj = (GameObject)PrefabUtility.InstantiatePrefab(newObject);
			}else{
				obj = Instantiate(newObject);
				obj.name = newObject.name;
			}
			if(copyVales){
				obj.transform.position = g.transform.position;
				obj.transform.rotation = g.transform.rotation;
				obj.transform.parent = g.transform.parent;
			}
			
			Undo.RegisterCreatedObjectUndo(obj, "Replaced objects");
			Undo.DestroyObjectImmediate(g);
		}
	}
}
