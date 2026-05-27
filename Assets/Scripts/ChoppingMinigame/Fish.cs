using System.Collections;
using UnityEngine;
using UnityEngine.Events;



public class Fish : MonoBehaviour
{
    private Animator animator;
    public UnityEvent OnClick;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
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
    }

    IEnumerator DelayInvoke()
    {
        yield return new WaitForSeconds(1);
        OnClick.Invoke();
    }
}
