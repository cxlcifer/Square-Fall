using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] private UnityEvent _playerDied;
    [SerializeField] private UnityEvent _squareCollected;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GlobalConstants.ALLY_TEG))
        {
            _squareCollected.Invoke();
            Destroy(col.gameObject);
        }

        if (col.CompareTag(GlobalConstants.ENEMY_TEG))
        {
            _playerDied.Invoke();
            Destroy(col.gameObject);
        }
    }
}
