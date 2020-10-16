using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGroundController : MonoBehaviour
{
    float direction = 1;
    float speed = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MovingGround"))
        {
            direction = -1f * direction;
        }
    }

    private void Update()
    {
        FloorMovement(direction);
    }

    private void FloorMovement(float direction)
    {
        Vector3 position = transform.position;
        position.x = position.x + (1 * direction) * speed * Time.deltaTime;
        transform.position = position;
    }

}
