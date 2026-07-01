using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLadlingInstructions : MonoBehaviour
{
    public void LoadLadleInstructions()
    {
        SceneManager.LoadSceneAsync("Ladling Instructions");
    }
}
