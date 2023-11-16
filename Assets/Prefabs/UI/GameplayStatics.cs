using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayStatics
{
    static GameObject playerGameObject;

    public static void SetPlayerGameObject(GameObject playerObj)
    {
        playerGameObject = playerObj;
    }

    public static GameObject GetPlayerGameObject()
    {
        if(playerGameObject == null)
        {
            playerGameObject = GameObject.FindObjectOfType<PlayerCharacter>().gameObject;
        }
        return playerGameObject;
    }

}
