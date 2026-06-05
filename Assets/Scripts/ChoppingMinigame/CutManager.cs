using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CutManager : MonoBehaviour
{
    public List<GameObject> cutLines;
    public GameObject wholeFruit;
    public GameObject fruitSplit;
    public float delayTime = 2f;
    public Animator animator;
    public UnityEvent onComplete;
    private SoundManager soundManager;
    public SpriteRenderer[] fadeObjects;
    //private PlayRandomSound prs;
    public Sequence fadeSequence;


    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();

    }

    private void FadeOut()
    {
        if (fadeObjects.Length > 0) {
            for (int i = 0; i < fadeObjects.Length; i++)
            {
                fadeObjects[i].DOFade(0, delayTime / 2f);
            }
        }

        StartCoroutine(RevealNextFruit());
    }

    public void RemoveCutLine(GameObject cutLine)
    {
        //prs = GetComponent<PlayRandomSound>();
        //if (prs != null)
        //{
        //    prs.PlaySound();

        //}
        cutLines.Remove(cutLine);
        if (cutLines.Count == 0)
        {
            if (wholeFruit != null)
            {
                wholeFruit.SetActive(false);
            }
            if(fruitSplit != null) 
            {
                fruitSplit.SetActive(true);

            }
            if (animator != null)
            {
                animator.SetTrigger("Slice");
                
            }
            soundManager.Slice();
            StartCoroutine(RevealNextFruit());
        }
    }

    IEnumerator RevealNextFruit()
    {
        Debug.Log("coroutine entered");
        Debug.Log("length: " + fadeObjects.Length);
        yield return new WaitForSeconds(0.2f);
        if (fadeObjects.Length > 0)
        {
            for (int i = 0; i < fadeObjects.Length; i++)
            {
                Debug.Log("fading");
                fadeObjects[i].DOFade(0, 0.5f);
            }
        }
        yield return new WaitForSeconds(delayTime);
        onComplete.Invoke();
    }
}




