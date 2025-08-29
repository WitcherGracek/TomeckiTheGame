using NUnit.Framework;
using Swinie.Audio;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [System.Serializable]
    struct DialogScene
    {
        [TextArea]
        public string text;
        public GameObject stage;
        public AudioAsset asset;
    }

    [SerializeField] List<DialogScene> dialogScenes;
    [SerializeField] AudioSource dialogPlayer;
    [SerializeField] TextMeshProUGUI text;
    int counter = 0;
    [SerializeField] GameObject tutorialPanel;

    public void SetUpAndStart()
    {
        tutorialPanel.SetActive(true);
        dialogScenes[0].stage.SetActive(true);
        text.text = dialogScenes[0].text.ToString();

        if (dialogScenes[0].asset != null)
            dialogScenes[0].asset.PlayOnSource(dialogPlayer);
    }

    public void NextStage()
    {
        dialogScenes[counter].stage.SetActive(false);
        counter++;

        if(counter == dialogScenes.Count)
        {
            tutorialPanel.SetActive(false);
            dialogPlayer.Stop();
            counter = 0;
        }


        if (dialogScenes[counter].asset != null)
            dialogScenes[counter].asset.PlayOnSource(dialogPlayer);

        dialogScenes[counter].stage.SetActive(true);
        text.text = dialogScenes[counter].text.ToString();
        
    }


}
