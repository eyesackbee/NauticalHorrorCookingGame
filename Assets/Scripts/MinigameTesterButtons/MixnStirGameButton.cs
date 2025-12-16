using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void PlayMixStirMinigame()
    {
        SceneManager.LoadSceneAsync("MixnStirMinigame");
    }
}
