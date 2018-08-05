using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandom : MonoBehaviour {
	System.Random rnd = new System.Random();
	private Vector3[] randVector;
	private float[] randAngle;

	// Use this for initialization
	void Start()
	{


		randVector = new[] {Vector3.down, Vector3.left, Vector3.up, Vector3.right};
		randAngle = new[] {90.0f, 180.0f, 270.0f};


		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("DirectionalObj"))
		{

			obj.transform.RotateAround(obj.transform.position, randVector[rnd.Next(3)], randAngle[rnd.Next(3)]);
		}
	}






	// Update is called once per frame
	void Update () {
		
	}
}
