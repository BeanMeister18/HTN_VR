using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product
{
    public ClothesType title;
    public string price;
    public long productId;
    public string imageUrl;
}

public static class GameSettings { 
    public static List<Product> Products = new List<Product>();
}
