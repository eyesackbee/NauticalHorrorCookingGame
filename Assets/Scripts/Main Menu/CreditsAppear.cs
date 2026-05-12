using UnityEngine;
using UnityEngine.UI;

public class CreditsAppear : MonoBehaviour
{
    public CreditsAppear image;
    void Start()
    {
        image.enabled = false;
    }

    void OnMouseDown()
    {
        image.enabled = true;
       
    }
}
