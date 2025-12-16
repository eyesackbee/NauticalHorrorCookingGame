using UnityEngine;
using UnityEngine.SceneManagement;

public class InsectGameButton : MonoBehaviour
{
    public void PlayInsectMinigame()
    {
        SceneManager.LoadSceneAsync("BugCatchingMinigame");
    }
}
