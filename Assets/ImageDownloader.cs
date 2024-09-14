using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ImageDownloader : MonoBehaviour
{
    Material _currMat;
    public string url;
    public float thres;
    public void Start()
    {
        _currMat = GetComponent<Renderer>().material;
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else {
            Texture2D t = (((DownloadHandlerTexture)request.downloadHandler).texture);

            var colourD = t.GetPixels32();

            for (int i = 0; i < colourD.Length; i++)
            {
                if (colourD[i].r + colourD[i].g + colourD[i].b >= thres)
                {
                    colourD[i].a = 0;
                }
            }

            t.SetPixels32(colourD);
            t.Apply();
            _currMat.mainTexture = t;
        }
    }
}