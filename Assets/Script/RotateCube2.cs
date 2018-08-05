using UnityEngine;
using System.Collections;
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
    
    float speed = 0.1f;
    void Start()
    {
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

    }
}