using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyController : MonoBehaviour
{

    float direction = 1;
    float counter = 0;
    float speed = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PlayerKilledByChomper();
        }
    }

    private void FixedUpdate()
    {
        EnemyMovement(direction);
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 2f)
        {
            direction = -1f * direction;
            counter = 0;
        }

        transformEnemy();
    }

    private void EnemyMovement(float direction)
    {
        Vector3 position = transform.position;
        position.x = position.x + (1* direction) * speed * Time.deltaTime;
        transform.position = position;
    }

    void transformEnemy()
    {
        //scale transform
        Vector3 scale = transform.localScale;       //Rotation of Player
        if (direction < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (direction > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}
