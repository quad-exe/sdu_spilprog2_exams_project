using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void OnQuitButtonClicked()
    {
        Debug.Log("Quit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif
    }


}