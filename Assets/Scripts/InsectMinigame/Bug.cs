using UnityEngine;

public class Bug : MonoBehaviour
{
    public float TopSpeed;
    public float BottomSpeed;
    private float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = Random.Range(BottomSpeed, TopSpeed);
        float Rotz = Random.Range(-20f, 20f);
        transform.Rotate(0, 0, Rotz);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Speed*Time.deltaTime, 0, 0);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
