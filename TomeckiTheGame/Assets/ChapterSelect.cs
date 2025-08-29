using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ChapterSelect : MonoBehaviour
{
    [SerializeField] List<GameObject> chapters;

    public void SelectChapter(int id)
    {
        chapters[id].SetActive(true);
        chapters[id].GetComponent<Lore>().SetUpAndStart();
    }
}
