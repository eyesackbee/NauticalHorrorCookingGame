using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMixnStirGame : MonoBehaviour
{
    public void LoadCookingGame()
    {
        SceneManager.LoadSceneAsync("MixnStirMinigame");
    }
}
