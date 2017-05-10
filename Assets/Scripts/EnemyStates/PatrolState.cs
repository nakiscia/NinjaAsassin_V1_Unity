using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {



	Enemy _enemy;

	float patrolTimer;
	public float patrolDuration;


	public void Enter(Enemy enemy)
	{
		_enemy = enemy;
		patrolDuration = _enemy.patrolDuration;

	}

	public void Execute()
	{
		Patrol ();


		if (_enemy.Target!=null) {

			if (_enemy.enemyType == Enemy.EnemyType.Archer) {
				
				_enemy.ChangeState (new RangedState());

			}
			else if (_enemy.enemyType == Enemy.EnemyType.Warrior) {

				_enemy.ChangeState (new MeeleState ());
			}


		}
	}

	public void Exit()
	{

	}

	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "PatrollingEdge") {

			_enemy.flipTheHero ();
		}

	}

	void Patrol()
	{

		_enemy.anim.SetFloat ("speed", 1);

		if (patrolTimer>=patrolDuration) {

			_enemy.ChangeState(new IdleState());
		}

		patrolTimer += Time.deltaTime;

		_enemy.HandleMovement();



	}


}
