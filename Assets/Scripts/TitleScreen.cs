using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private int scene = 1;
    [SerializeField] private CanvasGroup quitButton;
    private bool canQuit = true;
    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }

    private void Start() {
        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            quitButton.alpha = 0;
            canQuit = false;
         };
    }

    public void QuitGame()
    {
        //On Web Player
        if(!canQuit)
        {
            return;
        }
        Application.Quit();
    }
}
