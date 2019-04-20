using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





#region Enums
public enum SceneType
{
	Login = 0,
	Main = 1,
	Book = 2,

}

#endregion



public class SceneHelper
{
	public static SceneType CurrentScene {
		get {
			var scene = GetSceneTypeByScene (SceneManager.GetActiveScene ());
				return scene;
		}
	}


	public static void ReloadCurrentScene (bool doUseFading = true)
	{
		if (doUseFading) {
			SceneFader.instance.LoadSceneWhenFadingComplete (CurrentScene);
		} else {
			SceneManager.LoadScene (CurrentScene.ToString ());
		}
	}


	public static SceneType GetSceneTypeByScene (Scene scene)
	{
		return (SceneType)Enum.Parse (typeof (SceneType), scene.name);
	}

}
