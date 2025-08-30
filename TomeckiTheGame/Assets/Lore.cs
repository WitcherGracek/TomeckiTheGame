using NUnit.Framework;
using Swinie.Audio;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lore : MonoBehaviour
{
    [System.Serializable]
    struct DialogScene
    {
        [TextArea]
        public string text;
        public GameObject stage;
        public AudioAsset asset;
    }

    [SerializeField] AudioSource defaultMusic;
    [SerializeField] AudioAsset cutsceneMusic;
    [SerializeField] string levelName;

    [SerializeField] List<DialogScene> dialogScenes;
    [SerializeField] AudioSource dialogPlayer;
    [SerializeField] TextMeshProUGUI text;
    int counter = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextStage();
        }
    }
    public void SetUpAndStart()
    {
        defaultMusic.Stop();
        if(cutsceneMusic != null)
            cutsceneMusic.PlayOnSource(defaultMusic);

        dialogScenes[0].stage.SetActive(true);
        text.text = dialogScenes[0].text.ToString();

        if (dialogScenes[0].asset != null)
            dialogScenes[0].asset.PlayOnSource(dialogPlayer);
    }

    public void NextStage()
    {
        
        counter++;

        if(counter == dialogScenes.Count)
        {
            SceneManager.LoadScene(levelName);
            counter = 0;
            return;
        }

        dialogScenes[counter-1].stage.SetActive(false);


        if (dialogScenes[counter].asset != null)
            dialogScenes[counter].asset.PlayOnSource(dialogPlayer);

        dialogScenes[counter].stage.SetActive(true);
        text.text = dialogScenes[counter].text.ToString();
        
    }


}
