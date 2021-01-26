using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lodge : MonoBehaviour
{

    public GameObject Lodges;// game object


    public void Start()
    {
        Lodges.SetActive(false);// sets object false
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

        Lodges.SetActive(true);// sets object true

        yield return new WaitForSeconds(2); // waits 3 seconds
        Lodges.SetActive(false);// sets object false

    }

}
