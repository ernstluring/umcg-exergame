using UnityEngine;
using System.Collections;

public class DrawGizmo : MonoBehaviour {
	
	public enum ModelType{Building, Trees, Props};
	[HideInInspector]
	public ModelType modelType;

	private Vector3 _offset = new Vector3(-0.5f, -0.5f, -0.5f);

	void OnDrawGizmos () {
		
		switch(modelType){
		case ModelType.Building:
			SetGizmoColor(Color.blue);
			break;
		case ModelType.Trees:
			SetGizmoColor(Color.green);
			break;
		case ModelType.Props:
			SetGizmoColor(Color.magenta);
			break;
		default:
			SetGizmoColor(Color.grey);
			break;
		}

		Gizmos.DrawWireCube(transform.position - _offset, Vector3.one);
	}
	
	private void SetGizmoColor(Color color){
		Gizmos.color = color;
	}
}