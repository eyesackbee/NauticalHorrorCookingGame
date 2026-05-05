using UnityEngine;
using UnityEngine.Events;

public class ActionMarker : MonoBehaviour
{
    public DragAndDrop ladle;
    public UnityEvent PassedThrough;

    private void OnTriggerExit2D(Collider2D collision)
    {
        PassedThrough.Invoke();
        if(collision.CompareTag("Mix"))
        {
            ladle.canLadle = false;
            ladle.Reset();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mix"))
        {
            ladle.canLadle = true;
        }
    }
}
