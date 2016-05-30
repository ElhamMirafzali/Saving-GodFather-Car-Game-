using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {

    //public Button[] buttons;
   // public Text GameOverText;
    public Image GameOverImage;
    bool isGameover;
    //private string currentLevel="level_1";

	// Use this for initialization
	void Start () {
        isGameover = false;
	}
	
	// Update is called once per frame
	void Update () {
       
	}


    public void gameOverActivated()
    {
        isGameover = true;
        //GameOverText.gameObject.SetActive(true);
        GameOverImage.gameObject.SetActive(true);

        //foreach (Button button in buttons)
        //{
        //    button.gameObject.SetActive(true);
        //}
    }


    public void goToNextLevel()
    {
        
    }

    public void Play()
    {
        Time.timeScale =1;
        Application.LoadLevel("Level_1");
    }

    public void Menu()
    {
        Time.timeScale = 0;
        Application.LoadLevel("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
