using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] float spawnTimeDecrease;
    [SerializeField] float spawnTimeLimit;
    float timer;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnPosition;
    [SerializeField] float enemySpeed;

    [SerializeField] float enemySpeedIncrease;
    [SerializeField] float enemySpeedLimit;

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

            if (enemySpeed < enemySpeedLimit)
                enemySpeed += enemySpeedIncrease;
            if (spawnTime > spawnTimeLimit)
                spawnTime -= spawnTimeDecrease;

            timer = 0;
        }
    }
}
