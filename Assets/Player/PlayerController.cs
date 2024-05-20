using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private float horizentalInput;
    private bool isplayerFaceRitgh = true;
    private InputAction _input;

    [Header("jump settings")] [SerializeField]
    private Transform groundCheckPoint;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float jumpPower;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private float JumpBufferCounter;
    
    [SerializeField] private float speed;


    private playerState _playerState;
    
    [SerializeField] private Animator _animator;
    private static readonly int moveing = Animator.StringToHash("move");
    private static readonly int jumping = Animator.StringToHash("jump");
    private static readonly int attack1 = Animator.StringToHash("attack1");



    // Start is called before the first frame update
    void Start()
    {
        _playerState = GetComponent<playerState>();
        rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }

    
    
    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(horizentalInput * speed, rb2d.velocity.y);
        // _animator.SetBool(moveing, rb2d.velocity.x != 0.0f && IsGrounded());
        // _animator.SetBool(jumping, !IsGrounded());
        if (!isplayerFaceRitgh && horizentalInput > 0)
        {
            flip();
        }
        
        if (isplayerFaceRitgh && horizentalInput < 0)
        {
            flip();
            
        }
    }


    private void flip()
    {
        isplayerFaceRitgh = !isplayerFaceRitgh;
        Vector3 localScale = transform.localScale;
        localScale = new Vector2( localScale.x *-1 ,localScale.y ) ;
        transform.localScale = localScale;
    }

    public void jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            _playerState.Jumping = true;
        }
        
        if (context.performed && rb2d.velocity.y > 0.0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0.0f);
            _playerState.Jumping = false;
        }
        _animator.SetBool(moveing, rb2d.velocity.x != 0.0f && IsGrounded());
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position , groundCheckY, groundLayerMask);

 
    }
   public void Move(InputAction.CallbackContext context)
   {
       horizentalInput = context.ReadValue<Vector2>().x;
    
   }

   public void atacking()
   {
       _animator.SetBool(attack1, false);
   }

   private void UpdateJumpVariable()
   {

       if (IsGrounded())
       {
           _playerState.Jumping = false;
       }
   }
   
}
