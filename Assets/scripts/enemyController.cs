using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericEnemyController : MonoBehaviour
{
    public playerController player;
    public bool sawPlayer = false;
    public float sightDist;
    public float sightAngle;
    public float accel;
    public float speed;
    public float maxSpeed;
    public float gravity;
    public Vector3[] patrolPointList;
    protected int nextPoint;
    protected Vector3 moveDirection;
    protected float moveX;
    protected float moveZ;
    protected float angleDiff;

    // Start is called before the first frame update
    protected void Start()
    {
        transform.position = patrolPointList[0];
        nextPoint = 1;
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    protected void FollowPath()
    {
        //TODO: gravity
        moveX = 0;
        moveZ = 0;
        if (Mathf.Abs(transform.position.x - patrolPointList[nextPoint].x) > .4)
        {
            moveX = Mathf.Sign(patrolPointList[nextPoint].x - transform.position.x);
        }
        else
        {
            transform.position = new Vector3(patrolPointList[nextPoint].x, transform.position.y, transform.position.z);
        }
        if (Mathf.Abs(transform.position.z - patrolPointList[nextPoint].z) > .4)
        {
            moveZ = Mathf.Sign(patrolPointList[nextPoint].z - transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, patrolPointList[nextPoint].z);
        }
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection *= speed;
        transform.position += moveDirection * Time.deltaTime;
        if (Vector3.Distance(transform.position, patrolPointList[nextPoint]) < .4)
        {
            if (++nextPoint == patrolPointList.Length)
                nextPoint = 0;
            transform.LookAt(patrolPointList[nextPoint]);
        }
    }

    protected void CheckLineOfSight()
    {
        Vector3 toOther = (transform.position - player.transform.position).normalized;
        angleDiff = Vector3.Angle(transform.forward*-1,toOther);
        sawPlayer = angleDiff < sightAngle && Vector3.Distance(transform.position,player.transform.position) < sightDist;
    }

    protected void HurtPlayer()
    {
        player.TakeDamage();
    }
}