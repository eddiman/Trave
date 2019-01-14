using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour {
	private GameObject _nextSceneButton;
	private GameObject _menuContainer;

	
	// Use this for initialization
	void Start () {
		_nextSceneButton = GameObject.Find("NextSceneBtn");
		var nextSceneButtonRectTrans = _nextSceneButton.transform as RectTransform;
		nextSceneButtonRectTrans.sizeDelta = new Vector2 (Screen.width, nextSceneButtonRectTrans.sizeDelta.y);
		
		
		
		_menuContainer = GameObject.Find("Menu Container");
		
		
		var menuContainerRectTrans = _menuContainer.transform as RectTransform;
		menuContainerRectTrans.sizeDelta = new Vector2 (Screen.width, menuContainerRectTrans.sizeDelta.y);
		_menuContainer.SetActive(false);
		
	}
}
