using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public float x = 0;
    public float factor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (x > 1000) { x = 0; }
        x += Time.deltaTime * factor;
        transform.rotation = Quaternion.Euler(x,0,0);

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
}
