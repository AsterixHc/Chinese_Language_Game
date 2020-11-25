using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerStateType playerState;
    [SerializeField]
    private BoxSentenceMatchCombinations SentenceBool;

    private RayDetection rayDetection;

    private int health = 100;
    private int attack = 10;

    private void Awake()
    {
        rayDetection = GetComponent<RayDetection>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.playerState += SetMyPlayerState;
    }

    // Update is called once per frame
    void Update()
    {
        RayCheck();
    }

    private void RayCheck()
    {
        GameObject LeftGameObject = rayDetection.RayHitGameObjectLeft;
        GameObject RightGameObject = rayDetection.RayHitGameObjectRight;

        if (LeftGameObject != null || RightGameObject != null)
        {
            if (LeftGameObject.tag == "Door")
            {
                if(LeftGameObject.GetComponent<DoorMechanic>().DoorUnlocked == true)
                {
                    LeftGameObject.GetComponent<DoorMechanic>().UnlockDoor();
                }
            }
            else if(RightGameObject.tag == "Door")
            {
                if (RightGameObject.GetComponent<DoorMechanic>().DoorUnlocked == true)
                {
                    RightGameObject.GetComponent<DoorMechanic>().UnlockDoor();
                }
            }
        }
    }

    private void SetMyPlayerState(PlayerStateType _playerState)
    {
        playerState = _playerState;
    }

    public void TakeDamage(int EnemyDamage)
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
        else if(collision.gameObject.tag == "Door")
        {
            if(playerState == PlayerStateType.døreSlårJeg)
            {
                TakeDamage(collision.gameObject.GetComponent<DoorMechanic>().DoorDamage);
            }
        }
    }
}
