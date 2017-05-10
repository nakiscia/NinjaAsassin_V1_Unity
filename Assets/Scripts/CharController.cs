using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class CharController : CharacterController {



	/* About Jumping */ 
	public float jumpHeight = 50f;
	bool grounded;
	public Transform groundCheck;
	float groundRadius = 5f;
	public LayerMask whatisGround;





    // Use this for initialization
    public override void Start () {

        base.Start();
    }

	void Update(){
        
    }


	void FixedUpdate () {
		

        //Movement Handling
		HandleMovement ();
        // Attack Handling
        HandleAttack();
        // Jump Handling
        HandleJump();
        

	}


	public void jumpMobileEvent()
	{

		// Jump key
		if (grounded&&rg.velocity.y==0) {
            
            grounded = !grounded;
            rg.AddForce(new Vector2(0, jumpHeight));
            HandleJump();
		}

	}

	public override void HandleMovement()
    {


        /* with this statement we chech if current animation 
		 * in base layer is not player_attack
		 * we just move the player.
		*/

        if (!(anim.GetCurrentAnimatorStateInfo(0).IsTag("attacking")))
        {

            float move = CrossPlatformInputManager.GetAxis("Horizontal");
            rg.velocity = new Vector2(move * maxSpeed, rg.velocity.y);
            //Activate The Animation 

            anim.SetFloat("speed", Mathf.Abs(move));
            if (move > 0 && !rightFace)
                flipTheHero();
            else if (move < 0 && rightFace)
                flipTheHero();

        }
    }

    public void attackMobileEvent()
    {
        attacking = true;
    }

    private void HandleJump()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatisGround);
		anim.SetBool ("grounded", grounded);
		anim.SetFloat ("vspeed", rg.velocity.y);
		
	}





}
