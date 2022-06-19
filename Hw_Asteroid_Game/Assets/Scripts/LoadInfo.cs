using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System.Text.Json;

public static class LoadInfo
{    
    public static Info Load()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Info");
        Debug.Log(textAsset.text);
        Info info = JsonUtility.FromJson<Info>(textAsset.text);
        return info;
    }
}

public class Info
{
    //[JsonProperty("type")]
    public string[] type;
    //[JsonProperty("health")] 
    public float[] health;
    //[JsonProperty("speed")] 
    public float[] speed;
}
