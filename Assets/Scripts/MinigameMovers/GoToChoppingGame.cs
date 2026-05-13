using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToChoppingGame : MonoBehaviour
{
    public void LoadChoppingGame()
    {
        SceneManager.LoadSceneAsync("ChoppingMinigame");
    }

}
