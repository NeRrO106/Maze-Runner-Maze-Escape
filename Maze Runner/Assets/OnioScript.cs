﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnioScript : MonoBehaviour
{
    PlayerController player;
    AudioSource source;

    bool infoon = false;
    bool oniontaken = false;

    public GameObject infobg;
    public Text infotext;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        if(player.onion == 6){
            Destroy(this.gameObject);
        }
        if(player.runner || player.builder){
            Destroy(this.gameObject);
        }
    }

    void Update(){
        if(player.onion == 6){
            Destroy(this.gameObject);
        }
        if(player.runner || player.builder){
            Destroy(this.gameObject);
        }
        float distance;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 10f){
            SavingSystem.SavePlayer(player);
        }
        if(infoon){
            StartCoroutine(InfoDelay());
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if(!oniontaken){
                player.coins +=5;
                oniontaken = true;
                player.objfind++;
                source.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Onion picked".ToString();
                    infoon=true;
                }
                StartCoroutine(DestroyOnion());
            }
        }
    }
    IEnumerator DestroyOnion(){
        yield return new WaitForSeconds(2f);
        player.onion = 6;
        Destroy(this.gameObject,1f);
    }
    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
