using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerStateType playerState;
    [SerializeField]
    private BoxSentenceMatchCombinations SentenceBool;

    private int health = 100;
    private int attack = 10;

    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.playerState += SetMyPlayerState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetMyPlayerState(PlayerStateType _playerState)
    {
        playerState = _playerState;
    }

    private void TakeDamage(int EnemyDamage)
    {
        health -= EnemyDamage;
        IsPlayerDead(health);
    }

    public bool IsPlayerDead(int health)
    {
        if(health == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (playerState == PlayerStateType.fjendenSlårJeg)
            {
                TakeDamage(collision.gameObject.GetComponent<EnemyChasePlayer>().Attack);
            }
            else if(playerState == PlayerStateType.jegSlårFjenden)
            {
                collision.gameObject.GetComponent<EnemyChasePlayer>().TakeDamage(attack);
            }
        }
    }
}
