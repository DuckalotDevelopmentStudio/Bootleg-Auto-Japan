using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterReplace : NetworkBehaviour {
    
    [Command]
    public void Cmd_ReplacePlayer(GameObject playerPrefab)
    {
        GameObject GO = Instantiate(playerPrefab, transform.position, transform.rotation);
        NetworkServer.Spawn(GO);
        if (NetworkServer.ReplacePlayerForConnection(connectionToClient, GO, playerControllerId))
        {
            NetworkServer.Destroy(gameObject);
        }
    }

}
