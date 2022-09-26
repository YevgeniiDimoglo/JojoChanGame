using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject jojoChanPrefab;
    private GameObject dummy;

    public float MovementSpeed = 10;
    public float JumpForce = 50;
    public int Health;

    public bool CameraControl = false;
    private bool moveable = true;
    private bool TheWorldActive = false;

    private bool m_Grounded;
    private bool m_Walled;

    public Animator animator;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer m_SpriteRenderer;
    private Color m_NewColor;

    private void Awake()
    {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        Health = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        m_Grounded = isGrounded();
        m_Walled = isWalled();
        // Jump
        if (Input.GetButtonDown("Jump") && jumpable())
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonUp("Jump") && _rigidbody.velocity.y > 0 && animator.GetBool("IsJumping") && !animator.GetBool("WallJump") && moveable)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.3f);
        }

        // WallJump
        if (Input.GetButtonDown("Jump") && Input.GetAxis("Horizontal") != 0 && m_Walled && !m_Grounded)
        {
            lockMove();
            animator.SetBool("WallJump", true);
            _rigidbody.velocity = new Vector2();
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("wallJump", 0.33f);
        }

        animator.SetFloat("velocity.y", _rigidbody.velocity.y);
        animator.SetBool("IsJumping", !m_Grounded);

        if (Input.GetKeyDown("f"))
        {
            ChangeState();

            if (!TheWorldActive)
            {
                SpawnDummy();
            }
            else
            {
                DestroyDummy();
            }
        }

        if (Input.GetKeyDown("v"))
        {
            CameraControl = true;
        }
        if (Input.GetKeyUp("v"))
        {
            CameraControl = false;
        }
    }

    private void FixedUpdate()
    {
        // Move
        if (walkable())
        {
            var movement = Input.GetAxis("Horizontal");

            if (!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            }
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    public void wallJump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator.SetBool("WallJump", false);
        float angle;

        if (transform.rotation.y == 0)
        {
            angle = 120;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            angle = 60;
            transform.rotation = Quaternion.identity;
        }
        Vector2 v = new Vector2(JumpForce * Mathf.Cos(angle * Mathf.Deg2Rad), JumpForce * Mathf.Sin(angle * Mathf.Deg2Rad));
        _rigidbody.AddForce(v, ForceMode2D.Impulse);

        Debug.Log(angle + ":" + v);
        Invoke("endWallJump", 0.5f);

        animator.SetFloat("Speed", 0.5f);
    }

    public void endWallJump()
    {
        freeMove();
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.y * .1f, _rigidbody.velocity.y);
    }

    public void lockMove()
    {
        moveable = false;
    }

    public void freeMove()
    {
        if (!animator.GetBool("WallJump"))
            moveable = true;
    }

    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    private bool isWalled()
    {
        return transform.Find("WallCheck").GetComponent<WallCheck>().touchWall;
    }

    private void ChangeState()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_NewColor = new Color(1, 1, 1);

        if (m_SpriteRenderer.color.a == 0.5f)
        {
            m_NewColor.a = 1.0f;
            m_SpriteRenderer.color = m_NewColor;
        }
        else
        {
            m_NewColor.a = 0.5f;
            m_SpriteRenderer.color = m_NewColor;
        }
    }

    private void SpawnDummy()
    {
        dummy = Instantiate(jojoChanPrefab, transform.position, Quaternion.identity);
        TheWorldActive = true;
    }

    private void DestroyDummy()
    {
        Destroy(dummy);
        TheWorldActive = false;
    }

    private bool walkable()
    {
        return moveable && !CameraControl;
    }

    private bool jumpable()
    {
        return m_Grounded && moveable && !CameraControl;
    }
}