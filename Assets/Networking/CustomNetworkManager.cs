using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class CustomNetworkManager : NetworkManager
{
    public GameObject[] playerPrefabs;
    public bool sphere = false;
    public GameObject spawn;
    GameObject player;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        if (sphere)
        {
            player = (GameObject)Instantiate(playerPrefabs[1], spawn.transform, true);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

        } else
        {
            player = (GameObject)Instantiate(playerPrefabs[0], spawn.transform, true);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        
    }
}