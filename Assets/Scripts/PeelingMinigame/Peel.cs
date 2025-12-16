using UnityEngine;

public class Peel : MonoBehaviour
{
    private Animator animator;
    public CabbageManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("Peel");
        manager.Peeled();
    }

}
