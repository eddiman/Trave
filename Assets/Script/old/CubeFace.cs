using System;
using System.Linq;
using UnityEngine;


public class CubeFace : MonoBehaviour {
    [SerializeField] float threshHold = 90.0f;
    [SerializeField] float rayLength = 100.0f;
    private Camera mainCam;

    public bool IsFacingLeftAngleX;
    public bool IsFacingDownAngleY;
    public bool IsFacingBackwardAngleZ;

    public bool IsFacingRightAngleMinusX;
    public bool IsFacingUpAngleMinusY;
    public bool IsFacingForwardAngleMinusZ;


    private bool SideOne;
    private bool SideTwo;
    private bool SideThree;
    private bool SideFour;
    private bool SideFive;
    private bool SideSix;

    public bool AllowDebugRay;
    
    private bool[] facingDirections;
    public bool[] facingSides;

    private Vector3[] randVector;
    private float[] randAngle;

    
    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        
        DetectWhichSidesAreSelected();
        RotateCube();
        AllowDebugRay = false;
    }

    void DetectWhichSidesAreSelected()
    {

        facingSides = new[]
        {
            SideOne, SideTwo, SideThree, SideFour, SideFive, SideSix
        };
        
        facingDirections = new[]
        {
            IsFacingLeftAngleX, IsFacingDownAngleY, IsFacingBackwardAngleZ, IsFacingRightAngleMinusX, IsFacingUpAngleMinusY, IsFacingForwardAngleMinusZ 
        };

    }

    void RotateCube()
    {
        if (SceneLogicController.DebugRandomRotateIsOn)
        {
            System.Random rnd = new System.Random();
            System.Random rnd2 = new System.Random();
            Vector3[] randVector = new[] {Vector3.down, Vector3.left, Vector3.up, Vector3.right};
            float[] randAngle = new[] {90.0f, 180.0f, 270.0f};

         

                transform.RotateAround(transform.position, randVector[rnd2.Next(3)], randAngle[rnd.Next(3)]);
            
        }
    }
    /*
     * for obj in game
     *     piece.direction = randomDirection 
     */

    void Update() {
        // theta = arcos( a • b / |a| • |b|)
        float upAngle = Mathf.Acos(Vector3.Dot(transform.up, mainCam.transform.forward) / (transform.up.magnitude * mainCam.transform.forward.magnitude));
        upAngle *= 180.0f / Mathf.PI; // In Degrees not radians.
 
        float downAngleY = Mathf.Acos(Vector3.Dot(-transform.up, mainCam.transform.forward) / (transform.up.magnitude * mainCam.transform.forward.magnitude));
        downAngleY *= 180.0f / Mathf.PI; // In Degrees not radians.
 
        float forwardAngle = Mathf.Acos(Vector3.Dot(transform.forward, mainCam.transform.forward) / (transform.forward.magnitude * mainCam.transform.forward.magnitude));
        forwardAngle *= 180.0f / Mathf.PI; // In Degrees not radians.
        
        float backwardAngleZ = Mathf.Acos(Vector3.Dot(-transform.forward, mainCam.transform.forward) / (transform.forward.magnitude * mainCam.transform.forward.magnitude));
        backwardAngleZ *= 180.0f / Mathf.PI; // In Degrees not radians.

        float rightAngle = Mathf.Acos(Vector3.Dot(transform.right, mainCam.transform.forward) / (transform.right.magnitude * mainCam.transform.forward.magnitude));
        rightAngle *= 180.0f / Mathf.PI; // In Degrees not radians.

        float leftAngleX = Mathf.Acos(Vector3.Dot(-transform.right, mainCam.transform.forward) / (transform.right.magnitude * mainCam.transform.forward.magnitude));
        leftAngleX *= 180.0f / Mathf.PI; // In Degrees not radians.
 
        //X PLUS AXIS
        if (IsFacingLeftAngleX)
        {
            if (leftAngleX < threshHold)
            
            {
                facingSides[0] = true;
                if (SceneLogicController.DebugMode && AllowDebugRay)
                {
                    Debug.DrawRay(transform.position, transform.right * rayLength, Color.yellow);
                }
                
            }
            else
            {
                facingSides[0] = false;
            }
            
        }

        if (IsFacingDownAngleY)
        {
            if (downAngleY < threshHold)

            {
                facingSides[1] = true;
                if (SceneLogicController.DebugMode && AllowDebugRay)
                {
                    Debug.DrawRay(transform.position, transform.up * rayLength, Color.red);
                }
            }
            else
            {
                facingSides[1] = false;
            }
        }



        if (IsFacingBackwardAngleZ)
        {
            if (backwardAngleZ < threshHold)
            {
                facingSides[2] = true;
                if (SceneLogicController.DebugMode && AllowDebugRay)
                {
                    Debug.DrawRay(transform.position, transform.forward * rayLength, Color.blue);
                }
            }
            else
            {
                facingSides[2] = false;
            }
        }



        //MINUS SIDES, X Y Z RESPECTIVELY
        if (IsFacingRightAngleMinusX)
        {
            if (rightAngle < threshHold)
            {
                facingSides[3] = true;
                if (SceneLogicController.DebugMode && AllowDebugRay)
                {
                    Debug.DrawRay(transform.position, -transform.right * rayLength, Color.black);
                }
            }
            else
            {
                facingSides[3] = false;
            }
        }


        if (IsFacingUpAngleMinusY)
        {
            if (upAngle < threshHold)
            {
                facingSides[4] = true;

                if (SceneLogicController.DebugMode && AllowDebugRay)
                {
                    Debug.DrawRay(transform.position, -transform.up * rayLength, Color.magenta);
                }

            }
            else
            {
                facingSides[4] = false;
            }
        }


        if (IsFacingForwardAngleMinusZ)
        {
            if(forwardAngle < threshHold) 
            {
                facingSides[5] = true;

                if (SceneLogicController.DebugMode && AllowDebugRay)
                {
                    Debug.DrawRay(transform.position, -transform.forward * rayLength, Color.cyan);
                }

            }
            else
            {
                facingSides[5] = false;
            }

        }
        
        
        if ( Enumerable.SequenceEqual(facingSides, facingDirections))
        {
            gameObject.tag = "FacingCam";

        }
        else
        {
            gameObject.tag = "NotFacingCam";


        }
        
        
        

        

        
    }
}