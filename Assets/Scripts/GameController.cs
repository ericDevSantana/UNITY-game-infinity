using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStates
{
    INGAME,
    MAINMENU,
    GAMEOVER,
    SETTINGS,
    SCORE
}

public class GameController : MonoBehaviour
{
    //Game starts in MAINMENU
    private GameStates currentState = GameStates.MAINMENU;

    private SaveBestScore saveBestScore;

    //UI Groups
    public GameObject MainMenu;
    public GameObject Ingame;
    public GameObject GameOver;
    public GameObject Settings;
    public GameObject Score;

    public Text scoreInGame;
    public Text scoreInGameOver;
    public Text bestScoreInGame;

    private float score = 0;

    //Player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        saveBestScore = FindObjectOfType(typeof(SaveBestScore)) as SaveBestScore;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameStates.MAINMENU:
            {
                //Show Menu UI
                Score.SetActive(false);
                MainMenu.SetActive(true);
                //Hide everything else
            }
            break;

            case GameStates.INGAME:
            {
                //Show Gameplay UI
                MainMenu.SetActive(false);
                Score.SetActive(false);
                Ingame.SetActive(true);
                score += Time.deltaTime + 0.01f;
                scoreInGame.text = score.ToString("0.0");
                //Hide everything else
            }
            break;

            case GameStates.GAMEOVER:
            {
                //Show GameOver UI
                Ingame.SetActive(false);
                callScore();
                //Hide everything else
            }
            break;

            case GameStates.SETTINGS:
            {
                //Show settings UI
                //Hide everything else
            }
            break;

            case GameStates.SCORE:
            {
                //Show score UI
                Score.SetActive(true);
                
                if (saveBestScore.loadBestScore() < score)
                {
                    saveBestScore.saveBestScore("Best Score", score);
                }

                scoreInGameOver.text = score.ToString("0.0");
                bestScoreInGame.text = saveBestScore.loadBestScore().ToString("0.0");

                Debug.Log("Score");
                //Hide everything else
            }
            break;
        }
    }

    public GameStates getCurrentGameState()
    {
        return currentState;
    }

    public void callGameStart()
    {
        player.SetActive(true);
        score = 0;

        //player main position
        player.transform.position = new Vector3(0, 3.46f, -4.47f);

        currentState = GameStates.INGAME;
    }

    public void callScore()
    {
        currentState = GameStates.SCORE;
    }

    public void callGameOver()
    {
        currentState = GameStates.GAMEOVER;

        //Get all obstacles in the scene so you can desactivate them when you die
        ObstaclesBehaviour[] obstacles = FindObjectsOfType(typeof(ObstaclesBehaviour)) as ObstaclesBehaviour[];

        foreach (ObstaclesBehaviour o in obstacles)
        {
            o.gameObject.SetActive(false);
        }

        player.SetActive(false);
    }

    public void callMainMenu()
    {
        currentState = GameStates.MAINMENU;
    }
}
