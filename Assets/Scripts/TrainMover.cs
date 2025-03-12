using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour
{
    private float moveSpeed = 0;

    // Declare the event
    public delegate void SpeedChanged(float oldSpeed, float newSpeed);
    public event SpeedChanged OnSpeedChanged;

    void Update()
    {
        setSpeed(); // Call setSpeed in Update to listen for key presses
    }

    void setSpeed()
    {
        float oldSpeed = moveSpeed; // Save the old speed

        if (Input.GetKeyDown("0")) moveSpeed = 0;
        if (Input.GetKeyDown("1")) moveSpeed = 2;
        if (Input.GetKeyDown("2")) moveSpeed = 5;
        if (Input.GetKeyDown("3")) moveSpeed = 8;


        if (moveSpeed != oldSpeed)
        {
            OnSpeedChanged?.Invoke(oldSpeed, moveSpeed);

        }
    }

    public float getSpeed()
    {
        return moveSpeed;
    }
}
