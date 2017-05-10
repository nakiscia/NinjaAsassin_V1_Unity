using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

	public Enemy _enemy;


	//When the player enter the collider (see it)
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag=="Player") {

			_enemy.Target = other.gameObject;
			
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{

		_enemy.Target = null;
		ResetValues ();

	}


	void ResetValues()
	{
		_enemy.maxSpeed = 6;
		_enemy.anim.SetFloat ("runspeed", 0);
		_enemy.anim.SetFloat ("speed", 0);

	}


}
