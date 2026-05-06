using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bits"))
        {
            anim.SetTrigger("Splash");
            Destroy(collision.gameObject);        }
    }

}
