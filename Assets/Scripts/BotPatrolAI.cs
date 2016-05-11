//complete nav mesh ai script

using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System;
using System.Collections;

namespace UnityStandardAssets.Chararacters.ThirdPerson
{
	public class BotPatrolAI : MonoBehaviour
	{

		public Transform[] patrolPoints;
		public GameObject chaseTarget;
		public float patrolSpeed = 0.5f;
		public float pursueSpeed = 1.5f;
		public int pointIndex = 0;
		private int maxIndex;
		public float minWaypointDistance = 0.1f;
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
			navMeshAgent = GetComponentInChildren<NavMeshAgent> ();
			navMeshAgent.updatePosition = true;
			navMeshAgent.updateRotation = false;
			maxIndex = patrolPoints.Length - 1;

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

			Vector3 tempLocalPosition;
			Vector3 tempWaypointPosition;

			tempLocalPosition = transform.position;
			tempLocalPosition.y = 0f;

			// Current waypoints position (x, set y to 0, z)
			tempWaypointPosition = patrolPoints [pointIndex].position;
			tempWaypointPosition.y = 0f;

			if (Vector3.Distance (tempLocalPosition, tempWaypointPosition) <= minWaypointDistance) {

				if (pointIndex == maxIndex)
					pointIndex = 0;
				else
					pointIndex++;
			}

			// Set the destination for the agent
			// The navmesh agent is going to do the rest of the work
			navMeshAgent.SetDestination (patrolPoints [pointIndex].position);
			character.Move (navMeshAgent.desiredVelocity, false, false);

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

		void OnCollisionEnter (Collision collision)
		{
			if (collision.gameObject.tag == "FPSPlayer" && currentState == BotPatrolAI.State.PURSUING) {
				//Game Over
			}
		}

	}
}



