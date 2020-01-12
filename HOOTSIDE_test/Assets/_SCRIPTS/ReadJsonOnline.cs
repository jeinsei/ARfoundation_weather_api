using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//script permettant de charger les datas via les differents URL
public class ReadJsonOnline : MonoBehaviour
{
    #region VARIABLES

    [Header("DEBUG DATAS DE L'API")]
    public string pathJsonData;
    public string _lon, _lat, _id, _main, _description, _icon, _pressure, _humidity, _temp_min
    ,_temp_max, _deg, _all, _idcity, _country, _name, _sunrise, _sunset;
    public byte _temp;
    public float _speed;

    #endregion VARIABLES

    #region FUNCTIONS

    public void Awake()
    {   
        StartCoroutine(LinkDataJson(pathJsonData));
    }

    public void PlayCoroutine()
    {
        StartCoroutine(LinkDataJson(pathJsonData));
    }

    IEnumerator LinkDataJson(string _pathUrl)

      {
          Debug.Log("Entrée coroutine");
          
          using (UnityWebRequest webRequest = UnityWebRequest.Get(_pathUrl))
          
          {
                 yield return webRequest.SendWebRequest();

             if (webRequest.isNetworkError)
            {
                Debug.Log(":Error:");
            }
            else
            {
                Debug.Log(":Done:");
                ProcessJsonData(webRequest.downloadHandler.text);
            }
            
            }  
    
    }


    public void ProcessJsonData(string _url)
    {
        Debug.Log("Mapping des datas");
        JsonMainClass JsonBridge = JsonUtility.FromJson<JsonMainClass>(_url);
        _lon = JsonBridge.city.coord.lon;
        _lat = JsonBridge.city.coord.lat;
        _id  = JsonBridge.list[0].weather[0].id;
        _main = JsonBridge.list[0].weather[0].main;
        _description = JsonBridge.list[0].weather[0].description;
        _icon = JsonBridge.list[0].weather[0].icon;
        _temp = JsonBridge.list[0].main.temp;
        _pressure = JsonBridge.list[0].main.pressure;
        _humidity = JsonBridge.list[0].main.humidity;
        _temp_min = JsonBridge.list[0].main.temp_min;
        _temp_max = JsonBridge.list[0].main.temp_max;
        _speed = JsonBridge.list[0].wind.speed;
        _deg = JsonBridge.list[0].wind.deg;
        _all = JsonBridge.list[0].clouds.all;
        _idcity = JsonBridge.city.id;
        _name = JsonBridge.city.name;
        _country = JsonBridge.city.country;
        _sunrise = JsonBridge.city.sunrise;
        _sunset = JsonBridge.city.sunset; 


    } 

    #endregion FUNCTIONS

}

