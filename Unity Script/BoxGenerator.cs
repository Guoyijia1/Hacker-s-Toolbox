using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BoxGenerator : MonoBehaviour
{

    public bool generateBox = false;  // This is the bool you mentioned

    public GameObject boxPrefab;  // Reference to the BoxPrefab

    public Transform generatorPosition;  // The position where the box will be generated

    SerialPort serialPort;

    void Start()
    {
        // Modify the port name and baud rate based on your Arduino configuration
        serialPort = new SerialPort("/dev/cu.usbmodem1301", 9600);
        serialPort.Open();
    }


    void Update()
    {

        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            // Read the message from the serial port
            string message = serialPort.ReadLine();

            // Check if the received message is "S"
            if (message.Trim() == "S")
            {
                Debug.Log("S_sound sensor detected");
                // Set the bool to true to generate the box
                generateBox = true;
            }
        }

        // Check if the bool is true
        if (generateBox)
        {
            // Call the method to generate the box at the specified position
            GenerateBox();

            // Reset the bool to false to avoid continuous generation
            generateBox = false;
        }
    }

    void GenerateBox()
    {
        // Instantiate the boxPrefab at the specified position and rotation
        GameObject box = Instantiate(boxPrefab, generatorPosition.position, generatorPosition.rotation);

        // The instantiated box is now independent in the scene, not a child of the generator
    }
}
