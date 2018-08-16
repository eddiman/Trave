using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class DetermineDirection : MonoBehaviour
{
    private GameObject ControlObj;
    private GameObject NextSceneButton;
    public GameObject CheckBtn;
	
	
    public GameObject[] DirectionalObjs;

    private Camera mainCam;
    List<GameObject> FacingObjects = new List<GameObject>();
    List<GameObject> NotFacingObjects = new List<GameObject>();
    private Text doneText;


    // Use this for initialization
    void Start () {
        ControlObj = GameObject.Find("Control");
        NextSceneButton = GameObject.Find("NextSceneBtn");
        CheckBtn = GameObject.Find("CheckBtn");
        doneText = GameObject.Find("DoneText").GetComponent<Text>();
        DirectionalObjs = GameObject.FindGameObjectsWithTag("DirectionalObj");

        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        NextSceneButton.SetActive(false);
        SceneLogicController.LevelIsDone = false;
    }

    private void Update()
    {
        if (SceneLogicController.LevelIsDone)
        {
            NextSceneButton.SetActive(true);
            CheckBtn.SetActive(false);
        } else
        {
            NextSceneButton.SetActive(false);
            CheckBtn.SetActive(true);
        }
    }

    public void CheckAllDirections()
    {
        SetDirections();
        CheckIfDirectionsAreTrue();
    }



    private void SetDirections()
    {
        //Debug.Log("clicked");
        FacingObjects = null;
        NotFacingObjects = null;

        foreach (GameObject obj in DirectionalObjs)
        {
            if (IsLookingAtObject(obj.transform, ControlObj.transform.position, 90))
            {
                obj.GetComponent<IsFacingControl>().FacingControl = true;

            }
            else
            {
                obj.GetComponent<IsFacingControl>().FacingControl = false;

            }
	
        }


		
    }
    
    private void CheckIfDirectionsAreTrue()
    {
        int NoOfObjsFacingControl = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("DirectionalObj"))
        {
            if (obj.GetComponent<IsFacingControl>().FacingControl)
            {

                NoOfObjsFacingControl++;

            }
            if (NoOfObjsFacingControl == DirectionalObjs.Length)
            {
                Debug.Log("ALL is facing control unit");
                doneText.text= "Level is done!";
                SceneLogicController.LevelIsDone = true;
            }
            else
            {
                doneText.text= "Not yet finished";
                new WaitForSeconds(1);
                SceneLogicController.LevelIsDone = false;
            
            }
        }
    }

    bool IsLookingAtObject(Transform looker, Vector3 targetPos, float FOVAngle)
    {
        // FOVAngle has to be less than 180
        float checkAngle = Mathf.Min(FOVAngle,359.9999f) / 2; // divide by 2 isn't necessary, just a bit easier to understand when looking at the angles.
     
        float dot = Vector3.Dot(looker.forward, (targetPos - looker.position).normalized); // credit to fafase for this
     
        float viewAngle = (1 - dot) * 180; // convert the dot product value into a 180 degree representation (or *180 if you don't divide by 2 earlier)
             
        if (viewAngle <= checkAngle)
            return true;
        else
            return false;
    }
    
    bool IsLookingAtObject2(Transform looker, Vector3 targetPos, float FOVAngle)
    {
      
             
        if (Vector3.Dot(looker.transform.forward, mainCam.transform.position - looker.transform.position) > 0)
            return true;
        else
            return false;
    }


    
}