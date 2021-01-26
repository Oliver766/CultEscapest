using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follow : MonoBehaviour
{
    public Transform target; //  target of camera following
    public float smoothing; // camera smoothing


    

    // Update is called once per frame
    void LateUpdate()
    {


        if (transform.position != target.position) // if transform . position equals target.position
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // gets new position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); // sets new position

        }
    }
}
