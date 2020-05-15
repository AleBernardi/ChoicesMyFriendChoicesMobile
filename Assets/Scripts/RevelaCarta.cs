using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ColorUtility;

public class RevelaCarta : MonoBehaviour
{
    public GameObject[] cartas;
    public Button[] botoes;
    public Sprite As;
    public Sprite Rainha;
    public Sprite Rei;
    public Sprite Virada;
    public Text texto;
    public Text winnerText;
    public Canvas winnerCanvas;
    public Color corP1;
    public Color corP2;

    private int pontuacaoP1;
    private int pontuacaoP2;    
    private bool flagplayer=true;
    private bool winnerP1=false;
    private bool winnerP2=false;
    private int countRounds = 0;

    public int qtdCartas = 3;
    public int pesoCarta1;
    public int pesoCarta2;
    public int pesoCarta3;
    public int contJogadas;
    public int contRodadas = 0;
    public int[] escolha;
    public int[] baralho;

    private int posAs;
    private int posRei;
    private int posRainha;
    
    // Start is called before the first frame update
    void Start()
    {
        AtualizaPlayer(flagplayer);

        pontuacaoP1=0;
        pontuacaoP2=0;    

        escolha = new int[2];
        baralho = new int[qtdCartas];
        botoes = new Button[qtdCartas];
        cartas = GameObject.FindGameObjectsWithTag("Carta");
        for(int i=0; i<qtdCartas; i++){
            baralho[i] = -1;
        }
        do {
            Random.InitState(System.Environment.TickCount);
            pesoCarta1 = Random.Range(0,qtdCartas);
            pesoCarta2 = Random.Range(0,qtdCartas);
            pesoCarta3 = Random.Range(0,qtdCartas);

            if(baralho[0] == -1){
                baralho[0] = pesoCarta1;
            }
            if(baralho[0] != pesoCarta2 && baralho[1] == -1 && baralho[2] != pesoCarta2){
                baralho[1] = pesoCarta2;
            }
            if(baralho[0] != pesoCarta3 && baralho[1] != pesoCarta3 && baralho[2] == -1){
                baralho[2] = pesoCarta3;
            }
        }while(baralho[0] == -1 || baralho[1] == -1 || baralho[2] == -1);
        for(int x = 0; x < qtdCartas; x++){
            if(baralho[x] == 2){
                posAs = x;
            }
            if(baralho[x] == 1){
                posRei = x;
            }
            if(baralho[x] == 0){
                posRainha = x;
            }
        }  
        for(int k = 0; k < cartas.Length; k++){
            botoes[k] = cartas[k].GetComponent<Button>();
        }   
        for(int j = 0; j < botoes.Length; j++){
            botoes[j].onClick.AddListener(ExecutarAcaoCarta);
        }
        botoes[0].onClick.AddListener(() => ButtonClicked(0));
        botoes[1].onClick.AddListener(() => ButtonClicked(1));
        botoes[2].onClick.AddListener(() => ButtonClicked(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExecutarAcaoCarta(){
        Debug.Log("Clicou em uma carta");
    }

    void ButtonClicked(int botao){
        if(botao == posAs) {
            botoes[botao].image.sprite = As;
            botoes[botao].interactable = false;
            if(flagplayer){
                winnerP1 = true;
            }else{
                winnerP2 = true;
            }
        } 
        if(botao == posRei) {
            botoes[botao].image.sprite = Rei;
            botoes[botao].interactable = false;
            if(flagplayer){
                pontuacaoP1 = 1;
            }else{
                pontuacaoP2 = 1;
            }
        } 
        if(botao == posRainha) {
            botoes[botao].image.sprite = Rainha;
            botoes[botao].interactable = false;
            if(flagplayer){
                //vitoria do oponente
                winnerP2 = true;
            }else{
                //vitoria do oponente
                winnerP1 = true;
            }
        }
        flagplayer = !flagplayer;
        AtualizaPlayer(flagplayer);
        countRounds++;
        if(winnerP1){
            finaliza(1);
        }else if(winnerP2){
            finaliza(2);
        }else if(countRounds>=2){
            if(pontuacaoP1 > pontuacaoP2){
                finaliza(1);
            }else{
                finaliza(2);
            }
            //finaliza o jogo
        }
    }

    void finaliza(int player){
        texto.text = "";
        foreach(Button botaum in botoes)
            botaum.interactable = false;

        switch(player){
            case 1: winnerCanvas.gameObject.SetActive(true);
                    winnerText.text = "<color=#"+ToHtmlStringRGB(corP1)+">Winner winner chicken dinner!\nJogador 1 venceu!!</color>";
                    break;
            case 2: winnerCanvas.gameObject.SetActive(true);
                    winnerText.text = "<color=#"+ToHtmlStringRGB(corP2)+">Winner winner chicken dinner!\nJogador 2 venceu!!</color>";
                    break;
        }
    }

    void AtualizaPlayer(bool flag)
    {
        if(flag){
            //mostra canvas jogador 1
            texto.text = "<color=#"+ToHtmlStringRGB(corP1)+">É a vez do jogador 1!</color>";

            //somar pontuação da carta ao jogador 1 aqui e após click inverte a flag
            //pontuacaoP1 = //valor da carta selecionada
        }else{
            //mostra canvas jogador 2
            texto.text = "<color=#"+ToHtmlStringRGB(corP2)+">É a vez do jogador 2!</color>";

            //somar pontuação da carta ao jogador 2 aqui e após click inverte a flag
            //pontuacaoP2 = //valor da carta selecionada
        }
    }
}
