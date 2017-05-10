using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    CapsuleCollider2D playerCollider;

    public EdgeCollider2D platformCollider;

    public EdgeCollider2D platformTrigger;

    Animator anim;

	// Use this for initialization
	void Start () {

        playerCollider = GameObject.Find("Character").GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(platformCollider,platformTrigger, true);
        anim = GameObject.Find("Character").GetComponent<Animator>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
