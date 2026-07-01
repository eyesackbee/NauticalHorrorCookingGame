using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEnd : MonoBehaviour
{
    public void LoadEnds()
    {
        SceneManager.LoadSceneAsync("Ending Screen");
    }
}
