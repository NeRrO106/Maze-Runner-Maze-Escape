using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarlicScript : MonoBehaviour
{
    PlayerController player;
    AudioSource source;
    bool infoon = false;
    bool garlictaken = false;

    public GameObject infobg;
    public Text infotext;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        if(player.garlic == 6){
            Destroy(this.gameObject);
        }
        if(player.runner || player.builder){
            Destroy(this.gameObject);
        }
    }

    void Update(){
        if(player.garlic == 6){
            Destroy(this.gameObject);
        }
        if (player.runner || player.builder){
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
            if(!garlictaken){
                player.coins +=5;
                player.objfind++;
                garlictaken = true;
                source.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Garlic picked".ToString();
                    infoon=true;
                }
                StartCoroutine(DestroyGarlic());
            }
        }
    }
    IEnumerator DestroyGarlic(){
        yield return new WaitForSeconds(2f);
        player.garlic = 6;
        Destroy(this.gameObject,1f);
    }
    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
