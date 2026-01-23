using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartResetLevelForExpo : MonoBehaviour
{
    [SerializeField]public GameObject player,triggers,Logo,mainCam;

    // Start is called before the first frame update
    void Awake()
    {
        mainCam.GetComponent<NewCameraBehaviour>().enabled = false;
        player.GetComponent<EggControl>().enabled = false;
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space") == true)
        {
            mainCam.GetComponent<NewCameraBehaviour>().enabled = true;
            player.GetComponent<EggControl>().enabled = true;
            Logo.SetActive(false);
        }
        if(Input.GetKeyDown("r") == true)
		{
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(0);
		}
    }
    public void ResetGame()
	{
        SceneManager.LoadScene(0);
    }
}
