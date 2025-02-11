using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrainMove : MonoBehaviour
{
    public int totalDistance;
    private Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        totalDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        totalDistance += (int)this.transform.position.x;
        rb.velocity = new Vector3(10,0,0);
    }



    private int checkDistance()
    {

        return 1;
    }
}
