using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPeelingGame : MonoBehaviour
{
    public void LoadPeelingGame()
    {
        SceneManager.LoadSceneAsync("PeelingMinigame");
    }

}
