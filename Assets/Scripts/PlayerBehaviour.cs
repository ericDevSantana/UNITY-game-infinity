using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private GameController gameController;

    public float speed;
    public float x = 0;
    public float factor;

    // Start is called before the first frame update
    void Start()
    {
        //Accessing GameController script via var
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Only perform movements when in the Game State INGAME
        if (gameController.getCurrentGameState() == GameStates.INGAME)
        {
            //Player rotation...var factor control the speed of the rotation to match the texture offset
            // x resets itself after 1000 otherwise would increase with no limitations
            if (x > 1000) { x = 0; }

            x += Time.deltaTime * factor;
            transform.rotation = Quaternion.Euler(x, 0, 0);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //applying negative force on axis X to move to the left...force type IMPULSE
                gameObject.GetComponent<Rigidbody>().AddForce(-speed, 0, 0, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //applying positive force on axis X to move to the right...force type IMPULSE
                gameObject.GetComponent<Rigidbody>().AddForce( speed, 0, 0, ForceMode.Impulse);
            }
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        // If the player hits anything besides the street, it's game over
        if (collision.gameObject.name != "Street")
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameController.callGameOver();
            Debug.Log("GameOver");
        }
    }
}
