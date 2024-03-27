using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
 
    public bool smallCloneTurn;
    public bool bigCloneTurn;
    private AudioSource bigCloneMusic;
    private AudioSource smallCloneMusic;
    public float speed;

    private void Start()
    {
        bigCloneTurn = true;
        bigCloneMusic = transform.GetChild(0).GetComponent<AudioSource>();
        smallCloneMusic = transform.GetChild(1).GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && bigCloneTurn)
        {
            bigCloneTurn = false;
            smallCloneTurn = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && smallCloneTurn)
        {
            bigCloneTurn = true;
            smallCloneTurn = false;
        }

        if (bigCloneTurn)
        {
            if (bigCloneMusic.volume != 1 || smallCloneMusic.volume != 0)
            {
                bigCloneMusic.volume += speed * Time.deltaTime;
                smallCloneMusic.volume -= speed * Time.deltaTime;
            }
        }

        else if (smallCloneTurn)
        {
            if (bigCloneMusic.volume != 0 || smallCloneMusic.volume != 1)
            {
                bigCloneMusic.volume -= speed * Time.deltaTime;
                smallCloneMusic.volume += speed * Time.deltaTime;
            }
        }
    }


}
