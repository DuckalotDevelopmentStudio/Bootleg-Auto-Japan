using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomLobbyManager : NetworkLobbyManager
{
    
    public GameObject[] playerPrefabs;
    public bool sphere = false;
    public GameObject spawn;
    GameObject player;

    public override GameObject OnLobbyServerCreateGamePlayer(NetworkConnection conn, short playerControllerId)
    {
        if(sphere)
        {
            GameObject player = Instantiate(playerPrefabs[0], spawn.transform);
            ClientScene.RegisterPrefab(player);
            return player;
        } else
        {
            GameObject player = Instantiate(playerPrefabs[0], spawn.transform);
            ClientScene.RegisterPrefab(player);
            
            return player;
        }
    }
}
