using UnityEngine;
using UnityEngine.UI;

public class TempDataStore : MonoBehaviour
{
    public GameObject tempCanvas;
    public Text titleText;
    public Text containText;
 
    public RawImage rawImageTexture;
    public Article articleAllData;


    public void TempDataAll(Article tempData, Texture imgtexture)
    {

        tempCanvas.SetActive(true);
        articleAllData = tempData;
        titleText.text = articleAllData.title;
        containText.text = articleAllData.description;
        rawImageTexture.texture = imgtexture;

    }
}
