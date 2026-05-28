using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;
using System.Collections;

public class CabbageManager : MonoBehaviour
{
    public Collider2D[] peels;
    private int index = 0;
    public UnityEvent OnComplete;
    bool complete = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in peels)
        {
            item.enabled = false;
        }
        peels[0].enabled = true;
    }

    public void Peeled()
    {
        if (complete) { return; }
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
        OnComplete.Invoke();
    }
}
