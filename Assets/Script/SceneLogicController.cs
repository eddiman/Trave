using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLogicController : MonoBehaviour
{
    private GameObject[] FacingCamObjs;
    private GameObject[] NotFacingCamObjs;

    private Text debugFacingCamObj;
	
    public static bool LevelIsDone = true;
	
    //Debug flags
    public static bool DebugRandomRotateIsOn = false;

    public static bool DebugMode = true;
	

    void Start()
    {
	
        //Debug
        debugFacingCamObj = GameObject.Find("Debug_ObjFacingCam").GetComponent<Text>();
    }

    void Update()
    {
        FacingCamObjs = GameObject.FindGameObjectsWithTag("FacingCam");
        NotFacingCamObjs = GameObject.FindGameObjectsWithTag("NotFacingCam");

        //DEBUG
        if (DebugMode)
        {
            debugFacingCamObj.text = "dbg: " + FacingCamObjs.Length + " / " + (FacingCamObjs.Length + NotFacingCamObjs.Length) +
                                     " facing cam";
}

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