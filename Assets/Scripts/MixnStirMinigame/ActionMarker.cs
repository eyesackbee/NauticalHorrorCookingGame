using UnityEngine;
using UnityEngine.Events;

public class ActionMarker : MonoBehaviour
{
    public UnityEvent PassedThrough;

    private void OnTriggerExit2D(Collider2D collision)
    {
        PassedThrough.Invoke();
    }
}
