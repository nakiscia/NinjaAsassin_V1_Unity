using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState {


	private Enemy _enemy;

	float idleTimer;
	public float idleDuration;


	public void Enter(Enemy enemy)
	{
		_enemy = enemy;
		idleDuration = _enemy.idleDuration;
	}

	public void Execute()
	{
		Idle ();


		if (_enemy.Target!=null) {

				_enemy.ChangeState (new PatrolState ());


		}

	}

	public void Exit()
	{

	}

	public void OnTriggerEnter(Collider2D other)
	{


	}


	private void Idle()
	{
		
		_enemy.anim.SetFloat ("speed", 0);

		if (idleTimer>=idleDuration) {

			_enemy.ChangeState(new PatrolState());

		}

		idleTimer += Time.deltaTime;


	}


}
