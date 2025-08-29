using UnityEngine;

public class TomeckiSprite : MonoBehaviour
{
    [SerializeField] Sprite traitor;
    [SerializeField] Sprite villager;
    [SerializeField] Sprite worker;
    [SerializeField] Sprite jew;
    [SerializeField] Sprite defaultSprite;

    float timer;
    [SerializeField] float animationChangeTime;
    bool isAnimationRunning;

    SpriteRenderer tomeckiRenderer;

    private void Awake()
    {
        tomeckiRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        isAnimationRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimationRunning)
        {
            timer += 1 * Time.deltaTime;

            if(timer >= animationChangeTime)
            {
                tomeckiRenderer.sprite = defaultSprite;
                timer = 0;
                isAnimationRunning=false;
            }
        }
    }

    public void DoAnimation(EnemyType type)
    {
        if(type == EnemyType.Traitor)
        {
            tomeckiRenderer.sprite = traitor;
        }else if(type == EnemyType.Villager)
        {
            tomeckiRenderer.sprite = villager;
        }else if(type == EnemyType.Worker)
        {
            tomeckiRenderer.sprite= worker;
        }else if(type == EnemyType.Jews)
        {
            tomeckiRenderer.sprite = jew;
        }
        timer = 0;
        isAnimationRunning = true;
    }
}
