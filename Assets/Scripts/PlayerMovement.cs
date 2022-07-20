using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 3f;
    [SerializeField]
    private float walkingForce = 8f;
    [SerializeField]
    private float runningForce = 9f;
    private float movementX, yVelocity;
    private bool isGrounded;
    private Rigidbody2D myBody;
    private SpriteRenderer mySprite;

    private string WALK_ANIMATION = "Walk";
    private string RUN_ANIMATION = "Run";
    private string ATTACK_ANIMATION = "Attack";

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    bool flip;
    bool _object;

    private Animator anim;
    private const float shieldDistance = 2f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        flip = false;
    }
    void Update()
    {

        yVelocity = myBody.velocity.y;
        PlayerMoveKeyboard();
        WalkAnimation();
        Run();
        Attack();
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void WalkAnimation()
    {
        if (movementX > 0)
        {
            if (flip)
            {
                flip = false;
                transform.Rotate(0f, 180f, 0);
            }

            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            if (!flip)
            {
                transform.Rotate(0f, 180f, 0);
                flip = true;
            }
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && movementX != 0)
        {
            moveForce = runningForce;
            anim.SetBool(RUN_ANIMATION, true);
        }
        if (Input.GetKey(KeyCode.LeftShift) && movementX != 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveForce = walkingForce;
            anim.SetBool(RUN_ANIMATION, false);
        }
    }

    void Attack()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextAttackTime)
            {
                anim.SetBool(ATTACK_ANIMATION, true);
                
            }
            nextAttackTime = Time.time + 1f / attackRate;

        }   

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool(ATTACK_ANIMATION, false);
        }
        
    }

}
