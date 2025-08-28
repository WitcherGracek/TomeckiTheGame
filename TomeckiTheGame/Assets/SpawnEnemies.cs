using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] float spawnTime;
    float timer;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnPosition;
    [SerializeField] float enemySpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if(timer >= spawnTime)
        {
            var x = Instantiate(enemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
            x.GetComponent<Enemy>().speed = enemySpeed; 
            TomeckiController.singleton.incomingEnemies.Add(x);

            timer = 0;
        }
    }
}
