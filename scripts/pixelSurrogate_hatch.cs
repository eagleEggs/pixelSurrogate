using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixelSurrogate_hatch : MonoBehaviour
{

    [SerializeField] private float speed; // speed of pixel movement
    private GameObject target; // object to go after
    private Vector3 startPosition; // record of start position so it can return after chasing

    void Start()
    {
        float randomSpeed = Random.Range(0.5f, 3f); // set a random speed so they aren't all the same
        speed = randomSpeed; // set float to the new random
        target = GameObject.FindGameObjectWithTag("Player"); // set target to player
        startPosition = this.transform.position; // record the start position

    }


    void Update()
    {

        float dist = Vector3.Distance(this.transform.position, target.transform.position); // get distance between mesh and player

        if (dist <= 100f) // if it's less than 100f
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed); // start moving
        }
            if (dist >100f) //if it's greater than 100f
            {
            transform.position = Vector3.MoveTowards(this.transform.position, startPosition, speed); // return home

            }

    }

    


}
