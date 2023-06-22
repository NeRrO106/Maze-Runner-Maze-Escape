using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour{

    PlayerController player;
    AudioSource source;

    bool infoon = false;
    public bool taken = false;

    public GameObject infobg;
    public Text infotext;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        
        if(player.objfind >= 5){
            Destroy(this.gameObject);
        }
        if(player.cook || player.builder){
            Destroy(this.gameObject);
        }
    }
    void Update(){
        if(player.objfind >= 5){
            Destroy(this.gameObject);
        }
        if (player.cook || player.builder){
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
            if(player.objfind < 5 && !taken){
                taken = true;
                player.coins +=3;
                player.collectedcoins +=3;
                source.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Chest picked".ToString();
                    infoon=true;
                }
                StartCoroutine(DestroyChest());
            }
        }
    }

    IEnumerator DestroyChest(){
        yield return new WaitForSeconds(2f);
        player.objfind++;
        Destroy(this.gameObject, 1f);
    }

    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
