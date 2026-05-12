using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionText : MonoBehaviour
{
    public Text Intro1;


    void Start()
    {
        Invoke("Intro1", 0.5f);

    }

    
}
