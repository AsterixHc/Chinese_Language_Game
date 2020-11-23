using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{

    public float maxSpeed;
    public Transform player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, maxSpeed * Time.deltaTime );
        }
    }

}
