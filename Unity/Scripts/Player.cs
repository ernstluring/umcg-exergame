using UnityEngine;
using System.Collections;
[RequireComponent (typeof(CharacterController))]
public class Player : MonoBehaviour {

	public float moveSpeed = 15.0f;
	public float gravity = 9.81f;
	public float friction = 1f;

	private Vector3 input;
	private Vector3 velocity;
	private CharacterController controller;
	private Vector3 curVel = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
		velocity = -transform.TransformDirection(input) * moveSpeed;

		curVel = Vector3.Lerp(curVel, velocity, friction * Time.deltaTime);

		curVel.y -= gravity;

		controller.Move(curVel*Time.deltaTime);
	}
}
