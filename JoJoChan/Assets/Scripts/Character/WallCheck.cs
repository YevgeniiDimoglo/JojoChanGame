using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsWall;
    public bool touchWall;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!touchWall)
        {
            touchWall = collider != null && (((1 << collider.gameObject.layer) & m_WhatIsWall) != 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchWall = false;
    }
}