using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
 
    public bool smallcloneturn;
    public bool bigcloneturn;
    private AudioSource bigclonemusic;
    private AudioSource smallclonemusic;
    public float speed;

    private void Start()
    {
        bigcloneturn = true;
        bigclonemusic = transform.GetChild(0).GetComponent<AudioSource>();
        smallclonemusic = transform.GetChild(1).GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && bigcloneturn)
        {
            bigcloneturn = false;
            smallcloneturn = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && smallcloneturn)
        {
            bigcloneturn = true;
            smallcloneturn = false;
        }

        if (bigcloneturn)
        {
            if (bigclonemusic.volume != 1 || smallclonemusic.volume != 0)
            {
                bigclonemusic.volume += speed * Time.deltaTime;
                smallclonemusic.volume -= speed * Time.deltaTime;
            }
        }

        else if (smallcloneturn)
        {
            if (bigclonemusic.volume != 0 || smallclonemusic.volume != 1)
            {
                bigclonemusic.volume -= speed * Time.deltaTime;
                smallclonemusic.volume += speed * Time.deltaTime;
            }
        }
    }


}
