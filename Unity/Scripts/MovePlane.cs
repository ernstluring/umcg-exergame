using UnityEngine;
using System.Collections;

public class MovePlane : MonoBehaviour {

	public float speed = 2f;

	public enum Direction{
		XAxis,
		ZAxis
	}

	public Direction moveDirection;

	// Update is called once per frame
	void Update () {

		switch(moveDirection){
		case Direction.ZAxis:
			Move (Vector3.forward);
			break;
		case Direction.XAxis:
			Move (Vector3.left);
			break;
		}
	}

	private void Move(Vector3 direction){
		transform.Translate(direction * speed * Time.deltaTime, Space.Self);
	}
}
