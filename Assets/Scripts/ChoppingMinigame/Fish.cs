using System.Collections;
using UnityEngine;
using UnityEngine.Events;



public class Fish : MonoBehaviour
{
    private Animator animator;
    public AudioClip StabSound;
    public UnityEvent OnClick;
    public UnityEvent OnClickFirst;
    private AudioSource audio;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    animator.SetTrigger("Kill");
        //}
    }

    private void OnMouseDown()
    {
        StartCoroutine(DelayInvoke());
        animator.SetTrigger("Kill");
        audio.clip = StabSound;
        audio.loop = false;
        audio.Play();
    }

    IEnumerator DelayInvoke()
    {
        OnClickFirst.Invoke();
        yield return new WaitForSeconds(1f);
        OnClick.Invoke();
    }
}
