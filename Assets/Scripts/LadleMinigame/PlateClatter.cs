using UnityEngine;

public class PlateClatter : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip[] clips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (!audio.isPlaying)
        {
            int index = Random.Range(0, clips.Length);
            audio.clip = clips[index];
            audio.Play();
        }
    }
}
