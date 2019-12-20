using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBlanket : MonoBehaviour
{
    public float baseSpeed = 1;
    private float speed;
    public Transform left, right;

    private void Start()
    {
        DecorManager.instance.onBoost += BoostHandler;
    }

    private void BoostHandler(float obj)
    {
        speed = obj + baseSpeed;
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (gameObject.transform.position.x < left.position.x)
        {
            float XPos = right.transform.position.x;
            gameObject.transform.position = new Vector2(XPos, transform.position.y);
        }
    }
}
