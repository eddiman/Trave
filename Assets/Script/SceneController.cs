using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	private GameObject NextSceneButton;
	private GameObject MenuContainer;

	
	// Use this for initialization
	void Start () {
		//NextSceneButton = GameObject.Find("NextSceneBtn");
		}
	
	// Update is called once per frame
	void Update () {
		
		/*if (SceneLogicController.LevelIsDone)
		{
			NextSceneButton.SetActive(true);
		} else
		{
			NextSceneButton.SetActive(false);
		}*/
		
	}

	public void GoToMainMenu()
	{
		SceneLogicController.DebugRandomRotateIsOn = false;

		StartCoroutine(waitAndLoadScene());

	}
	
	IEnumerator waitAndLoadScene()
	{
		Fading.BeginFade(1);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("MainMenu");
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
	}


	public void RestartScene()
	{
		SceneLogicController.DebugRandomRotateIsOn = true;

		StartCoroutine(waitAndRestartScene());
	}
	
	public void GoToScene(int sceneNr)
	{

		StartCoroutine(waitAndLoadScene(sceneNr));

	}
	
	
	IEnumerator waitAndLoadScene(int sceneNr)
	{
		Fading.BeginFade(1);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("scene" + sceneNr);
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
	}
	
	IEnumerator waitAndRestartScene()
	{
		Fading.BeginFade(1);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	
}
