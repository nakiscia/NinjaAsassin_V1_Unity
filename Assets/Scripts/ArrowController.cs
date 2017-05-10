using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArrowController : MonoBehaviour {

    public float speed;

    Rigidbody2D myrigidbody;

    Vector2 direction;

    bool bowattack;

	// Use this for initialization
	void Start () {

        myrigidbody = GetComponent<Rigidbody2D>();
        bowattack = true;
	}

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        if(bowattack)
        { 
            myrigidbody.AddForce(direction * speed);
            bowattack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
