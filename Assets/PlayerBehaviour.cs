using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerStateType playerState;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bool sentenceBoxCombination = FindObjectOfType<BoxSentenceMatchCombinations>().Referencebool;
        //if(sentenceBoxCombination == true && FindObjectOfType<BoxSentenceMatchCombinations>().SkaderFjender == true)
        //{
        //    if(collision.gameObject.tag == "Enemy")
        //    {

        //    }
        //}
    }
}
