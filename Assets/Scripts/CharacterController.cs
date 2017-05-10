using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    // Base class of the Characters. 

    public float maxSpeed = 0.9f;
    public bool rightFace = true;
	public Animator anim;
	public Rigidbody2D rg;
	public bool attacking;


    // Use this for initialization
    public virtual void Start () {

        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void flipTheHero()
    {
        rightFace = !rightFace;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void HandleAttack()
    {
        // if attack key triggered and the current attack animations end 
        if (attacking && !(anim.GetCurrentAnimatorStateInfo(0).IsTag("attacking")))
        {
            this.anim.SetTrigger("attack");
            rg.velocity = Vector2.zero;
            ResetValues();
        }
    }


    public void ResetValues()
    {
        attacking = false;
    }

	public virtual void HandleMovement()
	{
		if (!attacking) {


			var direction = rightFace ? Vector2.right : Vector2.left;

			transform.Translate (direction * (maxSpeed * Time.deltaTime));
		}



	}






}
