using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState {

	Enemy _enemy;

	float throwTimer;
	float throwCoolDown=2;
	bool canThrow=true;

	public void Enter(Enemy enemy)
	{
		_enemy = enemy;
	}

	public void Execute()
	{

		if (_enemy.Target!=null) {

			ThrowArrow ();

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

	void ThrowArrow()
	{
		throwTimer += Time.deltaTime;

		_enemy.anim.SetFloat ("speed", 0);

		if (throwTimer>=throwCoolDown) {

			canThrow = true;
			throwTimer = 0;

		}

		if (canThrow) {
			
			_enemy.attacking = true;
			_enemy.HandleAttack ();
			canThrow = false;
		}

	}

}
