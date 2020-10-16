using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyController : MonoBehaviour
{

    float direction = 1;
    float counter;
    float speed = 3f;

    [SerializeField]
    private string Stopper;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PlayerKilledByChomper();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Stopper))
        {
            direction = -1f * direction;
        }
    }
    private void FixedUpdate()
    {
        EnemyMovement(direction);
    }

    private void Update()
    {

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
        Vector3 scale = transform.localScale;       //Rotation of Enemy
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
