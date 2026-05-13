using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLadlingGame : MonoBehaviour
{
    public void LoadLadlingGame()
    {
        SceneManager.LoadSceneAsync("LadlingMinigame");
    }
}
