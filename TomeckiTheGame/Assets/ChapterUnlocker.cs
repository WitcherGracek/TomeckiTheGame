using UnityEngine;
using UnityEngine.UI;

public class ChapterUnlocker : MonoBehaviour
{
    Button button;
    [SerializeField] Image locIcon;
    [SerializeField] int chapterRestriction;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("level",1) >= chapterRestriction)
        {
            button.interactable = true;
            locIcon.gameObject.SetActive(false);
        }
        else
        {
            button.interactable = false;
            locIcon.gameObject.SetActive(true);
        }
    }
}
