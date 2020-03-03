using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehaviour : MonoBehaviour
{
    public float speed;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        //Accessing GameController script via var
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.getCurrentGameState() == GameStates.INGAME)
        {
            //Making obstacles come towards the player incrementing its position with negative AXIS Z value
            transform.position += new Vector3(0, 0, -(speed + Time.deltaTime));
        }

        //After that point in z axis...deactivate obstacles
        //Obstacles passed the player and camera position
        if(transform.position.z < -13)
        {
            gameObject.SetActive(false);
        }
    }
}
