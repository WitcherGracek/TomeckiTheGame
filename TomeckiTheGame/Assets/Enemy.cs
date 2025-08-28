using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public EnemyType type;

    private void Start()
    {
        int rng;
        rng = Random.Range(0,4);

        if (rng == 0)
            type = EnemyType.Traitor;
        else if (rng == 1)
            type = EnemyType.Villager;
        else if (rng == 2)
            type = EnemyType.Worker;
        else if (rng == 3)
            type = EnemyType.Jews;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }
}
public enum EnemyType
{
    Traitor, Villager, Worker, Jews
}
