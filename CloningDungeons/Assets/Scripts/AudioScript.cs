using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public AudioSource[] audiosources;
    public float timer;
    public float endtimer;
    public int random;
    // Start is called before the first frame update
    void Start()
    {
        audiosources = GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > endtimer)
        {
            random = Random.Range(0, audiosources.Length);
            for (int i = 0; i < audiosources.Length; i++)
            {
                if (i == random)
                {
                    if (audiosources[i].isPlaying)
                    {
                        random = Random.Range(0, audiosources.Length);
                    }
                    else
                    {
                        audiosources[i].Play();
                    }
                    
                }
            }

            timer = 0f;
        }
        
    }
}
