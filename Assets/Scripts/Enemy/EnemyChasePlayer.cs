using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    #region EnemyStats
    private int attack = 5;
    private int health = 20;

    public int Attack { get => attack; set => attack = value; }
    public int Health { get => health; set => health = value; }
    #endregion
    public float maxSpeed;
    public Transform player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, maxSpeed * Time.deltaTime );
        }
    }

    public void TakeDamage(int PlayerDamage)
    {
        health -= PlayerDamage;
        if (health <= 0)
        {
            Destroy(this);
        }
    }
}
