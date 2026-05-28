using UnityEngine;
using UnityEngine.Events;

public class SoupManager : MonoBehaviour
{
    private int BowlFullCount = 0;
    public UnityEvent OnComplete;
    
    public void FullBowl()
    {
        BowlFullCount += 1;
        if (BowlFullCount == 3)
        {
            OnComplete.Invoke();
        }
    }
}
