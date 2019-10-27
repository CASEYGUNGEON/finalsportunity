using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericEnemyController : MonoBehaviour
{
    private GameObject player;
    public bool sawPlayer = false;
    public float speed;
    public float gravity;
    public Vector3[] patrolPointList;
    protected int nextPoint;
    protected Vector3 moveDirection;
    protected float moveX;
    protected float moveZ;

    // Start is called before the first frame update
    protected void Start()
    {
        player = GameObject.Find("railunity");
        transform.position = patrolPointList[0];
        nextPoint = 1;
    }

    // Update is called once per frame
    protected void Update()
    {
        
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
        sawPlayer = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, Vector3.Angle(transform.position,player.transform.position))) < 60;
    }
}