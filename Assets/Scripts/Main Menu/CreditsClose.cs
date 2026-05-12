using UnityEngine;
using UnityEngine.UI;

public class CreditsClose : MonoBehaviour
{
    public CreditsClose image;
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        image.enabled = false;

    }
}
