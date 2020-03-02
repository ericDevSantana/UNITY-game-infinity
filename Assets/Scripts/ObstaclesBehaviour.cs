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
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.getCurrentGameState() == GameStates.INGAME)
        {
            transform.position += new Vector3(0, 0, -(speed + Time.deltaTime));
        }

        if(transform.position.z < -13)
        {
            gameObject.SetActive(false);
        }
    }
}
