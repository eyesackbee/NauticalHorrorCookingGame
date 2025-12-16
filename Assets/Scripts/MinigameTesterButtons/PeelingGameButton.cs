using UnityEngine;
using UnityEngine.SceneManagement;

public class PeelingGameButton : MonoBehaviour
{
    public void PlayPeelingMinigame()
    {
        SceneManager.LoadSceneAsync("PeelingMinigame");
    }
}
