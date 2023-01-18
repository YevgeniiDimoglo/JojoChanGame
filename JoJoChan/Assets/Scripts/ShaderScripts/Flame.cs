using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] private Player player;
    Material material;

    // Start is called before the first frame update
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        material.SetFloat("_Flow", 1.0f);
    }

    private void Update()
    {
        if (player.state != 0)
        {
            material.SetFloat("_Flow", 0.0f);
        }
        else
        {
            material.SetFloat("_Flow", 1.0f);
        }
    }
}
