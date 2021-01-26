using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public GameObject text;// game object



    public void Start()
    {
        text.SetActive(false);// sets object false
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))// if collision of game object collides with object with tag.
        {

            StartCoroutine(TextT());// start coroutine
            Debug.Log("Enter");
        }

    }

    public IEnumerator TextT()
    {

        text.SetActive(true);// sets object true

        yield return new WaitForSeconds(3); // waits 3 seconds
        text.SetActive(false);// sets object false

    }

}

