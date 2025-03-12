using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private GameObject[] backgroundPrefabs; // List of background prefabs
    [SerializeField] private List<GameObject> activeBackgrounds = new List<GameObject>(); // Currently active backgrounds

    [SerializeField] public float moveSpeed = 0;      // Speed of movement


    [SerializeField] private float resetPosition = -10f; // X position where backgrounds get removed
    [SerializeField] private float halfwayPoint;//
    [SerializeField] private float startPosition = 10f; // X position where new backgrounds start

    [SerializeField] private TrainMover trainMover;

    void Start()
    {
 
        if (activeBackgrounds.Count == 0)
        {
            Debug.LogError("Assign active backgrounds in the inspector or instantiate them at runtime.");
        }
        trainMover.OnSpeedChanged += HandleSpeedChanged;

    }

    void Update()
    {
        halfwayPoint = resetPosition / 2;
        MoveBackgrounds();
    }


    void MoveBackgrounds()
    {
        for (int i = 0; i < activeBackgrounds.Count; i++)
        {
            GameObject bg = activeBackgrounds[i];

            // Move the background to the left
            bg.transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if(bg.transform.position.x <= halfwayPoint)
            {

            }
            if (bg.transform.position.x <= resetPosition)
            {
                ReplaceWithRandomBackground(i);
            }
        }
    }

    void ReplaceWithRandomBackground(int index)
    {
        // Destroy the old background
        Destroy(activeBackgrounds[index]);

        // Pick a random background prefab
        GameObject newBackground = Instantiate(backgroundPrefabs[Random.Range(0, backgroundPrefabs.Length)]);

        // Position the new background at the start position
        newBackground.transform.position = new Vector3(startPosition, 0, 0);

        // Replace the old background in the active list
        activeBackgrounds[index] = newBackground;
    }

    private void HandleSpeedChanged(float oldSpeed, float newSpeed)
    {
        moveSpeed = newSpeed; // Update the moveSpeed based on the event
        Debug.Log($"Train speed changed from {oldSpeed} to {newSpeed}.");
    }

}
