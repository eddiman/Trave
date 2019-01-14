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
		_menuContainer = GameObject.Find("Menu Container");
		
		SetUiElementToScreenWidth(_nextSceneButton);
		SetUiElementToScreenWidth(_menuContainer);
		
		//_nextSceneButton.SetActive(false);
		_menuContainer.SetActive(false);

		
	}

	void SetUiElementToScreenWidth(GameObject gameObject)
	{
		var gameObjectRectTrans = gameObject.transform as RectTransform;

			gameObjectRectTrans.sizeDelta = new Vector2(Screen.width, gameObjectRectTrans.sizeDelta.y);
	}
}
