using System.Net;
using System.IO;
using UnityEngine;

public static class APIHelper
{
    public static ParseJsonData GetData()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44325/api/User");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<ParseJsonData>(json);
    }
}
