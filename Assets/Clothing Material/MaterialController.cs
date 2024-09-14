using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public Material[] materials; // a list of material. We have to manually add them before running the game.
    private int currentIndex = 0; // MaterialIndex
    private Renderer objRenderer; 

    void Start()
    {
       
        objRenderer = GetComponent<Renderer>();

        // check if there's more than one material in the Index
        if (materials.Length > 0)
        {
            objRenderer.material = materials[currentIndex];
        }
        else
        {
            Debug.LogError("No material, add something!");
        }
    }

    void Update()
    {
        // When press space, change the material
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeMaterial();
        }
    }

    void ChangeMaterial()
    {
        // update material index
        currentIndex = (currentIndex + 1) % materials.Length;
        // apply new material
        objRenderer.material = materials[currentIndex];
    }
}
