using System.Collections.Generic;
using UnityEngine;

public class TomeckiController : MonoBehaviour
{
    public List<GameObject> incomingEnemies;
    int point;
    int ouchMetter;
    public static TomeckiController singleton;

    private void Awake()
    {
        singleton = GetComponent<TomeckiController>();
    }

    private void Start()
    {
        point = 0;
        ouchMetter = 0;
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
    }

    void KillEnemy()
    {
        Destroy(incomingEnemies[incomingEnemies.Count - 1]);
        incomingEnemies.RemoveAt(incomingEnemies.Count - 1);
        point++;
    }

    void CheckIfCorrect(EnemyType type)
    {
        
        if (incomingEnemies.Count > 0 && incomingEnemies[incomingEnemies.Count - 1].GetComponent<Enemy>().type == type)
        {
            KillEnemy();
        }
        else
        {
            ouchMetter++;
        }
    }
}
