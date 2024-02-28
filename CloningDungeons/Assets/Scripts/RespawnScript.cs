using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public List<Respawning> respawnscripts;
    // Start is called before the first frame update
    void Start()
    {
        respawnscripts.Add(FindObjectOfType<Respawning>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "SmallPlayer")
        {
            foreach (Respawning s in respawnscripts)
            {
                s.respawntime = true;
            }
        }
    }
}
