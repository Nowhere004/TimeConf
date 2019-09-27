using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveScript : MonoBehaviour
{
    private PlayerSaveData playerSaveData;
    private PlayerData playerData;
    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
        CustomEventSystem.SaveInitiated += Save;
    }
    private void Save()
    {
        playerSaveData = new PlayerSaveData(playerData);
        SaveLoad.Save<PlayerSaveData>(playerSaveData,"Player");
    }

    private void Load()
    {
        playerSaveData = SaveLoad.Load<PlayerSaveData>("Player");
        Vector3 position;
        position.x = playerSaveData.playerPosition[0];
        position.y = playerSaveData.playerPosition[1];
        position.z = playerSaveData.playerPosition[2];
        transform.position = position;
    }
}
