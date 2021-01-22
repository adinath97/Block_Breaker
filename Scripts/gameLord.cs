using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLord : MonoBehaviour
{
    public GameObject resultMessage;
    public GameObject StarterImage;
    public GameObject TitleText;
    public GameObject PlayBtnText;
    public GameObject QuitBtnText;
    public GameObject PlayBtn;
    public GameObject QuitBtn;
    public GameObject scoreText;

    public static int blocksDestroyed;
    public static int pointsShowed;
    public static int playPressedNumber;

    public static bool gameStart;
    public static bool gameQuit;
    public static bool gamePause;
    public static bool gameOver;
    public static bool gameWon;
    public static bool gameLost;
    public static bool resetGame;

    // Start is called before the first frame update
    void Start()
    {
        if (playPressedNumber == 0)
        {
            gameLost = false;
            gameStart = false;
            gamePause = false;
            gameOver = false;
            gameWon = false;
            gameLost = false;
            StarterImage.SetActive(true);
            TitleText.GetComponent<Text>().text = "BLOCK BREAKER";
            TitleText.SetActive(true);
            resultMessage.SetActive(false);
            PlayBtnText.GetComponentInChildren<Text>().text = "PLAY GAME";
            PlayBtnText.SetActive(true);
            QuitBtnText.GetComponentInChildren<Text>().text = "QUIT GAME";
            QuitBtnText.SetActive(true);
            PlayBtn.SetActive(true);
            QuitBtn.SetActive(true);
        }
        else if (playPressedNumber >= 2)
        {
            gameWon = false;
            gameLost = false;
            gameOver = false;
            StarterImage.SetActive(false);
            TitleText.SetActive(false);
            PlayBtnText.SetActive(false);
            QuitBtnText.SetActive(false);
            resultMessage.SetActive(false);
            PlayBtn.SetActive(false);
            QuitBtn.SetActive(false);
        }
        scoreText.GetComponent<Text>().text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + blocksDestroyed;

        if(gameStart || resetGame)
        {
            StarterImage.SetActive(false);
            TitleText.SetActive(false);
            PlayBtnText.SetActive(false);
            QuitBtnText.SetActive(false);
            resultMessage.SetActive(false);
            PlayBtn.SetActive(false);
            QuitBtn.SetActive(false);
            resetGame = false;
        }

        if(gamePause)
        {
            Debug.Log("GAME IS PAUSED!!");
        }

        if(blocksDestroyed >= 92)
        {
            gameWon = true;
            gameOver = true;
        }

        if(gameOver && gameWon)
        {
            PlayBtn.SetActive(true);
            QuitBtn.SetActive(true);
            StarterImage.SetActive(true);
            TitleText.GetComponent<Text>().text = "BLOCK BREAKER";
            TitleText.SetActive(true);
            resultMessage.GetComponent<Text>().text = "YOU WIN!";
            resultMessage.SetActive(true);
            PlayBtnText.GetComponentInChildren<Text>().text = "PLAY GAME";
            PlayBtnText.SetActive(true);
            QuitBtnText.GetComponentInChildren<Text>().text = "QUIT GAME";
            QuitBtnText.SetActive(true);
        }

        if (gameOver && gameLost)
        {
            PlayBtn.SetActive(true);
            QuitBtn.SetActive(true);
            StarterImage.SetActive(true);
            TitleText.GetComponent<Text>().text = "BLOCK BREAKER";
            TitleText.SetActive(true);
            resultMessage.GetComponent<Text>().text = "YOU LOSE!";
            resultMessage.SetActive(true);
            PlayBtnText.GetComponentInChildren<Text>().text = "PLAY GAME";
            PlayBtnText.SetActive(true);
            QuitBtnText.GetComponentInChildren<Text>().text = "QUIT GAME";
            QuitBtnText.SetActive(true);
        }
    }
}
