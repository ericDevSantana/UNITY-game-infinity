using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    INGAME,
    MAINMENU,
    GAMEOVER,
    SETTINGS
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
                //Hide everything else
            }
            break;

            case GameStates.INGAME:
            {
                //Show Gameplay UI
                //Hide everything else
            }
            break;

            case GameStates.GAMEOVER:
            {
                //Show GameOver UI
                //Hide everything else
            }
            break;

            case GameStates.SETTINGS:
            {
                //Show settings UI
                //Hide everything else
            }
            break;
        }
    }
}
