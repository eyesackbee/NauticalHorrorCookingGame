using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public GameObject[] Instructions;
    public float DisplayTime;
    public float DelayTime;
    private int index = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DisplayText());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(DelayTime);
        Instructions[index].gameObject.SetActive(true);

        yield return new WaitForSeconds(DisplayTime);
        Instructions[index].gameObject.SetActive(false);
        index += 1;
        if (index == Instructions.Length)
        {
            SceneManager.LoadScene("Bug Catching Instructions");
        }
        StartCoroutine(DisplayText());
    }
}
