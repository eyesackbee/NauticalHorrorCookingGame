using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToInsectGame : MonoBehaviour
{
    public void LoadInsectGame()
    {
        SceneManager.LoadSceneAsync("BugCatchingMinigame");
    }

}
