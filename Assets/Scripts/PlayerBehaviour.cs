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
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameController.getCurrentGameState() == GameStates.INGAME)
        {
            if (x > 1000) { x = 0; }
            x += Time.deltaTime * factor;
            transform.rotation = Quaternion.Euler(x, 0, 0);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().AddForce(-speed, 0, 0, ForceMode.Impulse);
                //gameObject.transform.position = new Vector3();
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().AddForce(+speed, 0, 0, ForceMode.Impulse);
            }
        }

        if(gameObject.transform.position.y <= 2.5f)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameController.callGameOver();
            Debug.Log("GameOver");
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Street")
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameController.callGameOver();
            Debug.Log("GameOver");
        }
    }
}
