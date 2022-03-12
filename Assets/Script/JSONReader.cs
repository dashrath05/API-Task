using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JSONReader : MonoBehaviour
{
    public Responce newsAllData;
    public NewsItem prefab;
    
    public Transform startPosition;
   
    string searchData = "Tesla";
    public string API_KEY;
   
    void Start()
    {
        StartCoroutine(GetData());
    }
    private IEnumerator GetData()
    {
       
        UnityWebRequest request = new UnityWebRequest("https://newsapi.org/v2/everything?q=" + searchData + "&apiKey=" + API_KEY)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Connection error!");
            yield break;
        }
        newsAllData = JsonUtility.FromJson<Responce>(request.downloadHandler.text);
       
        for (int i = 0; i < newsAllData.articles.Count; i++)
        {
            NewsItem button = Instantiate(prefab, startPosition);
            button.SetItem(newsAllData.articles[i]);
           
        }

    }

    public void SearchData()
    {
       
        InputField txt_Input = GameObject.Find("SearchBox").GetComponent<InputField>();
        searchData = txt_Input.text;
    }
}



[Serializable]
public class Source
{
    public string id;
    public string name;
}

[Serializable]
public class Article
{
    public Source source;
    public string author;
    public string title;
    public string description;
    public string url;
    public string urlToImage;
    public DateTime publishedAt;
    public string content;
    public Texture imgTextute;
}

[Serializable]
public class Responce
{
    public string status;
    public int totalResults;
    public List<Article> articles;
}
