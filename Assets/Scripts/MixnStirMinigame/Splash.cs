using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bits"))
        {
            anim.SetTrigger("Splash");
            Destroy(collision.gameObject);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            
        }
    }

}
