using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameManager manager; // Reference to manager script



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))// if collision of game object collides with object with tag.
        {

            manager.wellDone(); // runs well done function

        }


    }
}
