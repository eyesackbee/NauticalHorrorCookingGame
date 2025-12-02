using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutManager : MonoBehaviour
{
    public List<GameObject> cutLines;
    public GameObject wholeFruit;
    public GameObject fruitSplit;
    public float delayTime = 2f;
    public Animator animator;
    public UnityEvent onComplete;
    //private PlayRandomSound prs;
    

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
            if(wholeFruit != null)
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

            StartCoroutine(RevealNextFruit());
        }
    }

    IEnumerator RevealNextFruit()
    {
        yield return new WaitForSeconds(delayTime);
        onComplete.Invoke();
    }
}




