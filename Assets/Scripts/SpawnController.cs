using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public int maxSpawnWalls;

    public float rateSpawnWalls;

    private float currentSpawnWalls;

    public GameObject obstaclesWalls;

    public List<GameObject> wallsPrefab;

    public float minSpaceBetweenWalls;
    public float maxSpaceBetweenWalls;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        for (int i = 0; i < maxSpawnWalls; i++)
        {
            GameObject tempWall = Instantiate(obstaclesWalls) as GameObject;
            wallsPrefab.Add(tempWall);
            tempWall.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.getCurrentGameState() == GameStates.INGAME)
        {
            currentSpawnWalls += Time.deltaTime;

            if (currentSpawnWalls > rateSpawnWalls)
            {
                currentSpawnWalls = 0;
                SpawnWalls();
            }
        }
        }

    private void SpawnWalls()
    {

        float spaceBetweenWalls = Random.Range(minSpaceBetweenWalls, maxSpaceBetweenWalls);

        GameObject tempWall = null;

        for (int i = 0; i < maxSpawnWalls; i++)
        {
            if (wallsPrefab[i].activeSelf == false)
            {
                tempWall = wallsPrefab[i];
                break;
            }
        }

        if (tempWall != null)
        {
            tempWall.transform.position = new Vector3(spaceBetweenWalls, transform.position.y , transform.position.z);
            tempWall.SetActive(true);
        }

    }
}
