using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D theRigidBody;
    public float heroSpeed;
    public float forceOfJumping;
    private int maxJumps = 3;
    private int jumpsLeft;

    public bool onGround;
    public float distanceToGround;
    public LayerMask groundChecker;

    public bool jumpPowerChecker;

    private Animator animationController;
    public bool runningChecker;


    ///<summary> 
    /// The method defines the actions that happen at the beginning of the game. Start is called before the first frame update
    ///</summary> 
    void Start()
    {
        theRigidBody = GetComponent<Rigidbody2D> ();
        animationController = GetComponent<Animator> ();
        maxJumps -= 1;
        jumpsLeft = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0)
        {
            theRigidBody.velocity = new Vector2 ( heroSpeed, theRigidBody.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontalInput < 0)
        {
            theRigidBody.velocity = new Vector2 ( -heroSpeed, theRigidBody.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            theRigidBody.velocity = new Vector2(0, theRigidBody.velocity.y);
        }

        runningChecker = Mathf.Abs(horizontalInput) > 0;

        if(Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            theRigidBody.velocity = new Vector2 (theRigidBody.velocity.x, forceOfJumping);
            jumpsLeft -= 1;
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundChecker);

        if (onGround && theRigidBody.velocity.y <=0)
        {
            jumpsLeft = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpPowerChecker == false && jumpsLeft > 0)
        {
            theRigidBody.velocity = new Vector2 (theRigidBody.velocity.x, forceOfJumping);
            jumpsLeft += 1;
            jumpPowerChecker = true;
        }

        animationController.SetBool("RunningChecker", runningChecker);
        animationController.SetBool("onGround", onGround);
        animationController.SetFloat("JumpingStates", theRigidBody.velocity.y);

        if (theRigidBody.velocity.x !=0 && Input.GetKey(KeyCode.D) && onGround)
        {
            runningChecker = true;
        }
        else
        {
            runningChecker = false;
        }

    }
    

    ///<summary> 
    /// The method describes the actions when a GameObject with the tag "TripleJumpPower" enters the trigger zone of the GameObject
    ///<paramref name="collider"> 
    ///</summary> 
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("TripleJumpPower")) 
        {
            collider.gameObject.SetActive(false);
            jumpsLeft += 1;
            jumpPowerChecker = false;
            
        }
    }
}