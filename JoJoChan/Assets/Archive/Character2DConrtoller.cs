using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Character2DConrtoller : MonoBehaviour
{
    public PowerUse power;

    public float MovementSpeed = 10;
    public float JumpForce = 50;
    public int Health = 1;
    public int CharacterState = 1;                                              // 1 - usual state
                                                                                // 2 - shadow state
                                                                                // 0 - death state
    private bool m_Grounded;
    const float k_GroundedRadius = .2f;

    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private LayerMask m_WhatIsDamageGround;                    // A mask determining what is damage to the character
    [SerializeField] private LayerMask m_WhatIsPotion;                          // A mask determining what is potion to the character
    [SerializeField] private LayerMask m_WhatIsDoor;                          // A mask determining what is door to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    public UnityEvent OnCollideEvent;
    public UnityEvent OnCollidePotionEvent;
    public UnityEvent OnCollideDoorEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public Animator animator;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        m_Grounded = true;
    }

    public void OnColliding()
    {
        Health -= 1;
    }

    public void OnCollidingPotion()
    {
        Collider2D[] potionColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsPotion);
        Destroy(potionColliders[0].gameObject);
        power.currentTime += 5.0f;
    }

    public void OnCollidingDoor()
    {
        power.currentTime = .0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        Collider2D[] damageColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsDamageGround);
        for (int i = 0; i < damageColliders.Length; i++)
        {
            if (damageColliders[i].gameObject != gameObject)
            {
                OnCollideEvent.Invoke();
            }
        }

        Collider2D[] potionColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsPotion);
        for (int i = 0; i < potionColliders.Length; i++)
        {
            if (potionColliders[i].gameObject != gameObject)
            {
                OnCollidePotionEvent.Invoke();
            }
        }

        Collider2D[] doorColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsDoor);
        for (int i = 0; i < doorColliders.Length; i++)
        {
            if (doorColliders[i].gameObject != gameObject)
            {
                OnCollideDoorEvent.Invoke();
            }
        }
    }

    private void Update()
    {
        if (CharacterState == 2)
        {
            _rigidbody.isKinematic = true;
            GetComponent<Collider2D>().enabled = false;
            animator.enabled = false;
        }

        if (CharacterState != 2)
        {
            if (Input.GetButtonDown("Jump") && m_Grounded)
            {
                animator.SetBool("IsJumping", true);
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
            if (Input.GetButtonUp("Jump") && _rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.3f);
            }

            var movement = Input.GetAxis("Horizontal");

            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

            animator.SetFloat("Speed", Mathf.Abs(movement));

            if (!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            }

            animator.SetFloat("velocity.y", _rigidbody.velocity.y);

            _rigidbody.isKinematic = false;
            GetComponent<Collider2D>().enabled = true;
            animator.enabled = true;
        }

        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}