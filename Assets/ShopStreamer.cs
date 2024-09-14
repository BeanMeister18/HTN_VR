using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyJson;
using UnityEngine.Networking;
using System.Text;
using System.IO;

public class ShopStreamer : MonoBehaviour
{

    IEnumerator Upload(string filename)
    {
        WWWForm webForm = new WWWForm();

        print("Uploading...");

        // convert our class to json
        string JsonData = "{\"name\": \"test\"}";


        // instance of unity web request
        UnityWebRequest www = UnityWebRequest.PostWwwForm("https://livepeer.studio/api/asset/request-upload", "POST");

        // setup upload/download headers (this is what sets the json body)
        byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonData);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        // set your headers
        www.SetRequestHeader("Authorization", "Bearer " + "0488e0b2-7284-42cd-ad30-64a49b924d6c");
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            print(www.error);
        }
        else
        {
            print("---> " + www.downloadHandler.text);
            var json = www.downloadHandler.text;
            int[] tx = JSONParser.FromJson<int[]>(json);

        //    print("url " + tx.url);

            UnityWebRequest www2 = UnityWebRequest.Put(tx.ToString(), File.ReadAllBytes(filename));

            // setup upload/download headers (this is what sets the json body)
            // set your headers
            www2.SetRequestHeader("Authorization", "Bearer " + "0488e0b2-7284-42cd-ad30-64a49b924d6c");
            www2.SetRequestHeader("Content-Type", "video/mp4");

            yield return www2.SendWebRequest();

            if (www2.isNetworkError || www2.isHttpError)
            {
                print(www2.error);
            }
            else
            {
                print("Success!");
            }
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
