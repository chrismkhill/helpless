using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System;
using System.Collections;

namespace UnityStandardAssets.Chararacters.ThirdPerson
{
	public class BotPatrolAI : MonoBehaviour
	{
		public Transform botGuardingTransform;
		public Transform[] patrolPoints;
		public GameObject[] originPoints;
		public GameObject chaseTarget;
		public float patrolSpeed = 5.0f;
		public int curWayPoint = 0;
		public float pursueSpeed = 9.0f;
		private Transform startingPoint;
		private NavMeshAgent navMeshAgent;
		public ThirdPersonCharacter character;

		public enum State
		{
			PATROLLING,
			PURSUING
		}

		public State currentState;

		bool botAlive = true;



		// Use this for initialization
		void Start ()
		{
			character = GetComponent<ThirdPersonCharacter> ();
			startingPoint = GetComponent<Transform> ();
			navMeshAgent = GetComponentInChildren<NavMeshAgent> ();
			navMeshAgent.updatePosition = true;
			navMeshAgent.updateRotation = false;

			currentState = BotPatrolAI.State.PATROLLING;

			StartCoroutine ("StartStateSequence");

		}


		IEnumerator StartStateSequence ()
		{
			while (botAlive) {
				switch (currentState) {
				case State.PATROLLING:
					Patrol ();
					break;
				case State.PURSUING:
					ChasePlayer ();
					break;
				}
				yield return null;
			}
		}


		void Patrol ()
		{
			navMeshAgent.speed = patrolSpeed;
			if (Vector3.Distance (this.gameObject.transform.position, originPoints [curWayPoint].transform.position) >= 2) {
				navMeshAgent.SetDestination (originPoints [curWayPoint].transform.position);
				character.Move (navMeshAgent.desiredVelocity, false, false);
			} else if (Vector3.Distance (this.gameObject.transform.position, originPoints [curWayPoint].transform.position) <= 2) {
				curWayPoint += 1;

				if (curWayPoint > originPoints.Length) {
					curWayPoint = 0;
				}
			} else {
				character.Move (Vector3.zero, false, false);
			}
				
		}

		void ChasePlayer ()
		{
			navMeshAgent.speed = pursueSpeed;
			navMeshAgent.SetDestination (chaseTarget.transform.position);
			character.Move (navMeshAgent.desiredVelocity, false, false);

		}

		void OnTriggerEnter (Collider collider)
		{
			if (collider.tag == "FPSPlayer") {
				currentState = BotPatrolAI.State.PURSUING;
				chaseTarget = collider.gameObject;
			}
				
		}

	}
}


