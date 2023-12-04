using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main class which is responsible for player interaction with the game world.
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float heroSpeed;
    public float jumpForce;
    [SerializeField] private int maxJumps = 2;
    private int jumpsLeft;
    [SerializeField] private bool isAbleToTripleJump;

    public bool onGround;
    public float distanceToGround;
    public LayerMask groundLayer;

    public bool jumpPowerChecker;

    private Animator animationController;
    public bool runningChecker;


    ///<summary> 
    /// The method defines the actions that happen at the beginning of the game. Start is called before the first frame update
    /// We get Rigidboy2D & Animator components. Also set initial amount of jumps.
    ///</summary> 
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        animationController = GetComponent<Animator> ();
        if (maxJumps == 0) maxJumps = 2;
        jumpsLeft = maxJumps;
    }

    /// <summary>
    /// In Update we calculate physics (movement and jumping)
    /// </summary>
    void Update()
    {
        // Movement 
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            rb.velocity = new Vector2 (heroSpeed, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            rb.velocity = new Vector2 (-heroSpeed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.velocity = new Vector2 (0, rb.velocity.y);
        }

        runningChecker = Mathf.Abs(horizontalInput) > 0;

        // Jumping

        // Triple jump ^
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft == 0 && isAbleToTripleJump)
        {
            isAbleToTripleJump = false;
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            jumpsLeft -= 1;
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundLayer);

        if (onGround && rb.velocity.y <=0)
        {
            jumpsLeft = maxJumps;
        }

        animationController.SetBool("RunningChecker", runningChecker);
        animationController.SetBool("onGround", onGround);
        animationController.SetFloat("JumpingStates", rb.velocity.y);

        if (rb.velocity.x != 0 && Input.GetKey(KeyCode.D) && onGround)
        {
            runningChecker = true;
        }
        else
        {
            runningChecker = false;
        }
    }


    /// <summary>
    /// Method that sets ability to triple jump to true.
    /// </summary>
    public void SetIsAbleToTripleJump()
    {
        isAbleToTripleJump = true;
    }

    /// <summary>
    /// Method responsible for handling boost and starting the reset.
    /// </summary>
    public void UseSpeedBoost()
    {
        heroSpeed = 10;
        StartCoroutine(ResetTheSpeedAfterBoost());
    }

    /// <summary>
    /// Method responsible for resetting the boost after some time. (10 seconds in our case)
    /// </summary>
    private IEnumerator ResetTheSpeedAfterBoost()
    {
        yield return new WaitForSeconds(10f);

        heroSpeed = 5;
    }


    ///<summary> 
    /// The method describes the actions when a GameObject with the tag "TripleJumpPower" enters the trigger zone of the GameObject
    ///<paramref name="collider"> 
    ///</summary> 
    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.CompareTag("TripleJumpPower")) 
    //    {
    //        collider.gameObject.SetActive(false);
    //        jumpsLeft += 1;
    //        jumpPowerChecker = false;
    //    }
    //}
}