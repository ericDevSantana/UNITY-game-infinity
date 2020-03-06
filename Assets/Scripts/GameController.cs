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

    //Var type SaveSystem to save or load settings from playerprefs
    public SaveSystem saveSystem;

    //UI Groups
    public GameObject MainMenu;
    public GameObject Ingame;
    public GameObject GameOver;
    public GameObject Settings;
    public GameObject Score;

    //UI Text variables
    public Text scoreInGame;
    public Text scoreInGameOver;
    public Text bestScoreInGame;

    //Score
    private float score = 0;

    //AudioSources to controll and adjust sound settings
    public AudioSource soundEffect;
    public AudioSource soundTrack;

    //Player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        saveSystem = FindObjectOfType(typeof(SaveSystem)) as SaveSystem;

        //Loading from PlayerPrefs the settings value
        soundTrack.volume = PlayerPrefs.GetFloat("Soundtrack Volume");
        soundEffect.volume = PlayerPrefs.GetFloat("Effects Volume");
    }

    // Update is called once per frame
    void Update()
    {
        //Finite-State Machine
        switch (currentState)
        {
            case GameStates.MAINMENU:
            {
                //Show Menu UI
                Score.SetActive(false);
                Settings.SetActive(false);
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
                MainMenu.SetActive(false);
                Settings.SetActive(true);
                //Hide everything else
            }
            break;

            case GameStates.SCORE:
            {
                //Show score UI
                Score.SetActive(true);
                
                if (saveSystem.loadBestScore() < score)
                {
                    saveSystem.saveBestScore("Best Score", score);
                }

                scoreInGameOver.text = score.ToString("0.0");
                bestScoreInGame.text = saveSystem.loadBestScore().ToString("0.0");

                Debug.Log("Score");
                //Hide everything else
            }
            break;
        }
    }

    //Function that give the current state of the finite-state machine
    public GameStates getCurrentGameState()
    {
        return currentState;
    }

    //Update finite state machine to INGAME
    public void callGameStart()
    {
        player.SetActive(true);
        score = 0;

        //player main position
        player.transform.position = new Vector3(0, 3.46f, -4.47f);

        currentState = GameStates.INGAME;
    }

    //Update finite state machine to SCORE
    public void callScore()
    {
        currentState = GameStates.SCORE;
    }

    //Update finite state machine to GAMEOVER
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

    //Update finite state machine to MAINMENU
    public void callMainMenu()
    {
        currentState = GameStates.MAINMENU;
    }

    //Update finite state machine to SETTINGS
    public void callSettings()
    {
        currentState = GameStates.SETTINGS;
    }

    //Function that controls the audio volumes
    public void SoundTrackManager(GameObject button)
    {

        switch (button.name.ToString())
        {
            case "Music Up":
            {
                soundTrack.volume += 0.2f;
                PlayerPrefs.SetFloat("Soundtrack Volume", soundTrack.volume);
                Debug.Log("Music Up");
            }
            break;
            case "Music Down":
            {
                soundTrack.volume -= 0.2f;
                PlayerPrefs.SetFloat("Soundtrack Volume", soundTrack.volume);
            }
            break;
            case "Effects Up":
            {
                soundEffect.volume += 0.2f;
                AudioController.playSound(SoundEffects.HIT);
                PlayerPrefs.SetFloat("Effects Volume", soundEffect.volume);
            }
            break;
            case "Effects Down":
            {
                soundEffect.volume -= 0.2f;
                AudioController.playSound(SoundEffects.HIT);
                PlayerPrefs.SetFloat("Effects Volume", soundEffect.volume);
            }
            break;
        }
    }
}
