using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayScale : MonoBehaviour
{
    private Material material;
    public Shader shader;
    public Player player;
        
    // Start is called before the first frame update
    void Start()
    {
        material = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (player.state == 1)  Graphics.Blit(source, destination, material);
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
