using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    private Vector3 moveDirection;
    private CharacterController charCon;

    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        if (!charCon.isGrounded)
        {
            moveDirection += new Vector3(0, -gravity, 0);
        }
        charCon.Move(moveDirection * Time.deltaTime);
    }
}