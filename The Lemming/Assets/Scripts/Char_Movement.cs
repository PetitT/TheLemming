using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Movement : MonoBehaviour
{
    public float moveSpeed;
    public Transform BottomLeft, TopRight; 

    private void Update()
    {
        Move();
        Clamp();
    }

    private void Clamp()
    {
        float XPos = transform.position.x;
        float YPos = transform.position.y;

        if (XPos > TopRight.position.x)
            XPos = TopRight.position.x;
        if (XPos < BottomLeft.position.x)
            XPos = BottomLeft.position.x;

        if (YPos > TopRight.position.y)
            YPos = TopRight.position.y;
        if (YPos < BottomLeft.position.y)
            YPos = BottomLeft.position.y;

        transform.position = new Vector2(XPos, YPos);
    }

    private void Move()
    {
        float XMove = Input.GetAxis("Horizontal");
        float YMove = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(XMove, YMove);

        gameObject.transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
