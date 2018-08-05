using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeScaler : MonoBehaviour
{

	private float mSize;

	public float StepSecond;
	private bool increasing;
	private bool decreasing;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("Scale", 0.0f, StepSecond);
	}

	void Scale()
	{

		if (mSize <= 0)
		{
			increasing = true;
			decreasing = false;
		}
		
		if (mSize >= 100.0f)
		{
			increasing = false;
			decreasing = true;
		}

		if (increasing)
		{
			GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize++);
		}
		
		if (decreasing)
		{
			GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize--);
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
