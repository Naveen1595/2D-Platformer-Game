using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingFloorController : MonoBehaviour
{
    public float direction = 1;
    public float speed = 2f;

    [SerializeField]
    private string stopper;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(stopper))
        {
            direction = -1f * direction;
        }
    }

    private void FixedUpdate()
    {
        FloorMovement(direction);
    }

    public void FloorMovement(float direction)
    {
        Vector3 position = transform.position;
        position.x = position.x + (1 * direction) * speed * Time.deltaTime;
        transform.position = position;
    }
}
