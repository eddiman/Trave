using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToMainMenu()
	{

		StartCoroutine(waitAndLoadScene());

	}
	
	IEnumerator waitAndLoadScene()
	{
		Fading.BeginFade(1);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("MainMenu");
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
	}
}
