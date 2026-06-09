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
    private List<SpriteRenderer> fadeObjects;
    public Transform fadeParent;
    //private PlayRandomSound prs;
    public Sequence fadeSequence;


    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        if(fadeParent != null && fadeParent.childCount > 0)
        {
            fadeObjects = new List<SpriteRenderer>();
            for (int i = 0; i < fadeParent.childCount; i++)
            {
                fadeObjects.Add(fadeParent.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
            }
        }
        
    }

    private void FadeOut()
    {
        if (fadeObjects.Count > 0) {
            for (int i = 0; i < fadeObjects.Count; i++)
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
        Debug.Log("length: " + fadeObjects?.Count);
        yield return new WaitForSeconds(0.2f);
        if (fadeObjects?.Count > 0)
        {
            for (int i = 0; i < fadeObjects.Count; i++)
            {
                Debug.Log("fading");
                fadeObjects[i].DOFade(0, 0.5f);
            }
        }
        yield return new WaitForSeconds(delayTime);
        onComplete.Invoke();
    }
}




