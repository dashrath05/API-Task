using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class NewsItem : MonoBehaviour
{
    public Text mainText;
    public RawImage rawImageData;
    public Texture imageTextureStore;

    public Article articleData;
    
    public TempDataStore tempDataStore;

  
   
    private GameObject mainCanvas;
    private GameObject containCanvas;

    void Start()
    {
       mainCanvas=GameObject.Find("Canvas");
       containCanvas=GameObject.Find("AllContainCanvas");
       tempDataStore= GameObject.Find("CanvasHandler").GetComponent<TempDataStore>();

    }

    public void SetItem(Article data)
    {
        articleData = data;
        mainText.text = articleData.title;
        StartCoroutine(GetImageTexture());


    }
    IEnumerator GetImageTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(articleData.urlToImage);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawImageData.texture = myTexture;
            imageTextureStore = myTexture;
        }
    }

    public void OnClick()
    {
         mainCanvas.SetActive(false);
        tempDataStore.TempDataAll(articleData,imageTextureStore);
       
    }


}
