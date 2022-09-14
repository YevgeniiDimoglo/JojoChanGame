using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsGround;
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!isGrounded)
            isGrounded = collider != null && (((1 << collider.gameObject.layer) & m_WhatIsGround) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}