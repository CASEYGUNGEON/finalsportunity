using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public cameraController cam;
    public playerController playerPrefab;
    public GameObject spawn1;

    // Start is called before the first frame update
    void Start()
    {
        spawn1 = GameObject.Find("spawn1");
        NetworkManager.Instance.InstantiatePlayer(position: spawn1.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}