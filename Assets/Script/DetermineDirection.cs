using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetermineDirection : MonoBehaviour
{
    private GameObject ControlObj;
    public Button CheckBtn;
	
	
    public GameObject[] DirectionalObjs;
	
    List<GameObject> FacingObjects = new List<GameObject>();
    List<GameObject> NotFacingObjects = new List<GameObject>();
    private Text doneText;
	
	
    // Use this for initialization
    void Start () {
        ControlObj = GameObject.Find("Control");
        doneText = GameObject.Find("DoneText").GetComponent<Text>();

        CheckBtn.onClick.AddListener(CheckAllDirections);
		
        DirectionalObjs = GameObject.FindGameObjectsWithTag("DirectionalObj");
		
    }

    private void CheckAllDirections()
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
                doneText.text= "Done!";
            }
            else
            {
                doneText.text= "Still missing some.";
            
            }
        }
    }

    bool IsLookingAtObject(Transform looker, Vector3 targetPos, float FOVAngle)
    {
        // FOVAngle has to be less than 180
        float checkAngle = Mathf.Min(FOVAngle,359.9999f) / 2; // divide by 2 isn't necessary, just a bit easier to understand when looking at the angles.
     
        float dot = Vector3.Dot(looker.forward, (targetPos - looker.position).normalized); // credit to fafase for this
     
        float viewAngle = (1 - dot) * 90; // convert the dot product value into a 180 degree representation (or *180 if you don't divide by 2 earlier)
             
        if (viewAngle <= checkAngle)
            return true;
        else
            return false;
    }
	
}