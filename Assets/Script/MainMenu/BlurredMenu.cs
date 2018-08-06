using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredMenu : MonoBehaviour
{

	private bool isDown = false;
	private Vector3 p;

	private int duration = 5;
	// Use this for initialization
	void Start () {
		
		Camera mainCamera= GameObject.Find("Main Camera").GetComponent<Camera>();
		p = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
		Debug.Log(mainCamera);
		Debug.Log(p);

		float height = mainCamera.orthographicSize * 1.0f;
		float width =  height * Screen.width / Screen.height;
		gameObject.transform.localScale = p / 6;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void MoveDown()
	{

		if (!isDown)
		{
			isDown = false;
			transform.Translate(Vector3.back * Time.deltaTime);
			StartCoroutine(Wait(10));
			isDown = true;
		}
		
		
	}
	
	IEnumerator Wait(float delay)
	{
		yield return new WaitForSeconds(delay);
	}
}
