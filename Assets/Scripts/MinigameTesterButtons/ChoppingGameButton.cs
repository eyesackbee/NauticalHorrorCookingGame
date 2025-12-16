using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoppingGameButton : MonoBehaviour
{
    public void PlayChopMinigame()
    {
        SceneManager.LoadSceneAsync("ChoppingMinigame");
    }
}
