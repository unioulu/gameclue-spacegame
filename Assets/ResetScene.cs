using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    public void ResetLastScene()
    {
        SceneManager.LoadScene(MutationManager.MutationName());
        Debug.Log(MutationManager.MutationName());
    }
}
