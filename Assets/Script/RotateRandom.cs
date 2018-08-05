using UnityEngine;

public class RotateRandom : MonoBehaviour {
	
	
	
	private Vector3[] randVector;
	private float[] randAngle;

	public int TagSelectInt ;
		
	private string[] Tags = {"DirectionalObj", "OtherObject"};

	// Use this for initialization
	void Start()
	{
		System.Random rnd = new System.Random();
		System.Random rnd2 = new System.Random();
		randVector = new[] {Vector3.down, Vector3.left, Vector3.up, Vector3.right};
		randAngle = new[] {90.0f, 180.0f, 270.0f};
		Debug.Log(Tags[TagSelectInt]);

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag(Tags[TagSelectInt]))
		{
			Debug.Log(obj);

			obj.transform.RotateAround(obj.transform.position, randVector[rnd2.Next(3)], randAngle[rnd.Next(3)]);
		}
	}

}
