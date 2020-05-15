using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    void Update() {
        if (GameIsPaused == false) {
            Resume();
        }  
        if (GameIsPaused == true) {
            Pause();
        }
    }

    public void PausarDespausar(){
        GameIsPaused = !GameIsPaused;
    }

    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }



    public void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void Reiniciar() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(y);
    }

    public void abrirMenu(){
        SceneManager.LoadScene("MainMenu");
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(y);
    }

    public void fecharJogo(){
        Application.Quit();
    }

}