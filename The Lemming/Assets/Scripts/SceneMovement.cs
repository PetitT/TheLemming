using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : MonoBehaviour
{
    public List<GameObject> movingObjects;
    public float speed;

    private void Update()
    {
        MoveScene();
    }

    private void MoveScene()
    {
        foreach (var obj in movingObjects)
        {
            obj.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
