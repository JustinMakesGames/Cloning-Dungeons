using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform bigClone;
    public Transform smallClone;
    public TMP_Text damageText;

    private void Start()
    {
        bigClone = GameObject.Find("Clones").transform.GetChild(0);
        smallClone = GameObject.Find("Clones").transform.GetChild(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer.timer -= 30;
            StartCoroutine(TimePunishment());
            bigClone.position = transform.GetChild(0).position;
            smallClone.position = transform.GetChild(1).position;
        }
    }

    private IEnumerator TimePunishment()
    {
        damageText.gameObject.SetActive(true);
        damageText.text = "-30";
        yield return new WaitForSeconds(1);
        damageText.gameObject.SetActive(false);

    }
}
