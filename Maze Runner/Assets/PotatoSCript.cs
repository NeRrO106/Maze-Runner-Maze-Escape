using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotatoSCript : MonoBehaviour{
    
    PlayerController player;
    AudioSource source;

    bool infoon = false;
    bool potatotaken = false;

    public GameObject infobg;
    public Text infotext;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        if(player.potatos == 6){
            Destroy(this.gameObject);
        }
        if(player.runner || player.builder){
            Destroy(this.gameObject);
        }
    }

    void Update(){
        if(player.potatos == 6){
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
            if(!potatotaken){
                player.coins +=5;
                player.objfind++;
                potatotaken = true;
                source.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Potato picked".ToString();
                    infoon=true;
                }
                StartCoroutine(DestroyPotato());
            }
        }
    }
    IEnumerator DestroyPotato(){
        yield return new WaitForSeconds(2f);
        player.potatos = 6;
        Destroy(this.gameObject,1f);
    }
    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
