using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPeelingInstructions : MonoBehaviour
{
    public void LoadPeelingInstructions()
    {
        SceneManager.LoadSceneAsync("Peeling instructions");
    }
}
