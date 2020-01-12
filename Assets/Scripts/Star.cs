﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject sw;

    public bool collected = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && GameObject.Find("Player").GetComponent<PlayerMovement>().alive == true)
        {
            transform.localScale = new Vector3(0,0,0);
            sw.GetComponent<AnimationScript>().enabled = false;
            GetComponent<AnimationScript>().enabled = false;
            StartCoroutine(OnCollected());           
        }
    }

    IEnumerator OnCollected()
    {
        sw.GetComponent<Animation>().Play();
        while (sw.GetComponent<Animation>().isPlaying)
        {
            yield return null;
        }
        collected = true;
        gameObject.SetActive(false);
        sw.SetActive(false);
    }
}
