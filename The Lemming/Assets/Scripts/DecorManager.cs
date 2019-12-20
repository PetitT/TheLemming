using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorManager : MonoBehaviour
{
    public static DecorManager instance;

    public Transform decorDeactivator;
    public Transform topSpawn, bottomSpawn;
    public GameObject decorParent;

    public List<GameObject> decorList = new List<GameObject>();
    public List<GameObject> obstacleList = new List<GameObject>();

    public SceneMovement sceneMovement;
    public Vector2 timeBetweenDecorSpawns;
    public Vector2 minTimeBetweenDecorSpawns;
    public Vector2 timeBetweenObstacleSpawns;
    public Vector2 minTimeBetweenObstacleSpawns;
    public float decorSpawnBoost;
    public float obstacleSpawnBoost;
    public float sceneMovementBoost;
    private float remainingTimeForDecor;
    private float remainingTimeForObstacle;

    public float speedBoostPerSec;
    private float speedBoostTimer = 1f;
    private float currentSpeedBoost;

    public event Action<float> onBoost;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        ResetObstacleTimer();
        ResetDecorTimer();
    }

    private void Update()
    {
        DecorCountdown();
        ObstacleCountdown();
        IncreaseSpeed();
    }

    private void IncreaseSpeed()
    {
        speedBoostTimer -= Time.deltaTime;
        if (speedBoostTimer < 0)
        {
            speedBoostTimer = 1;
            currentSpeedBoost += speedBoostPerSec;
            onBoost?.Invoke(currentSpeedBoost);
            UpdateSpawns();
        }
    }

    private void DecorCountdown()
    {
        remainingTimeForDecor -= Time.deltaTime;
        if (remainingTimeForDecor < 0)
        {
            AddNewDecor(DecorPool.instance.decorPool, decorList);
            ResetDecorTimer();
        }
    }

    private void ObstacleCountdown()
    {
        remainingTimeForObstacle -= Time.deltaTime;
        if (remainingTimeForObstacle < 0)
        {
            AddNewDecor(DecorPool.instance.obstaclePool, obstacleList);
            ResetObstacleTimer();
        }
    }

    private void AddNewDecor(List<GameObject> listFromPool, List<GameObject> listToTake)
    {
        int index = UnityEngine.Random.Range(0, listToTake.Count);
        float YPos = UnityEngine.Random.Range(bottomSpawn.position.y, topSpawn.position.y);

        GameObject newDecor = DecorPool.instance.GetObjectFromPool(listFromPool, listToTake[index], listToTake[index].ToString(), new Vector3(topSpawn.position.x, YPos, topSpawn.position.z + 1));
        newDecor.transform.SetParent(decorParent.transform);
        newDecor.GetComponent<DecorBehaviour>().SetNewSpeed(currentSpeedBoost);
    }

    private void ResetDecorTimer()
    {
        remainingTimeForDecor = UnityEngine.Random.Range(timeBetweenDecorSpawns.x, timeBetweenDecorSpawns.y);
    }

    private void ResetObstacleTimer()
    {
        remainingTimeForObstacle = UnityEngine.Random.Range(timeBetweenObstacleSpawns.x, timeBetweenObstacleSpawns.y);
    }

    private void UpdateSpawns()
    {
        if (timeBetweenDecorSpawns.x > minTimeBetweenDecorSpawns.x)
            timeBetweenDecorSpawns.x -= decorSpawnBoost;

        if (timeBetweenDecorSpawns.y > minTimeBetweenDecorSpawns.y)
            timeBetweenDecorSpawns.y -= decorSpawnBoost;

        if (timeBetweenObstacleSpawns.x > minTimeBetweenObstacleSpawns.x)
            timeBetweenObstacleSpawns.x -= obstacleSpawnBoost;

        if (timeBetweenObstacleSpawns.y > minTimeBetweenObstacleSpawns.y)
            timeBetweenObstacleSpawns.y -= obstacleSpawnBoost;

        sceneMovement.speed += sceneMovementBoost;
    }
}
