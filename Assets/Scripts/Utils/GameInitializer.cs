using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    //[SerializeField]
    //GameObject spawnChar;

    //BoxCollider2D hitbox;

    private void Awake()
    {
        ScreenUtils.Initialize();
        //GameObject tempChar = Instantiate(spawnChar, Vector3.zero, Quaternion.identity);
        //hitbox = tempChar.GetComponent<BoxCollider2D>();
        //Destroy(tempChar);
        //Vector3 spawnLocation = GameObject.FindGameObjectWithTag("SpawnBlock").transform.position;
        //spawnLocation.y += hitbox.size.y * 3;
        //Instantiate(spawnChar, spawnLocation, Quaternion.identity);
    }
}
