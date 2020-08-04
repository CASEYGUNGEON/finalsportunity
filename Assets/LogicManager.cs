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

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.InstantiatePlayer(position: new Vector3(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}