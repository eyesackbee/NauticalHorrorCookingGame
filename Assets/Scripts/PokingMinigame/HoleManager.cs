using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public List<GameObject> Holes;
    public float OnTime;
    public float OffTime;
    int HoleNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShowHole());
    }

    IEnumerator ShowHole()
    {
        HoleNumber=Random.Range(0, Holes.Count);
        Holes[HoleNumber].GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(OnTime);
        StartCoroutine(HideHole());

    } 

    IEnumerator HideHole()
    {
        Holes[HoleNumber].GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(OffTime);
        StartCoroutine(ShowHole());
    }

    public void RemoveHole()
    {
        Holes.RemoveAt(HoleNumber);
        StopAllCoroutines();
        Invoke("Delay", OffTime);
    }

    void Delay()
    {
        StartCoroutine(ShowHole());
    }
}
