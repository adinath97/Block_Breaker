using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void PlayPressed()
    {
        gameLord.blocksDestroyed = 0;
        gameLord.playPressedNumber++;
        gameLord.gameStart = true;
        if(gameLord.gamePause)
        {
            gameLord.gamePause = false;
        }
        SceneManager.LoadScene("Game");
        gameLord.resetGame = true;
    }

    public void PausePressed()
    {
        gameLord.gamePause = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
