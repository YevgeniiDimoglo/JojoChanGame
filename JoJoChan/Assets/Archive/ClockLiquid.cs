using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockLiquid : MonoBehaviour
{
    public Player player;

    private float ColorValue;

    private SpriteRenderer _spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ColorValue = player.PowerCapacity;
        _spriteRender.color = new Color(1.0f, 0.0f, 0.0f, 1.0f * ColorValue * 0.01f);
    }
}
