using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private SerialPort arduino;

    private bool is_touching;

    private int frame_count;

    // Start is called before the first frame update
    void Start()
    {
        arduino = new SerialPort("COM4", 19200);
        arduino.ReadTimeout = 250;
        arduino.Open();

        frame_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frame_count = (frame_count+1) % 60;
        if (frame_count % 2 == 0)
        {
            StartCoroutine(GetStatusOfSensor());
        }
        Debug.Log(is_touching);
    }

    IEnumerator GetStatusOfSensor()
    {
        arduino.Write("touch_sensor\n");
        yield return is_touching = (arduino.ReadLine() == "1");
    }
}
