using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourNearlythere : MonoBehaviour
{

   
    public GameObject Target;// game object


    public void Start()
    {
        Target.SetActive(false);// sets object false
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

        Target.SetActive(true);// sets object true

        yield return new WaitForSeconds(2);// waits 3 seconds
        Target.SetActive(false);// sets object false

    }
}

