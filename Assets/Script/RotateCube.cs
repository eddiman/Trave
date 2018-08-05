using UnityEngine;

public class RotateCube : MonoBehaviour {
    float rotationSpeed = 0.2f;

    void OnMouseDrag()
    {
        float xAxisRotation = Input.GetAxis("Mouse X")*rotationSpeed;
        float yAxisRotation = Input.GetAxis("Mouse Y")*rotationSpeed;
        // select the axis by which you want to rotate the GameObject
        transform.RotateAround (Vector3.down, xAxisRotation);
        transform.RotateAround (Vector3.right, yAxisRotation);
    }
}