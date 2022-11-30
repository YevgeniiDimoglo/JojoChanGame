using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    private float maxHeight;
    private RectTransform rectTransform;
    [SerializeField] private Player player;
    private float power = 0;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        maxHeight = rectTransform.rect.height;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (player)
        {
            power = player.PowerCapacity;
        }
    }

    private void FixedUpdate()
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, maxHeight * (power / player.maxPowerCapacity));
    }
}