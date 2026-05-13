using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip slice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slice()
    {
        audio.clip = slice;
        audio.Play();
    }
}
