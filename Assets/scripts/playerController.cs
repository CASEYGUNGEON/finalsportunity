using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    public cameraController cam;
    private Vector3 moveDirection;
    private CharacterController charCon;
    private bool hurt;
    private Animator animator;
    private float timeOfPress;
    private bool mouseLocked;
    private Plane plane;
    private bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hurt)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            if (!charCon.isGrounded)
            {
                moveDirection += new Vector3(0, -gravity, 0);
            }
            charCon.Move(moveDirection * Time.deltaTime);

            if (!attacking)
            {
                plane = new Plane(Vector3.up, transform.position);
                Ray ray = cam.GetMouseRay();
                float hit;
                plane.Raycast(cam.GetMouseRay(), out hit);
                transform.LookAt(ray.GetPoint(hit));
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!mouseLocked)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    mouseLocked = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    mouseLocked = false;
                }
            }


            if (Input.GetMouseButtonDown(0))
            {
                animator.SetInteger("playerState", 1);
                timeOfPress = Time.time;
                attacking = true;
            }
            if (!Input.GetMouseButton(0) && Time.time - timeOfPress > 0.2f)
            {
                animator.SetInteger("playerState", 2);
                attacking = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        int layer = other.gameObject.layer;
        if (layer == 9 || layer == 10)
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        hurt = true;
        StartCoroutine(DeathRestart());
    }

    IEnumerator DeathRestart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}