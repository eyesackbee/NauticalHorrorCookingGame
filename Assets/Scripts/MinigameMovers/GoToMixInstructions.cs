using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMixInstructions : MonoBehaviour
{
    public void LoadMixInstructions()
    {
        SceneManager.LoadSceneAsync("Mix and Stir Instructions");
    }
}
