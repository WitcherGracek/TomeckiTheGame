using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public EnemyType type;
    [SerializeField] Sprite traitor;
    [SerializeField] Sprite worker;
    [SerializeField] Sprite jew;
    [SerializeField] Sprite villager;
    [SerializeField] Sprite deadTraitor;
    [SerializeField] Sprite deadWorker;
    [SerializeField] Sprite deadJew;
    [SerializeField] Sprite deadVillager;

    Sprite deadSprite;
    SpriteRenderer enemyRenderer;

    [SerializeField] float deadSpeed;
    float timer;

    bool isDying;

    private void Awake()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        int rng;
        rng = Random.Range(0,4);

        if (rng == 0)
        {
            type = EnemyType.Traitor;
            enemyRenderer.sprite = traitor;
            deadSprite = deadTraitor;
        }
        else if (rng == 1)
        {
            type = EnemyType.Villager;
            enemyRenderer.sprite = villager;
            deadSprite = deadVillager;
        }    
        else if (rng == 2)
        {
            type = EnemyType.Worker;
            enemyRenderer.sprite = worker;
            deadSprite = deadWorker;
        }
        else if (rng == 3)
        {
            type = EnemyType.Jews;
            enemyRenderer.sprite = jew;
            deadSprite = deadJew;
        }
            

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);

        if (isDying)
        {
            timer += 1 * Time.deltaTime;
            if(timer >= deadSpeed)
            {
                Destroy(this.gameObject);
            }
        }
        if(Vector2.Distance(gameObject.transform.position, TomeckiController.singleton.gameObject.transform.position) <= TomeckiController.singleton.deathDistance)
        {
            SceneManager.LoadScene("Death");
        }
    }

    public void DeadAnim()
    {
        isDying = true;
        timer = 0;
        speed = 0;
        enemyRenderer.sprite = deadSprite;
    }
}
public enum EnemyType
{
    Traitor, Villager, Worker, Jews
}
