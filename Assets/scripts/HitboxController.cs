using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public enum OwnerType
    {
        player, enemy
    };
    public OwnerType ownerType;

    public float DelayTime;
    private float DelayTimeLeft;
    public float secondsActive;
    private float curSecondsLeft = 0;
    private int attackPhase = 0;

    private BoxCollider hitbox;


    public void Attack()
    {
        DelayTimeLeft = DelayTime;
        curSecondsLeft = 0;
        attackPhase = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        hitbox = GetComponent<BoxCollider>();
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackPhase == 1)
        {
            if (DelayTimeLeft > 0)
            {
                DelayTimeLeft -= Time.deltaTime;

            }
            else
            {
                attackPhase = 2;
                curSecondsLeft = secondsActive;
                hitbox.enabled = true;
            }
        }
        else if(attackPhase == 2)
        {
            if(curSecondsLeft > 0)
            {
                curSecondsLeft -= Time.deltaTime;
            }
            else
            {
                hitbox.enabled = false;
                attackPhase = 0;
            }
        }
    }
}