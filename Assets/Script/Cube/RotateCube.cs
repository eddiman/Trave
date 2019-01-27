using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    public class RotateCube: MonoBehaviour {
        private Vector2 _firstPressPos;
        private Vector2 _currentSwipe;
        private float _rotationSpeed = 0.3f;
        private Transform _clickedTransform;
        private bool _rotating;
        private float angle = 90.0f;
        private float duration = 1.0f;
        private Ray _ray;
        RaycastHit _hit;
        private int _rotateCounter;
        private bool _selected;
        private Dictionary<Vector3, int> _rotAngleDict;
        private int _currentCubeCode;


        //Combination of cubeface sides that is shown on screen. If cube displays this combination of sides on screen
        //it is considered as facing cam.
        public int correctCubeCode = 123;
        
        //Int represents which single side that makes the cube to be correct. As long as this side is shown on screen
        //the cube is considered as facing cam. Overrides the correct cube code combination.
        public int singleCubeFaceNo = 0;
        

        private Camera mainCam;
        float speed = 0.1f;

        void Start()
        {
            mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        
            _rotAngleDict = new Dictionary<Vector3, int>();
            _rotAngleDict.Add(new Vector3(270, 0, 0), 123);
            _rotAngleDict.Add(new Vector3(270, 90, 0), 243);
            _rotAngleDict.Add(new Vector3(270, 180, 0), 453);
            _rotAngleDict.Add(new Vector3(270, 270, 0), 513);

            //with 2 on top of cube
            _rotAngleDict.Add(new Vector3(0, 180, 180), 162);
            _rotAngleDict.Add(new Vector3(0, 270, 180), 642);
            _rotAngleDict.Add(new Vector3(0, 0, 180), 432);
            _rotAngleDict.Add(new Vector3(0, 90, 180), 312);

            //with 6 on top of cube
            _rotAngleDict.Add(new Vector3(90, 0, 0), 156);
            _rotAngleDict.Add(new Vector3(90, 90, 0), 546);
            _rotAngleDict.Add(new Vector3(90, 180, 0), 426);
            _rotAngleDict.Add(new Vector3(90, 270, 0), 216);

            //with 5 on top of cube
            _rotAngleDict.Add(new Vector3(0, 0, 0), 135);
            _rotAngleDict.Add(new Vector3(0, 90, 0), 345);
            _rotAngleDict.Add(new Vector3(0, 180, 0), 465);
            _rotAngleDict.Add(new Vector3(0, 270, 0), 615);

            //with 1 on top of cube
            _rotAngleDict.Add(new Vector3(0, 180, 90), 561);
            _rotAngleDict.Add(new Vector3(0, 270, 90), 621);
            _rotAngleDict.Add(new Vector3(0, 0, 90), 231);
            _rotAngleDict.Add(new Vector3(0, 90, 90), 351);

            //with 4 on top of cube
            _rotAngleDict.Add(new Vector3(0, 180, 270), 264);
            _rotAngleDict.Add(new Vector3(0, 270, 270), 654);
            _rotAngleDict.Add(new Vector3(0, 0, 270), 534);
            _rotAngleDict.Add(new Vector3(0, 90, 270), 324);

            _currentCubeCode = DetectFaces.DetectSides(transform.eulerAngles, _rotAngleDict);
            ChangeFacingTag();


        }

        private void OnMouseDown()
        {
            _selected = true;
            SetClickedTransformed();
        }



        private void OnMouseUp()
        {
        
            RotateOnSwipe();

            _selected = false;
        }
    
        private void SetClickedTransformed()
        {
            _firstPressPos = Input.mousePosition;
            if (Physics.Raycast(_ray, out _hit) && _selected)
            {
                _clickedTransform = _hit.transform;
            }
        }

        private void RotateOnSwipe()
        {
            _currentSwipe = (Vector2) Input.mousePosition - _firstPressPos;
        
            if (_currentSwipe.x > 100 && _rotating == false)
            {
                StartCoroutine(RotateAround(Vector3.down, 90.0f, duration, _clickedTransform) );
            }

            if (_currentSwipe.x < -100 && _rotating == false)
            {
                StartCoroutine(RotateAround(Vector3.up, angle, duration, _clickedTransform));
            }

            if (_currentSwipe.y < -100 && _rotating == false)
            {
                StartCoroutine(RotateAround(Vector3.right, angle, duration, _clickedTransform));
            }

            if (_currentSwipe.y > 100 && _rotating == false)
            {
                StartCoroutine(RotateAround(Vector3.left, angle, duration, _clickedTransform));
            }
        }

        void Update()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
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

            if (!_rotating)
            {
                _rotating = true; 

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
            _rotating = false;

            _currentCubeCode = DetectFaces.DetectSides(transform.eulerAngles, _rotAngleDict);

            ChangeFacingTag();

        }

        private void ChangeFacingTag()
        {
            if (singleCubeFaceNo > 0 && singleCubeFaceNo < 7)
            {
                if (_currentCubeCode.ToString().Contains(singleCubeFaceNo.ToString()))
                {
                    DetectFaces.SetObjTagToFacingCam(gameObject);
                }
                else
                {
                    DetectFaces.SetObjTagToNotFacingCam(gameObject);
                }
            }
            
            else if (_currentCubeCode == correctCubeCode)
            {
                DetectFaces.SetObjTagToFacingCam(gameObject);
            }
            else
            {
                DetectFaces.SetObjTagToNotFacingCam(gameObject);

            }
        }


    }
}