using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;
using System.Collections;
using DG.Tweening;

public class CabbageManager : MonoBehaviour
{
    public Collider2D[] peels;
    private int index = 0;
    public UnityEvent OnComplete;
    bool complete = false;
    public SpriteRenderer baseSprite;
    private AudioSource audio;
    public AudioClip[] PeelSounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in peels)
        {
            item.enabled = false;
        }
        peels[0].enabled = true;
        audio = GetComponent<AudioSource>();
    }

    public void Peeled()
    {
        if (complete) { return; }
        int soundIndex = Random.Range(0, PeelSounds.Length);
        audio.clip = PeelSounds[soundIndex];
        audio.Play();
        peels[index].enabled = false;
        index++;
        if(index == peels.Length)
        {
            complete = true;
            StartCoroutine(Complete());
            return;
        }
        peels[index].enabled = true;
    }

    IEnumerator Complete()
    {
        yield return new WaitForSeconds(1f);
        if (baseSprite != null)
        {
           baseSprite.DOFade(0, 0.5f);
        }
        yield return new WaitForSeconds(1f);
        OnComplete.Invoke();
    }
}
