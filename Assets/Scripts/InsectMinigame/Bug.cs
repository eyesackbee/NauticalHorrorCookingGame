using UnityEngine;

public class Bug : MonoBehaviour
{
    public float TopSpeed;
    public float BottomSpeed;
    private float Speed;
    public int BugNumber;
    private InsectUIManager UIManager;
    private SpawnManager spawnManager;
    [HideInInspector] public float direction;
    [HideInInspector] public bool flipX = false;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = Random.Range(BottomSpeed, TopSpeed);
        //float Rotz = Random.Range(-20f, 20f);
        //float Rotz = transform.eulerAngles.z;
        //if(transform.position.x < 0 && Rotz > 0)
        //{
        //    Rotz *= -1;
        //}
        //else if(transform.position.x > 0 && Rotz > 0)
        //{
        //    Rotz *= -1;
        //}
        //transform.Rotate(0, 0, Rotz);
        UIManager = FindFirstObjectByType<InsectUIManager>();
        spawnManager = FindFirstObjectByType<SpawnManager>();
        spawnManager.PlayBugSound();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Speed*Time.deltaTime, 0, 0);
    }
    public void Flip()
    {
        spriteRenderer.flipX = true;
    }

    private void OnMouseDown()
    {
        UIManager.UpdatebugScores(BugNumber);
        Destroy(gameObject);
        spawnManager.SquishBugSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
            spawnManager.StopBugSound();
        }
    }
}
