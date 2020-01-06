using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullController : genericEnemyController
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (!sawPlayer)
        {
            CheckLineOfSight();
            FollowPath();
        }
        else
        {
            transform.LookAt(player.transform);
            if(speed < maxSpeed)
            {
                speed += accel;
                if (speed > maxSpeed)
                    speed = maxSpeed;
            }
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        base.Update();
    }
}