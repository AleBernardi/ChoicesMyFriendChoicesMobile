using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Carregou Script para botões do menu")   ;
    }

    public float velocidadeC1 = 0.2f;
    public float velocidadeC2 = 0.2f;
    public float velocidadeC3 = 0.2f;
    public Vector3 direcaoC1;
    public Vector3 direcaoC2;
    public Vector3 direcaoC3;

    // Update is called once per frame
    void Update()
    {
        carta1.transform.Rotate(direcaoC1 * velocidadeC1);
        carta2.transform.Rotate(direcaoC2 * velocidadeC2);
        carta3.transform.Rotate(direcaoC3 * velocidadeC3);
    }

    public void fecharJogo(){
        Debug.Log ("Fechando o jogo");
        Application.Quit();
    }

    public void abrirJogo(){
        Debug.Log("Carregando cena sobre o jogo");
        SceneManager.LoadScene("Game");
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(y);
    }
    public void abrirSobre(){
        Debug.Log("Carregando cena sobre o jogo");
        SceneManager.LoadScene("Sobre");
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(y);
    }

    public void abrirMenu(){
        Debug.Log("Carregando cena menu o jogo");
        SceneManager.LoadScene("MainMenu");
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(y);
    }

}
