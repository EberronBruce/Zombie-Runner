﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

	[SerializeField] Transform target;
	[SerializeField] float chaseRange = 5f;

	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;
	bool isProvoked = false;

	void Start() {
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Update() {
		distanceToTarget = Vector3.Distance(target.position, transform.position);
		if(isProvoked) {
			Engagetarget();
		} else if(distanceToTarget <= chaseRange) {
			isProvoked = true;
		}
	}

	private void Engagetarget() {
		if(distanceToTarget >= navMeshAgent.stoppingDistance) {
			ChaseTarget();
		}

		if(distanceToTarget <= navMeshAgent.stoppingDistance) {
			AttacktTarget();
		}
	}

	private void ChaseTarget() {
		GetComponent<Animator>().SetBool("attack", false);
		GetComponent<Animator>().SetTrigger("move");
		navMeshAgent.SetDestination(target.position);
	}

	private void AttacktTarget() {
		GetComponent<Animator>().SetBool("attack", true);
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
}
