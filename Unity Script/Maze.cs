using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Maze : MonoBehaviour
{

    SerialPort serialPort;

    public GameObject RedMaze;
    public GameObject YellowMaze;
    public GameObject BlueMaze;

    public GameObject Red_BlackMaze;
    public GameObject Yellow_BlackMaze;
    public GameObject Blue_BlackMaze;


    void Start()
    {
        // Modify the port name and baud rate based on your Arduino configuration
        serialPort = new SerialPort("/dev/cu.usbmodem1301", 9600);
        serialPort.Open();

        RedMaze.SetActive(false);
        YellowMaze.SetActive(false);
        BlueMaze.SetActive(false);

        Red_BlackMaze.SetActive(true);
        Yellow_BlackMaze.SetActive(true);
        Blue_BlackMaze.SetActive(true);

    }


    void Update()
    {

        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            // Read the message from the serial port
            string message = serialPort.ReadLine();

            // Check if the received message is "S"
            if (message.Trim() == "R")
            {
                Debug.Log("R");
                // Set the bool to true to generate the box
                RedMaze.SetActive(true);
                Red_BlackMaze.SetActive(false);

                YellowMaze.SetActive(false);
                Yellow_BlackMaze.SetActive(true);

                BlueMaze.SetActive(false);
                Blue_BlackMaze.SetActive(true);

            }

            if (message.Trim() == "Y")
            {
                Debug.Log("Y");
                // Set the bool to true to generate the box
                YellowMaze.SetActive(true);
                Yellow_BlackMaze.SetActive(false);

                BlueMaze.SetActive(false);
                Blue_BlackMaze.SetActive(true);

                RedMaze.SetActive(false);
                Red_BlackMaze.SetActive(true);
            }

            if (message.Trim() == "B")
            {
                Debug.Log("B");
                // Set the bool to true to generate the box
                BlueMaze.SetActive(true);
                Blue_BlackMaze.SetActive(false);

                YellowMaze.SetActive(false);
                Yellow_BlackMaze.SetActive(true);

                RedMaze.SetActive(false);
                Red_BlackMaze.SetActive(true);
            }


        }
    }
}