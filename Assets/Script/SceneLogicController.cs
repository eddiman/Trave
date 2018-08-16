using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLogicController : MonoBehaviour
{
	private GameObject[] FacingCamObjs;
	private GameObject[] NotFacingCamObjs;

	public static bool LevelIsDone = true;
	
	//Debug flags
	public static bool randomRotateIsOn = true;
	

	void Start()
	{
		
	}

	void Update()
	{
		FacingCamObjs = GameObject.FindGameObjectsWithTag("FacingCam");
		NotFacingCamObjs = GameObject.FindGameObjectsWithTag("NotFacingCam");


		if (FacingCamObjs.Length == (FacingCamObjs.Length + NotFacingCamObjs.Length))
		{
			LevelIsDone = true;
		}
		else
		{
			LevelIsDone = false;
		}
	}
	
	
	
}
