using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningRoom : MonoBehaviour
{

    public GameObject Room; // game object

    public void Start()
    {
        Room.SetActive(false); // sets object false
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if collision of game object collides with object with tag.
        {

            StartCoroutine(TextT()); // start coroutine
            Debug.Log("Enter");
        }

    }

    public IEnumerator TextT()
    {

        Room.SetActive(true); // sets object true

        yield return new WaitForSeconds(2); // waits 3 seconds
        Room.SetActive(false); // sets object false

    }


}
