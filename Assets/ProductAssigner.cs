using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ProductScraper))]
public class ProductAssigner : MonoBehaviour
{

    ProductScraper _P;
    public ImageDownloader[] ProductList;

    float _t = 0;
    float _lt = 5;

    float its = 0;

    // Start is called before the first frame update
    void Start()
    {
        _P = GetComponent<ProductScraper>();

        Distribute();
    }

    private void Update()
    {
        if (_t < _lt)
        {
            Distribute();
            _t += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Distribute()
    {
        if (true)
        {
            int ind = 0;
            foreach (Product p in GameSettings.Products)
            {
                if (ind < ProductList.Length)
                {
                    ProductList[ind].Clothing = p.title;
                    ProductList[ind].url = p.imageUrl;
                    ProductList[ind].Price = p.price;
                    ProductList[ind].title = p.title.ToString();
                    ProductList[ind].Start();
                    ind++;
                }
            }
        }
    }
}
