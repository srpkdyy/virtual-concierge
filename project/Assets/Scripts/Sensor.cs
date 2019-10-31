using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private SerialPort arduino;

    private bool is_touching, is_moving;
    private int temperature;

    private int frame_count;

    // Start is called before the first frame update
    void Start()
    {
        arduino = new SerialPort("COM4", 9600);
        arduino.ReadTimeout = 250;
        arduino.Open();
    }

    // Update is called once per frame
    void Update()
    {
        frame_count = (frame_count+1) % 60;
        if (frame_count % 2 == 0)
        {
            StartCoroutine(GetStatusOfSensor());
            //Debug.Log(temperature);
            Debug.Log(is_moving);
        }
    }

    IEnumerator GetStatusOfSensor()
    {
        arduino.Write("touch\n");
        yield return is_touching = (arduino.ReadLine() == "1");
        arduino.Write("move\n");
        yield return is_moving = (arduino.ReadLine() == "1");
        arduino.Write("temperature\n");
        yield return temperature = int.Parse(arduino.ReadLine());
    }
}
