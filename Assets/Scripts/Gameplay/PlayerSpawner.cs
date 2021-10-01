using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    float respawnDuration;
    [SerializeField]
    GameObject player0;
    [SerializeField]
    CinemachineVirtualCameraBase playerCamera;

    Vector3 spawnLocation;
    Timer respawnTimer;
    BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempChar = Instantiate(player0, transform.position, Quaternion.identity);
        hitbox = tempChar.GetComponent<BoxCollider2D>();
        Destroy(tempChar);
        spawnLocation = GameObject.FindGameObjectWithTag("SpawnBlock").transform.position;
        spawnLocation.y += hitbox.size.y * 3;
        GameObject spawnChar = Instantiate(player0, spawnLocation, Quaternion.identity);
        spawnChar.GetComponent<SpecialChar>().CharacterType = PlayerType.Standard;

        respawnTimer = gameObject.AddComponent<Timer>();
        EventManager.AddPlayerDeathListener(StartRespawnTimer);
        playerCamera.Follow = spawnChar.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnTimer.ElapsedSeconds >= respawnDuration)
        {
            GameObject newPlayer = Instantiate(player0, spawnLocation, Quaternion.identity);
            newPlayer.GetComponent<SpecialChar>().CharacterType = PlayerType.Standard;
            respawnTimer.Stop();
            playerCamera.Follow = newPlayer.transform;
        }
    }

    void StartRespawnTimer()
    {
        respawnTimer.Run();
    }
}
