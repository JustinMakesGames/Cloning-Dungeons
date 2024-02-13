using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] people;
    public bool flagtofind = true;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        people = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < people.Length; i++)
            {
                Movement move = people[i].GetComponent<Movement>();

                if (move.isPlayer == flagtofind)
                {
                    player = people[i];
                }

            }

            player.GetComponent<Movement>().isPlayer = false;
            int activeplayer = System.Array.IndexOf(people, player);

            if (activeplayer + 1 < people.Length)
            {
                people[activeplayer + 1].GetComponent<Movement>().isPlayer = true;
            }
            else
            {
                people[0].GetComponent<Movement>().isPlayer = true;
            }
        }
        

       
    }
}
