using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour{
    PlayerController player;
    AudioSource source;

    bool infoon = false;
    bool cointaked = false;

    public GameObject infobg;
    public Text infotext;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        if(player.collectcoins >= 31){
            Destroy(this.gameObject);
        }
        if(player.cook || player.builder){
            Destroy(this.gameObject);
        }
    }
    
    void Update(){
        if(player.collectcoins >= 31){
            Destroy(this.gameObject);
        } 
        if(player.cook || player.builder){
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
            if(player.collectcoins < 31 && !cointaked){
                player.coins +=2;
                player.collectedcoins +=2;
                cointaked = true;
                source.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Coin picked".ToString();
                    infoon=true;
                }
                StartCoroutine(CoinDestroy());
            } 
        }
    }

    IEnumerator CoinDestroy(){
        yield return new WaitForSeconds(2f);
        player.collectcoins++;
        Destroy(this.gameObject, 1f);
    }

    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
