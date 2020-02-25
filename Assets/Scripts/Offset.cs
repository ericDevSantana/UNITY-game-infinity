using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    private Material currentMaterial;

    public float speed = 2;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {

        currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //Modifying texture's offset to give an effect of movement
        offset += 0.001f;
        currentMaterial.SetTextureOffset("_MainTex", new Vector3(0, - offset * (speed + 1), 0));
    }
}
