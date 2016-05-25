using UnityEngine;
using UnityEditor;
using System.Collections;

public class GiveParent : ScriptableWizard {

	public GameObject[] objects = new GameObject[0];
	public string parentName;
	
	[MenuItem("Tools/Give Parent")]

	private static void CreateWizard(){
		ScriptableWizard.DisplayWizard("Give objects parent", typeof(GiveParent), "Give Parent and Close", "Give Parent");
	}

	private void OnWizardCreate(){
		if(errorString != ""){
			return;
		}

		CreateParent();
	}

	private void OnWizardOtherButton(){
		if(errorString != ""){
			return;
		}
		CreateParent();
		objects = null;
		parentName = null;
	}

	private void CreateParent(){
		GameObject parentObj = new GameObject(parentName);
		parentObj.transform.parent = objects[0].transform.parent;

		foreach(GameObject obj in objects){
			obj.transform.parent = parentObj.transform;
		}
	}

	private void OnWizardUpdate(){
		errorString = "";

		if(objects.Length <= 0)
			errorString += "No objects to give parent.\n";
		if(parentName == null)
			errorString += "No name for parent assigned.";
	}
}
