using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Tutorial tutorial;
    [SerializeField] GameObject chapterSelectMenu;
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

        SceneManager.LoadScene(levelName);

    }

    public void StartTutorial()
    {
        tutorial.SetUpAndStart();
    }

    public void OpenChapterSelect()
    {
        chapterSelectMenu.SetActive(true);
    }

    public void CloseChapterSelect()
    {
        chapterSelectMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
