using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [Header("MainMenu Controller")]
    [SerializeField] private GameObject startingSelectedButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameModeMenu;
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private GameObject gameCredtisUI;
    private GameObject player;
    
    // Update is called once per frame
    void Awake()
    {
		if (GameObject.FindGameObjectWithTag("Player"))
		{
            player = GameObject.FindGameObjectWithTag("Player");
		}
        startingSelectedButton.GetComponent<Button>().Select();
        DontDestroyOnLoad(this.gameObject);
    }
	private void FixedUpdate()
	{
		if (player.gameObject.GetComponent<EggControl>().IsInTheEnd())
		{
            SceneManager.LoadScene(2);
        }
	}
    public void PauseGame()
	{
        GameObject.FindGameObjectWithTag("PauseMenu").SetActive(true);
        GameObject.FindGameObjectWithTag("First").GetComponent<Button>().Select();
	}
    public void ResumeGame()
	{
        GameObject.FindGameObjectWithTag("PauseMenu").SetActive(false);
        GameObject.FindGameObjectWithTag("OptionMenu").SetActive(false);
    }
	public void MenuChanging(int index)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (index == 1)
            {
                //Loads Game Scene
                SceneManager.LoadScene(1);
            }
            if (index == 2)
            {
                //Opens Options
                mainMenu.SetActive(false);
                optionsMenuUI.SetActive(true);
                startingSelectedButton.GetComponent<Button>().Select();
            }
            if (index == -2)
            {
                //Returns to Home closing Options
                gameCredtisUI.SetActive(false);
                optionsMenuUI.SetActive(false);
                mainMenu.SetActive(true);
                startingSelectedButton.GetComponent<Button>().Select();

            }
            if (index == 3)
            {
                gameCredtisUI.SetActive(true);
                optionsMenuUI.SetActive(false);
                mainMenu.SetActive(false);
                startingSelectedButton.GetComponent<Button>().Select();

            }
            if (index == 0)
            {
                //Exit game
                Application.Quit();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
		{
            if (index == 1)
            {
                //Pauses Game

                mainMenu.SetActive(false);
                optionsMenuUI.SetActive(true);
                startingSelectedButton.GetComponent<Button>().Select();

            }
            if (index == 2)
            {
                //Opens Options
                mainMenu.SetActive(false);
                optionsMenuUI.SetActive(true);
                startingSelectedButton.GetComponent<Button>().Select();
            }
            if (index == -2)
            {
                //Returns to Home closing Options
                gameCredtisUI.SetActive(false);
                optionsMenuUI.SetActive(false);
                mainMenu.SetActive(true);
                startingSelectedButton.GetComponent<Button>().Select();

            }
            if (index == 3)
            {
                gameCredtisUI.SetActive(true);
                optionsMenuUI.SetActive(false);
                mainMenu.SetActive(false);
                startingSelectedButton.GetComponent<Button>().Select();

            }
            if (index == -3)
            {
                SceneManager.LoadScene(2);

            }
            if (index == -4)
            {
                SceneManager.LoadScene(0);
            }
            if (index == 0)
            {
                //Main Menu
                Application.Quit();
            }
        }
    }
}
