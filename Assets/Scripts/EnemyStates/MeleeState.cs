using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleState : IEnemyState {

	Enemy _enemy;

	float attackRange = 5;
	bool isInMeleRange;

	float attackTimer;
	float attackCoolDown;

	float runSpeed = 15;

	bool canAttack = true;


	public void Enter(Enemy enemy)
	{
		_enemy = enemy;
		attackCoolDown = _enemy.attackCoolDown;
	}

	public void Execute()
	{
		if (_enemy.Target!=null) {
			
		

			isInMeleRange = (Vector2.Distance (_enemy.transform.position, _enemy.Target.transform.position)<=attackRange) ? true : false  ;


			if (isInMeleRange) {

				attackTheTarget();
			} else {
				runTheTarget ();
			}

		} else {
			

			_enemy.ChangeState (new IdleState ());


		}


	}

	public void Exit()
	{
			
	}

	public void OnTriggerEnter(Collider2D other)
	{


	}


	void runTheTarget()
	{

		_enemy.anim.SetFloat ("runspeed", 1);
		_enemy.maxSpeed = runSpeed;
		_enemy.HandleMovement ();


	}


	void attackTheTarget()
	{
		_enemy.rg.velocity = Vector2.zero;
		_enemy.anim.SetFloat ("runspeed", 0);
		_enemy.anim.SetFloat ("speed", 0);


		if (attackTimer>=attackCoolDown) {
			canAttack = true;
			attackTimer = 0;
		}

		if (canAttack) {
			_enemy.attacking = true;
			_enemy.HandleAttack ();
			canAttack = false;
		}

		attackTimer += Time.deltaTime;



	}


}
