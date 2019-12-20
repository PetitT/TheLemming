using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosManager : MonoBehaviour
{
    public List<Transform> startPos;

    public static StartPosManager instance;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
}
