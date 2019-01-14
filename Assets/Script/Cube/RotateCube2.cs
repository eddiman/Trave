using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cube;
using UnityEngine.Experimental.U2D;
using UnityEngine.Experimental.UIElements;

public class RotateCube2: MonoBehaviour {
    private Vector2 _firstPressPos;
    private Vector2 _currentSwipe;
    private float _rotationSpeed = 0.3f;
    private Transform clickedTransform;
    private bool rotating;
    private float angle = 90.0f;
    private float duration = 1.0f;
    private Ray ray;
    RaycastHit hit;
    private int rotateCounter;
    private bool selected;
    private Dictionary<Vector3, int> RotAngleDict;
    private int _currentCubeCode;


    public int correctCubeCode = 123;

    private Camera mainCam;
    float speed = 0.1f;
    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        RotAngleDict= new Dictionary<Vector3, int>();
        RotAngleDict.Add(new Vector3(270, 0, 0), 123);
        RotAngleDict.Add(new Vector3(270, 90, 0), 243);
        RotAngleDict.Add(new Vector3(270, 180, 0), 453);
        RotAngleDict.Add(new Vector3(270, 270, 0), 513);

        //with 2 on top of cube
        RotAngleDict.Add(new Vector3(0, 180, 180), 162);
        RotAngleDict.Add(new Vector3(0, 270, 180), 642);
        RotAngleDict.Add(new Vector3(0, 0, 180), 432);
        RotAngleDict.Add(new Vector3(0, 90, 180), 312);

        //with 6 on top of cube
        RotAngleDict.Add(new Vector3(90, 0, 0), 156);
        RotAngleDict.Add(new Vector3(90, 90, 0), 546);
        RotAngleDict.Add(new Vector3(90, 180, 0), 426);
        RotAngleDict.Add(new Vector3(90, 270, 0), 216);

        //with 5 on top of cube
        RotAngleDict.Add(new Vector3(0, 0, 0), 135);
        RotAngleDict.Add(new Vector3(0, 90, 0), 345);
        RotAngleDict.Add(new Vector3(0, 180, 0), 465);
        RotAngleDict.Add(new Vector3(0,270, 0), 615);
        
        //with 1 on top of cube
        RotAngleDict.Add(new Vector3(0,180, 90), 561);
        RotAngleDict.Add(new Vector3(0,270, 90), 621);
        RotAngleDict.Add(new Vector3(0,0, 90), 231);
        RotAngleDict.Add(new Vector3(0,90, 90), 351);
        
        //with 4 on top of cube
        RotAngleDict.Add(new Vector3(0,180, 270), 264);
        RotAngleDict.Add(new Vector3(0,270, 270), 654);
        RotAngleDict.Add(new Vector3(0,0, 270), 534);
        RotAngleDict.Add(new Vector3(0,90, 270), 324);
        
        _currentCubeCode = CubeFace2.DetectSides(transform.eulerAngles, RotAngleDict);
        ChangeFacingTag();


    }
    private void OnMouseDown()
    {
        selected = true;
        SetClickedTransformed();
    }



    private void OnMouseUp()
    {
        
        RotateOnSwipe();

        selected = false;
    }
    
    private void SetClickedTransformed()
    {
        _firstPressPos = Input.mousePosition;
        if (Physics.Raycast(ray, out hit) && selected)
        {
            clickedTransform = hit.transform;
        }
    }

    private void RotateOnSwipe()
    {
        _currentSwipe = (Vector2) Input.mousePosition - _firstPressPos;
        
        if (_currentSwipe.x > 100 && rotating == false)
        {
            StartCoroutine(RotateAround(Vector3.down, 90.0f, duration, clickedTransform) );
        }

        if (_currentSwipe.x < -100 && rotating == false)
        {
            StartCoroutine(RotateAround(Vector3.up, angle, duration, clickedTransform));
        }

        if (_currentSwipe.y < -100 && rotating == false)
        {
            StartCoroutine(RotateAround(Vector3.right, angle, duration, clickedTransform));
        }

        if (_currentSwipe.y > 100 && rotating == false)
        {
            StartCoroutine(RotateAround(Vector3.left, angle, duration, clickedTransform));
        }
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SetClickedTransformed();
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            SetClickedTransformed();
            

        }
    }
    

    IEnumerator RotateAround(Vector3 axis, float rotAngle, float rotDuration, Transform rotateTransform)
    {
        Transform thisTransform = rotateTransform;
        float elapsed = 0.0f;
        float rotated = 0.0f;

        if (!rotating)
        {
            rotating = true; 

            while (elapsed < rotDuration)
            {
                float step = rotAngle / rotDuration * (Time.deltaTime*2);
                thisTransform.RotateAround(thisTransform.position, axis, step);
                elapsed += (Time.deltaTime*2);
                rotated += step;
                yield return null;
            }

            thisTransform.RotateAround(thisTransform.position, axis, rotAngle - rotated);

        }
        rotating = false;

        _currentCubeCode = CubeFace2.DetectSides(transform.eulerAngles, RotAngleDict);

        ChangeFacingTag();

    }

    void ChangeFacingTag()
    {
        if (_currentCubeCode == correctCubeCode)
        {
            CubeFace2.setObjTagToFacingCam(gameObject, _currentCubeCode, correctCubeCode);
        }
        else
        {
            CubeFace2.setObjTagToNotFacingCam(gameObject, _currentCubeCode, correctCubeCode);

        }
    }
}