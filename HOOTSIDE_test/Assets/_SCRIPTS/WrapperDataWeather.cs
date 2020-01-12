using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Script permettant de gérer les données de l'api
public class WrapperDataWeather : MonoBehaviour
{

    #region VARIABLES

    [Header("OBJETS CONNECTEES A L'API")]
    public string _url;
    public RawImage _rawImageIcon;
    public Text _text;
    public ParticleSystem _particlesSystem;
    public Light _pointLight;
    public byte _r_color;
    public ReadJsonOnline _readJsonOnline;

    #endregion VARIABLES

    #region FUNCTIONS

    public void Update()
    {
       
        UpdateData(); // update les données météo
        ColorTemp(); // gère la couleur de la light celon la température
        StartCoroutine(LoadFileCoroutine()); // Permet de load les datas via l'api
      

    }

    // Gameobject liés à l'api
    public void UpdateData()
    {
        _url = "http://openweathermap.org/img/wn/" + _readJsonOnline._icon + "@2x.png";
        _text.text = _readJsonOnline._name;
        float x_float = _readJsonOnline._speed;
        var vel = _particlesSystem.velocityOverLifetime;
        vel.x = (x_float * 10);
        _r_color = _readJsonOnline._temp;

    }

    // fonctions pour la gestion de la couleur de la light
    public void ColorTemp()
    {

        if(_r_color > -1.0f)
        {
            Debug.Log("froid");
            _pointLight.color = Color.blue;

        }
        if (_r_color > 10) 
        {
            Debug.Log("temperé");
            _pointLight.color = Color.yellow;
        }
        if(_r_color > 24)
        {
            Debug.Log("chaud");
            _pointLight.color = Color.red;
        }

    }

    // coroutine pour la lecture des datas de l'api
    public IEnumerator LoadFileCoroutine()
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(_url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(":Error:");
            }
            else
            {
                Debug.Log(":Done:");
                _rawImageIcon.texture = DownloadHandlerTexture.GetContent(webRequest);

            }

        }

    }

    #endregion FUNCTIONS
}
