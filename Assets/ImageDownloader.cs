using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public enum ClothesType
{
    None,
    Torso,
    Lower,
    Foot
}
public class ImageDownloader : MonoBehaviour
{
    Material _currMat;
    public ClothesType Clothing = ClothesType.None;
    public Material SetMat;
    public string url;
    public string Price;
    public string title;
    public TextMeshPro TMPTitle;
    public TextMeshPro TMPPrice;
    public float thres;
    public void Start()
    {
        if (!SetMat)
            _currMat = GetComponent<Renderer>().material;
        else
            _currMat = SetMat;

        if (url.Length > 0)
            StartCoroutine(DownloadImage(url));

        if (TMPTitle)
            TMPTitle.text = title;

        if (TMPPrice)
        TMPPrice.text = Price;
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else {
            Texture2D t = (((DownloadHandlerTexture)request.downloadHandler).texture);
            _currMat.mainTexture = t;
        }
    }
}
