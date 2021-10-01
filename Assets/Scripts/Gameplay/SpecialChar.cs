using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialChar : Player
{
    PlayerType playerType;

    public PlayerType CharacterType
    {
        set
        {
            playerType = value;
            if (playerType == PlayerType.Standard)
            {
                moveSpeed = 4.5f;
                jumpConstant = 7.5f;
                attackCd = 0.4f;
            }
            else if(playerType == PlayerType.Melancholic)
            {
                moveSpeed = 3f;
                jumpConstant = 6f;
                attackCd = 0.8f;
            }
            else if(playerType == PlayerType.Arsonist)
            {
                moveSpeed = 6f;
                jumpConstant = 8.8f;
                attackCd = 0.2f;
            }
            else if(playerType == PlayerType.Hectic)
            {
                moveSpeed = 4f;
                jumpConstant = 8;
                attackCd = 1f;
            }
        }
        get { return playerType; }
    }
}
