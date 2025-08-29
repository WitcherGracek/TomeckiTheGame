using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Tutorial tutorial;

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
       Application.Quit();
    }

    public void RestartLevel()
    {
        string levelName;

        levelName = PlayerPrefs.GetString("lastLevel","0");

        if (levelName == "0")
            SceneManager.LoadScene("MainMenu");

    }

    public void StartTutorial()
    {
        tutorial.SetUpAndStart();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
