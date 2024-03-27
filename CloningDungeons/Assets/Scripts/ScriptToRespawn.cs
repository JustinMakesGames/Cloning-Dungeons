using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScriptToRespawn : MonoBehaviour
{
    public float distancetoDisappear;
    public GameObject[] players;

    private Vector3 _positionToSpawn;
    private bool _playersinRange;
    private readonly float timeForRespawning = 10f;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        _positionToSpawn = transform.position;
    }

    private void Update()
    {
        PlayersNotInRange();
        IfPlayersInRange();
    }

    private void PlayersNotInRange()
    {
        if (!_playersinRange)
        {
            StartCoroutine(RespawningKey());
        }
        else
        {
            StopCoroutine(RespawningKey());
        }
    }

    private void IfPlayersInRange()
    {
        foreach (GameObject player in players)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < distancetoDisappear)
            {
                _playersinRange = true;
                return;
            } 
        }

        _playersinRange = false;
        
    }

    IEnumerator RespawningKey()
    {
        transform.position = _positionToSpawn;
        yield return new WaitForSeconds(timeForRespawning);
    }
}
