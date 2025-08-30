using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TomeckiController : MonoBehaviour
{
    public List<GameObject> incomingEnemies;
    int point;
    int ouchMetter;
    public static TomeckiController singleton;
    TomeckiSprite TomeckiSprite;
    TomeckiAudio TomeckiAudio;

    [SerializeField] int maxOuch;
    [SerializeField] int neededPoints;

    [SerializeField] TextMeshProUGUI points;
    [SerializeField] Image wkurwMeter;
    public float deathDistance;
    [SerializeField] int numberLevel;

    private void Awake()
    {
        singleton = GetComponent<TomeckiController>();
        TomeckiSprite = GetComponent<TomeckiSprite>();
        TomeckiAudio = GetComponent<TomeckiAudio>();
    }

    private void Start()
    {
        point = 0;
        ouchMetter = 0;
        PlayerPrefs.SetString("lastLevel",SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            //strzelanie do zdrajców
            CheckIfCorrect(EnemyType.Traitor);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CheckIfCorrect(EnemyType.Villager);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            CheckIfCorrect(EnemyType.Worker);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            CheckIfCorrect(EnemyType.Jews);
        }

        points.text = (neededPoints - point).ToString();
        wkurwMeter.fillAmount = (float)ouchMetter / (float)maxOuch;

        if(point >= neededPoints)
        {
            if(PlayerPrefs.GetInt("level", 1) <= numberLevel + 1)
            {
                PlayerPrefs.SetInt("level", numberLevel + 1);
            }

            SceneManager.LoadScene("Win");
        }

        if(ouchMetter >= maxOuch)
        {
            SceneManager.LoadScene("Death");
        }
    }

    void KillEnemy()
    {
        incomingEnemies[0].GetComponent<Enemy>().DeadAnim();
        incomingEnemies.RemoveAt(0);
        point++;
    }

    void CheckIfCorrect(EnemyType type)
    {
        
        if (incomingEnemies.Count > 0 && incomingEnemies[0].GetComponent<Enemy>().type == type)
        {
            KillEnemy();
        }
        else
        {
            ouchMetter++;
        }
        TomeckiAudio.PlayOnEmptyPlayer(type);
        TomeckiSprite.DoAnimation(type);
    }
}
