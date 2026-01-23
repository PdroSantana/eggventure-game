using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel_LoadNextScene : MonoBehaviour
{



	public int LoadNext(int index)
	{
		SceneManager.LoadScene(index);
		return index;
	}
	
}
