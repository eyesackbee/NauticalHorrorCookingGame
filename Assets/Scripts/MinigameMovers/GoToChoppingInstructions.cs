using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToChoppingInstructions : MonoBehaviour
{
    public void LoadChoppingInstructions()
    {
        SceneManager.LoadSceneAsync("Chopping Instructions");
    }
}
