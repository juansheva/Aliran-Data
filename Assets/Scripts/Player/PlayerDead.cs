using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : IDeadable
{
    private GameObject playerGameObject;
    private GameObject deadEffect;

    public PlayerDead(GameObject _playerGameObject, GameObject _deadEffect)
    {
        playerGameObject = _playerGameObject;
        deadEffect = _deadEffect;
    }

    public void Dead()
    {
        Object.Instantiate(deadEffect, playerGameObject.transform.position, Quaternion.identity);
        Object.Destroy(playerGameObject);
    }
}