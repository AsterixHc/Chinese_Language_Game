using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderColorChange : MonoBehaviour
{

    public Material material;
    public string typeOfWordBox;
    public Color colorChangeOnHit;

    private Vector2 gameObjectPosition;
    private GameObject wordBox1;
    private GameObject wordBox2;


    void Start()
    {
        material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(wordBox1 != null && wordBox2 != null)
        {
            Material material1 = wordBox1.gameObject.GetComponent<MeshRenderer>().material;
            material1.color = colorChangeOnHit;

            Material material2 = wordBox2.gameObject.GetComponent<MeshRenderer>().material;
            material2.color = colorChangeOnHit;

            material.color = colorChangeOnHit;
            wordBox1 = null;
            wordBox2 = null;
        }
    }

    /// <summary>
    /// Checks for when another Object collides with this object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region PlayerCollision
        //Checks if  the gameObject that collides with this is the player
        if (collision.gameObject.tag == "Player")
        {
            //Saves the players position in local variable
            gameObjectPosition = collision.gameObject.transform.position;

            //Checks what color to change to
            if(gameObjectPosition.y < gameObject.transform.position.y && material.color != Color.red)
            {
                material.color = Color.red;
            }
            else if(gameObjectPosition.y > gameObject.transform.position.y && material.color != Color.blue)
            {
                material.color = Color.blue;
            }
            else if(gameObjectPosition.x < gameObject.transform.position.x && material.color != Color.green)
            {
                material.color = Color.green;
            }
            else if(gameObjectPosition.x > gameObject.transform.position.x && material.color != Color.black)
            {
                material.color = Color.black;
            }
        }
        #endregion

        #region BoxAdjacentCheck
        if(collision.gameObject.tag == "Pushable")
        {
            if(collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                if(wordBox1 == null)
                {
                    wordBox1 = collision.gameObject;
                }
                else if(wordBox2 == null) 
                {
                    wordBox2 = collision.gameObject;
                }
            }
            else if(collision.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                if (wordBox1 == null)
                {
                    wordBox1 = collision.gameObject;
                }
                else if (wordBox2 == null)
                {
                    wordBox2 = collision.gameObject;
                }
            }
            else if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                if (wordBox1 == null)
                {
                    wordBox1 = collision.gameObject;
                }
                else if (wordBox2 == null)
                {
                    wordBox2 = collision.gameObject;
                }
            }
            else if (collision.gameObject.transform.position.y > gameObject.transform.position.y)
            {
                if (wordBox1 == null)
                {
                    wordBox1 = collision.gameObject;
                }
                else if (wordBox2 == null)
                {
                    wordBox2 = collision.gameObject;
                }
            }
        }
        #endregion
    }
}
