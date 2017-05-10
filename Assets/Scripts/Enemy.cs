using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterController {


	IEnemyState currentState;

	public enum EnemyType{

		Warrior,
		Wizard,
		Archer
	}


	public GameObject arrowPrefab;

	public EnemyType enemyType;

	public float idleDuration=3;
	public float patrolDuration =7;
	public float attackCoolDown = 3;

	public GameObject Target {get;set;}



	// Use this for initialization
	public override void Start () {

		base.Start ();
		ChangeState(new IdleState());

	}
	
	// Update is called once per frame
	void Update () 
	{
		currentState.Execute ();
		LookAtTarget ();

	}

	public void ChangeState(IEnemyState newState)
	{

		if (currentState != null) {

			currentState.Exit ();
		}

		currentState = newState;

		currentState.Enter (this);


	}

	void OnTriggerEnter2D(Collider2D other)
	{

		currentState.OnTriggerEnter (other);

	}




	void LookAtTarget()
	{

		if (Target!=null) {

			float xDir = Target.transform.position.x - transform.position.x;

			if (xDir<0 && rightFace || xDir>0 && !rightFace) {

				flipTheHero ();
			}


		}
	}

	public void runArrow(int value)
	{
		if (rightFace)
		{
			GameObject tmp = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
			tmp.GetComponent<ArrowController>().Initialize(Vector2.right);
		}
		else
		{

			GameObject tmp = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
			tmp.GetComponent<ArrowController>().Initialize(Vector2.left);

		}

	}
		


}
