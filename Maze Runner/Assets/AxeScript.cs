using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxeScript : MonoBehaviour{

    PlayerController player;
    AudioSource source;

    bool infoon = false;
    bool axetaken = false;

    public GameObject infobg;
    public Text infotext;


    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        if (player.objaxefind >= 3){
            Destroy(this.gameObject);
        }
        if (player.runner || player.cook){
            Destroy(this.gameObject);
        }
    }

    void Update(){
        if (player.objaxefind >= 3){
            Destroy(this.gameObject);
        }
        if (player.runner || player.cook){
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
            if(player.objaxefind < 3 && !axetaken){
                axetaken = true;
                player.coins +=3;
                source.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Axe part picked".ToString();
                    infoon=true;
                }
                StartCoroutine(AxeDestroy());
            }
        }
    }
    IEnumerator AxeDestroy(){
        yield return new WaitForSeconds(2f);
        player.objaxefind++;
        Destroy(this.gameObject,1f);
    }
    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
