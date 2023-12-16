// ArduinoData.cs

// ArduinoData.cs

using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoData : MonoBehaviour
{
    public int DistanceValue { get; private set; }
    public int PositionValue { get; private set; }

    SerialPort serialPort;

    void Start()
    {
        serialPort = new SerialPort("/dev/cu.usbmodem1301", 9600); // Replace "COM3" with your Arduino port
        try
        {
            serialPort.Open();
            serialPort.ReadTimeout = 1000; // Set a timeout to avoid blocking indefinitely
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening serial port: " + e.Message);
        }
    }

    void Update()
    {
        //Debug.Log("Distance: " + DistanceValue + ", Position: " + PositionValue);
        try
        {
            string serialData = serialPort.ReadLine();
            ParseSerialData(serialData);
        }
        catch (TimeoutException) { }
    }

    void ParseSerialData(string data)
    {
        string[] values = data.Split(',');

        foreach (string value in values)
        {
            string[] parts = value.Split(':');
            if (parts.Length == 2)
            {
                string key = parts[0].Trim();
                string stringValue = parts[1].Trim();

                if (key == "Distance")
                {
                    DistanceValue = int.Parse(stringValue);
                }
                else if (key == "Position")
                {
                    PositionValue = int.Parse(stringValue);
                }
                else if (key == "S")
                {
                    Debug.Log("sound sensor is on");
                }

            }
        }

        // Now DistanceValue and PositionValue hold the parsed values
        //Debug.Log("Distance: " + DistanceValue + ", Position: " + PositionValue);
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
