using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera playerCam;
    [SerializeField]
    GameObject player0;
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject currPlayer = GameObject.FindGameObjectWithTag("Player");
            if(currPlayer == null)
            {
                return;
            }
            Vector3 currLocation = currPlayer.transform.position;
            Vector2 currVelocity = currPlayer.GetComponent<Rigidbody2D>().velocity;
            Destroy(currPlayer);
            GameObject newPlayer;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                newPlayer = Instantiate(player0, currLocation, Quaternion.identity);
                newPlayer.GetComponent<SpecialChar>().CharacterType = PlayerType.Standard;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                newPlayer = Instantiate(player1, currLocation, Quaternion.identity);
                newPlayer.GetComponent<SpecialChar>().CharacterType = PlayerType.Arsonist;
            }
            else
            {
                newPlayer = Instantiate(player2, currLocation, Quaternion.identity);
                newPlayer.GetComponent<SpecialChar>().CharacterType = PlayerType.Melancholic;
            }
            newPlayer.GetComponent<Rigidbody2D>().velocity = currVelocity;
            playerCam.Follow = newPlayer.transform;
        }
    }
}
