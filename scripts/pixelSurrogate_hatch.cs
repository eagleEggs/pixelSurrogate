using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixelSurrogate_hatch : MonoBehaviour
{

    [SerializeField] private float speed; // speed of pixel movement
    private GameObject target; // object to go after
    private Vector3 startPosition; // record of start position so it can return after chasing
    private Quaternion startRotation; // record of start position so it can return after chasing
    private float randomRotating; // rotation when close to target

    void Start()
    {

        randomRotating = Random.Range(-360f, 360f);

        float randomSpeed = Random.Range(3, 4); // set a random speed so they aren't all the same
        speed = randomSpeed; // set float to the new random
        target = GameObject.FindWithTag("Player"); ; // set target to player from pixelSurrogateController

        startPosition = this.transform.position; // record the start position so it can return to it later
        startRotation = this.transform.rotation; // record the start rotation so it can return to it later



    }


    void Update()
    {

        float dist = Vector3.Distance(this.transform.transform.position, target.transform.position); // get distance between mesh and player
        if (dist <= 100f && dist > 10f) // if it's less than 100f and greater than 10f
        {



            transform.position = Vector3.MoveTowards(this.transform.transform.position, target.transform.position, speed); // start moving



        }
        if (dist <= 10f) // if distance is less than or equal to 10f
        {

            transform.RotateAround(target.transform.position, Vector3.up, randomRotating * Time.deltaTime); // rotate around target



        }
        if (dist > 100f) //if it's greater than 100f
        {

            transform.position = Vector3.MoveTowards(this.transform.position, startPosition, speed); // return home
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, startRotation, speed); // return home
        }


    }




}