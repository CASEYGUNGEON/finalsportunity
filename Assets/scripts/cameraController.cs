using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Vector3 offset;
    public playerController player;
    private Camera cam;
    private Plane plane;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        plane = new Plane(Vector3.up, player.transform.position);
    }

    public Ray GetMouseRay()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
    public Vector3 GetScreenPos(Vector3 worldPos)
    {
        return cam.WorldToScreenPoint(worldPos);
    }
}