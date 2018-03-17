using UnityEngine;
using UnityEngine.Networking;
using Prototype.NetworkLobby;

public class CustomLobbyHook : LobbyHook {

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, 
        GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        SetupCharacter localPlayer = gamePlayer.GetComponent<SetupCharacter>();
        localPlayer.avatarColor = lobby.playerColor;
        
    }

}
