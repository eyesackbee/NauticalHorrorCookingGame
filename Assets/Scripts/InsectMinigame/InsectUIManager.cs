using UnityEngine;
using TMPro;

public class InsectUIManager : MonoBehaviour
{
    public TMP_Text[] bugNumbers;
    private int[] bugScores;
    private int min = 3;
    private int max = 8;
    public GameObject Complete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bugScores = new int[5];
        GenerateScores();
    }

    void GenerateScores()
    {
        for (int i = 0; i < 5; i++)
        {
            int score = Random.Range(min, max);
            bugScores[i] = score;
            bugNumbers[i].text = score.ToString();
        }
    }

  public void UpdatebugScores(int bugIndex)
    {
        bugScores[bugIndex] -= 1;
        if (bugScores[bugIndex] < 0)
        {
            bugScores[bugIndex] = 0;
        }

        bugNumbers[bugIndex].text = bugScores[bugIndex].ToString();
        if (AllCompleted())
        {
            Complete.SetActive(true);
        }
    }


    bool AllCompleted()
    {
        bool complete = true;
        for (int i = 0; i < 5; i++)
        {
            if (bugScores[i] != 0) 
            {
                complete = false;
            }
        }
        return complete;
    }
}
