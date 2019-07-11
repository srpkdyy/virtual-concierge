using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {
    private IEnumerator GetWeatherInfo(System.Action<string> onFinished)
    {
        var request = UnityEngine.Networking.UnityWebRequest.Get("http://weather.livedoor.com/forecast/webservice/json/v1?city=340010");
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.LogErrorFormat("エラー発生で草草の草　→　{0}", request.error);
            yield break;
        }

        onFinished(request.downloadHandler.text);
    }

    private IEnumerator PrintWeatherInfo()
    {
        string weatherInfo = null;
        {
            System.Action<string> onFinished = (i_text) =>
            {
                weatherInfo = i_text;
            };
            yield return GetWeatherInfo(onFinished);
        }
        Debug.Log(weatherInfo);

        var weatherData = JsonUtility.FromJson<WeatherData>(weatherInfo);
        SetWeatherData(weatherData);
    }

  
    private void SetWeatherData(WeatherData weatherData)
    {
        var forecast = weatherData.forecasts[0];
        Debug.Log(forecast.telop);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(PrintWeatherInfo());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
