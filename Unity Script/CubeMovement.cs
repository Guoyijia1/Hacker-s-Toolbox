using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public ArduinoData arduinoData;

    public GameObject[] objectsToMove;
    public float MovementAmount = 1.0f;

    public float maxZ = 2.0f; // Maximum allowed position on the Z-axis
    public float minZ = -2.0f; // Minimum allowed position on the Z-axis


    void Update()
    {
        int CubedistanceValue = arduinoData.DistanceValue;
   
        Debug.Log("CubeMovement: " + CubedistanceValue);

        foreach (GameObject obj in objectsToMove)
        {
            // Check if the GameObject has the tag "A"
            if (obj.CompareTag("A"))
            {
                //Debug.Log("Tag of object is A");
                if (CubedistanceValue <=10)
                {
                    //Vector3 movement = new Vector3(0.0f, 0.0f, CubedistanceValue / 10) * MovementAmount;

                    Vector3 movement = new Vector3(0.0f, 0.0f, MovementAmount);
                    Vector3 newPosition = transform.position + movement;

                    // Restrict the movement within the specified range on the Z-axis
                    newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
                    transform.position = newPosition;
                }

                if (CubedistanceValue > 10)
                {
                    //Vector3 movement = new Vector3(0.0f, 0.0f, CubedistanceValue / 10) * MovementAmount;
                    Vector3 movement = new Vector3(0.0f, 0.0f, -MovementAmount);
                    Vector3 newPosition = transform.position + movement;

                    // Restrict the movement within the specified range on the Z-axis
                    newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
                    transform.position = newPosition;
                }
            }

            /*
            if (obj.CompareTag("B"))
            {
                //Debug.Log("Tag of object is A");
                Vector3 movement = new Vector3(0.0f, CubedistanceValue / 10, 0.0f) * MovementAmount;

                // Update the position of the cube
                transform.position += movement;
            }
            */

            // Check if the GameObject has the tag "A"
            if (obj.CompareTag("B"))
            {
                //Debug.Log("Tag of object is A");
                if (CubedistanceValue <= 10)
                {
                    //Vector3 movement = new Vector3(0.0f, 0.0f, CubedistanceValue / 10) * MovementAmount;

                    Vector3 movement = new Vector3(0.0f, MovementAmount, 0.0f);
                    Vector3 newPosition = transform.position + movement;

                    // Restrict the movement within the specified range on the Z-axis
                    newPosition.y = Mathf.Clamp(newPosition.y, minZ, maxZ);
                    transform.position = newPosition;
                }

                if (CubedistanceValue > 10)
                {
                    //Vector3 movement = new Vector3(0.0f, 0.0f, CubedistanceValue / 10) * MovementAmount;
                    Vector3 movement = new Vector3(0.0f, -MovementAmount, 0.0f);
                    Vector3 newPosition = transform.position + movement;

                    // Restrict the movement within the specified range on the Z-axis
                    newPosition.y = Mathf.Clamp(newPosition.y, minZ, maxZ);
                    transform.position = newPosition;
                }
            }

            /*
            if (obj.CompareTag("C"))
            {
                //Debug.Log("Tag of object is A");
                Vector3 movement = new Vector3(CubedistanceValue / 10, 0.0f, 0.0f) * MovementAmount;

                // Update the position of the cube
                transform.position += movement;
            }
            */

            // Check if the GameObject has the tag "A"
            if (obj.CompareTag("C"))
            {
                //Debug.Log("Tag of object is A");
                if (CubedistanceValue <= 10)
                {
                    //Vector3 movement = new Vector3(0.0f, 0.0f, CubedistanceValue / 10) * MovementAmount;

                    Vector3 movement = new Vector3(MovementAmount, 0.0f, 0.0f);
                    Vector3 newPosition = transform.position + movement;

                    // Restrict the movement within the specified range on the Z-axis
                    newPosition.x = Mathf.Clamp(newPosition.x, minZ, maxZ);
                    transform.position = newPosition;
                }

                if (CubedistanceValue > 10)
                {
                    //Vector3 movement = new Vector3(0.0f, 0.0f, CubedistanceValue / 10) * MovementAmount;
                    Vector3 movement = new Vector3(-MovementAmount, 0.0f, 0.0f);
                    Vector3 newPosition = transform.position + movement;

                    // Restrict the movement within the specified range on the Z-axis
                    newPosition.x = Mathf.Clamp(newPosition.x, minZ, maxZ);
                    transform.position = newPosition;
                }
            }
        }
        
    }
}
