using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ROOT CLASS

// Json > C#
[System.Serializable]
public class JsonMainClass
{
    public string cod ;
    public string message ;
    public string cnt ;
    public List<_List> list ;
    public _City city ;
}

#endregion ROOT CLASS

#region JSON CLASS

[System.Serializable]
public class _Main
{
    public byte temp ;
    public string feels_like ;
    public string temp_min ;
    public string temp_max ;
    public string pressure ;
    public string sea_level ;
    public string grnd_level ;
    public string humidity ;
    public string temp_kf ;
}

[System.Serializable]
public class _Weather
{
    public string id ;
    public string main ;
    public string description ;
    public string icon ;
}

[System.Serializable]
public class _Clouds
{
    public string all ;
}

[System.Serializable]
public class _Wind
{
    public float speed ;
    public string deg ;
}

[System.Serializable]
public class _Sys
{
    public string pod ;
}

[System.Serializable]
public class _Rain
{
    public string __invalid_name__3h ;
}

[System.Serializable]
public class _List
{
    public string dt ;
    public _Main main ;
    public List<_Weather> weather ;
    public _Clouds clouds ;
    public _Wind wind ;
    public _Sys sys ;
    public string dt_txt ;
    public _Rain rain ;
}

[System.Serializable]
public class _Coord
{
    public string lat ;
    public string lon ;
}

[System.Serializable]
public class _City
{
    public string id ;
    public string name ;
    public _Coord coord ;
    public string country ;
    public string timezone ;
    public string sunrise ;
    public string sunset ;
}

#endregion JSON CLASS

