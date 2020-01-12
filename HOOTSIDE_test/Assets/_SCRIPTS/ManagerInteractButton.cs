using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script permettant le declencement de interactions via les boutons
public class ManagerInteractButton : MonoBehaviour
{
    public ReadJsonOnline _readJsonOnline;
    [Header("LIENS DATAS DE L'API SELON LES VILLES")]
    public string ParisDataPath;
    public string BamakoDataPath;
    public string HaitiDataPath;
    public string LondonDataPath;
    public string ReykjavikDataPath;


    public void ParisData()
    {
        _readJsonOnline.pathJsonData = ParisDataPath;
        _readJsonOnline.PlayCoroutine();
    }

    public void BamakoData()
    {
        _readJsonOnline.pathJsonData = BamakoDataPath;
        _readJsonOnline.PlayCoroutine();
    }

    public void HaitiData()
    {
        _readJsonOnline.pathJsonData = HaitiDataPath;
        _readJsonOnline.PlayCoroutine();
    }

    public void LondonData()
    {
        _readJsonOnline.pathJsonData = LondonDataPath;
        _readJsonOnline.PlayCoroutine();
    }

    public void ReykjavikData()
    {
        _readJsonOnline.pathJsonData = ReykjavikDataPath;
        _readJsonOnline.PlayCoroutine();
    }
}
