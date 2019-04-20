using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ButtonSceneMove : MonoBehaviour {

	// Use this for initialization
	private Button _button;
	public SceneType targetScene;
	void Start ()
	{
		_button = GetComponent<Button>();
		bindView();
	}

	void bindView()
	{
		_button.onClick.AddListener(MoveToScene);
	}

	void MoveToScene()
	{
		SceneFader.instance.LoadSceneWhenFadingComplete(targetScene);
	}

}
