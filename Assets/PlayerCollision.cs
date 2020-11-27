using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverScript gameOverScript;

    void OnCollisionEnter(Collision collisionInfo)
    {
        //UnityEngine.Debug.Log(collisionInfo.collider.name);
        gameOverScript.GameOver();
    }
}
