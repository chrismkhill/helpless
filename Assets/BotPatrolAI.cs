using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System;
using System.Collections;


public class BotPatrolAI : MonoBehaviour
{
	public Transform botGuardingTransform;
	public Transform[] patrolPoints;
	public float speed = 5.0f;
	public int curWayPoint = 0;
	public float pursueSpeed = 9.0f;
	private Transform startingPoint;
	private NavMeshAgent navMeshAgent;
	public ThirdPersonCharacter character;
	public GuardState currentState;


	public enum GuardState
	{
		PATROLLING,
		PURSUING
	}

	// Use this for initialization
	void Start ()
	{
		character = this.gameObject.GetComponent<ThirdPersonCharacter> ();
		startingPoint = this.gameObject.GetComponent<Transform> ();
		navMeshAgent = this.gameObject.GetComponent<NavMeshAgent> ();

		currentState = BotPatrolAI.GuardState.PATROLLING;

	}

	void Patrol ()
	{

	}

	void ChasePlayer ()
	{


	}

	void OnTriggerEnter (Collider collider)
	{

	}


	
	// Update is called once per frame
	void Update ()
	{
	


	}
}
