using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorBehaviour : MonoBehaviour
{
    public float moveSpeed;
    private Transform deactivator;

    private float currentMoveSpeed;

    private void Start()
    {
        deactivator = DecorManager.instance.decorDeactivator;

        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.left * currentMoveSpeed * Time.deltaTime);

        if(transform.position.x < deactivator.position.x)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetNewSpeed(float speed)
    {
        currentMoveSpeed = moveSpeed + speed;
    }
}
