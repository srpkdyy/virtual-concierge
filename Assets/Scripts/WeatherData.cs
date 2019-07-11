using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeatherData
{
    [SerializeField]
    public ForecastData[] forecasts = null;


    [System.Serializable]
    public class ForecastData
    {
        [SerializeField]
        public string telop = null;
        [SerializeField]
        public string date = null;
        [SerializeField]
        public TemperatureData temperature = null;
    }

    [System.Serializable]
    public class TemperatureData
    {
        [SerializeField]
        public TemperatureDetailData min = null;
        [SerializeField]
        public TemperatureDetailData max = null;
    }

    [System.Serializable]
    public class TemperatureDetailData
    {
        [SerializeField]
        public string celsius = null;
    }
}