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
        if(!sawPlayer)
        {
            FollowPath();
            CheckLineOfSight();
        }
        
    }
}