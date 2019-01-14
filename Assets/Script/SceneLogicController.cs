using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLogicController : MonoBehaviour
{
    private GameObject[] _facingCamObjs;
    private GameObject[] _notFacingCamObjs;

    private Text _debugFacingCamObj;
    private Text _debugSideBtnText;
	
    public static bool LevelIsDone = true;
	
    //Debug flags
    public static bool DebugRandomRotateIsOn = false;

    public static bool DebugMode = false;
	
    private GameObject _nextSceneButton;
    private GameObject[] _debugObjs;


    void Start()
    {
        _nextSceneButton = GameObject.Find("NextSceneBtn");

        //Debug
        _debugFacingCamObj = GameObject.Find("Debug_ObjFacingCam").GetComponent<Text>();
        _debugObjs = GameObject.FindGameObjectsWithTag("DebugObj");

        
        if (DebugMode)
        {

            ActivateDebugObjs();


        }
        else
        {
            DectivateDebugObjs();
        }
    }

    void Update()
    {
        _facingCamObjs = GameObject.FindGameObjectsWithTag("FacingCam");
        _notFacingCamObjs = GameObject.FindGameObjectsWithTag("NotFacingCam");

        //DEBUG
        if (DebugMode)
        {
            _debugFacingCamObj.text = "dbg: " + _facingCamObjs.Length + " / " + (_facingCamObjs.Length + _notFacingCamObjs.Length) +
                                     " facing cam";

        }

        if (_facingCamObjs.Length == (_facingCamObjs.Length + _notFacingCamObjs.Length))
        {
            LevelIsDone = true;
            _nextSceneButton.SetActive(true);

        }
        else
        {
            LevelIsDone = false;
            _nextSceneButton.SetActive(false);

        }
    }

    public void ToggleDebug()
    {
        if (DebugMode)
        {
            DebugMode = false;
        }
        else
        {
            DebugMode = true;
        }
    }
	
    void ActivateDebugObjs()
    {
        for(int i=0; i< _debugObjs.Length; i++)
        {
            var child = _debugObjs[i].gameObject;
            if(child != null)
                child.SetActive(true);
        }
    } 
    
    void DectivateDebugObjs()
    {
        for(int i=0; i< _debugObjs.Length; i++)
        {
            var child = _debugObjs[i].gameObject;
            if(child != null)
                child.SetActive(false);
        }
    }

	
	
}