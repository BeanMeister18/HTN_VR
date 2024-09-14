using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSwapper : MonoBehaviour
{
    public ClothesType ClothesSection;
    public ImageDownloader dsection;
    private void OnTriggerStay(Collider other)
    {
        ImageDownloader imd = other.GetComponent<ImageDownloader>();

        if (imd != null)
        {
            if (imd.Clothing == ClothesSection)
            {
                dsection.url = imd.url;
                dsection.Start();

                Destroy(imd.gameObject);
            }
        }
    }
}
