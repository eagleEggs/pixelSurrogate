using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixelSurrogate_hatch : MonoBehaviour
{

    [SerializeField] private float speed;
    private GameObject target;
    private Vector3 startPosition;
    //private GameObject player;

    void Start()
    {
        float randomSpeed = Random.Range(0.5f, 3f);
        speed = randomSpeed;
        target = GameObject.FindGameObjectWithTag("Player");
        startPosition = this.transform.position;

    }


    void Update()
    {

        float dist = Vector3.Distance(this.transform.position, target.transform.position);

        if (dist <= 100f)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);
        }
            if (dist >100f) //push image
            {
            transform.position = Vector3.MoveTowards(this.transform.position, startPosition, speed);

            }

    }

    


}
