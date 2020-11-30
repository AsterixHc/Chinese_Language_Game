using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateRemoval : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour playerState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerState.playerState == PlayerStateType.MeAttackEnemey)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
