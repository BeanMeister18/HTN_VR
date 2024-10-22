using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSwapper : MonoBehaviour
{
    public ClothesType ClothesSection;
    public ImageDownloader dsection;
    public AudioSource trigger;
    private void OnTriggerStay(Collider other)
    {
        ImageDownloader imd = other.GetComponent<ImageDownloader>();

        if (imd != null)
        {
            if (imd.Clothing == ClothesSection)
            {
                if (dsection.url != imd.url)
                {
                    dsection.url = imd.url;
                    dsection.Start();

                    trigger.Play();
                }

              //  Destroy(imd.gameObject);
            }
        }
    }
}
