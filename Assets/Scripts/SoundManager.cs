using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip[] slices;
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
        int soundIndex = Random.Range(0, slices.Length);
        audio.clip = slices[soundIndex];
        audio.Play();
    }
}
