using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour {

    
    public Transform[] patrolPoints;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
    public float speed;

    public Transform target;
    public float chaseRange;

    // Use this for initialization
    void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints [currentPatrolIndex];
	}
	
	// Update is called once per frame
	void Update () {

        #region Movement
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f){
            if (currentPatrolIndex + 1 < patrolPoints.Length){
                currentPatrolIndex++;
            }else {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints [currentPatrolIndex];
        }

        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        transform.Translate(patrolPointDir.normalized * Time.deltaTime * speed);
        //float angle = Mathf.Atan2 (patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
        #endregion

        #region Chasing
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
            transform.Translate(targetDir.normalized * Time.deltaTime * speed);
        }



        #endregion
    }
}
