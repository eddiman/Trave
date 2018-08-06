using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
	private Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			
			Debug.Log(hit.collider.gameObject.name);
			if(hit.collider.gameObject.name == "PlayBtn" && Input.GetMouseButtonDown(0))
			{
				StartCoroutine(waitAndLoadScene());
				
			}
		}
		
		
	}

	IEnumerator waitAndLoadScene()
	{
		Fading.BeginFade(1);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("scene" + "1");
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
	}
}
