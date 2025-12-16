using UnityEngine;
using UnityEngine.Rendering;

public class CabbageManager : MonoBehaviour
{
    public Collider2D[] peels;
    private int index = 0;

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
        peels[index].enabled = false;
        index++;
        if(index == peels.Length)
        {
            return;
        }
        peels[index].enabled = true;
    }
}
