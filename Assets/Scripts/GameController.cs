using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //UI Groups
    public GameObject MainMenu;
    public GameObject Ingame;
    public GameObject GameOver;
    public GameObject Settings;
    public GameObject Score;

    //Player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameStates.MAINMENU:
            {
                //Show Menu UI
                MainMenu.SetActive(true);
                //Hide everything else
            }
            break;

            case GameStates.INGAME:
            {
                //Show Gameplay UI
                MainMenu.SetActive(false);
                Score.SetActive(false);
                //Hide everything else
            }
            break;

            case GameStates.GAMEOVER:
            {
                //Show GameOver UI
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
        player.transform.position = new Vector3(0, 3.46f, -4.47f);

        //Store all obstacles in a list so you can desactivate them when you die
        ObstaclesBehaviour[] obstacles = FindObjectsOfType(typeof(ObstaclesBehaviour)) as ObstaclesBehaviour[];

        foreach (ObstaclesBehaviour o in obstacles)
        {
            o.gameObject.SetActive(false);
        }

        currentState = GameStates.INGAME;
    }

    public void callScore()
    {
        currentState = GameStates.SCORE;
    }

    public void callGameOver()
    {
        currentState = GameStates.GAMEOVER;
        player.SetActive(false);
    }
}
