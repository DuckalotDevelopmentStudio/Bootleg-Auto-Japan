using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupCharacter : NetworkBehaviour {
    public GameObject[] avatars;
    public Color avatarColor;

    private void Update()
    {
        if (localPlayerAuthority)
        {
            if (avatarColor == Color.red)
            {
                GetComponent<CharacterReplace>().Cmd_ReplacePlayer(avatars[0]);
            }
            if (avatarColor == Color.blue)
            {
                GetComponent<CharacterReplace>().Cmd_ReplacePlayer(avatars[1]);
            }
        }
    }


}
