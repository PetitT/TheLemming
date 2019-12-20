using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    private Transform startPos;
    public int startPosNumber;

    private void Awake()
    {
        startPos = StartPosManager.instance.startPos[startPosNumber];
        transform.position = startPos.position;
    }

    private void Start()
    {
        transform.position = startPos.position;
    }

    private void OnEnable()
    {
        transform.position = startPos.position;
    }
}
