using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    public ArduinoData arduinoData; // Drag and drop the GameObject with ArduinoData script in the Inspector

    public GameObject TriggerDoor;
    public GameObject Door;



    private const float REAL_SECOND_PER_INGAME_DAY = 60f;

    public GameObject clockHourHand;
    public GameObject clockMinuteHand;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;

    private float day;

    private void Awake()
    {
        clockHourHandTransform = clockHourHand.transform;
        clockMinuteHandTransform = clockMinuteHand.transform;
    }


    void Update()
    {
        int distanceValue = arduinoData.DistanceValue;
        int positionValue = arduinoData.PositionValue;

        // Use distanceValue and positionValue as needed
        //Debug.Log("Distance from AnotherScript: " + distanceValue + ", Position: " + positionValue);
        Debug.Log("Position: " + positionValue);

        clockHourHandTransform.eulerAngles = new Vector3(-positionValue, 0, 0);

        float hoursPerDay = 24f;
        clockMinuteHandTransform.eulerAngles = new Vector3(-positionValue * hoursPerDay, 0, 0);

        if (positionValue == -10)
        {
            TriggerDoor.SetActive(true);
            Door.SetActive(false);
        }

    }


}
