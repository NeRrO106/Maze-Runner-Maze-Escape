using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour{
    
    PlayerController player;
    AudioSource source;
    Rigidbody rgb;

    public float health = 100f;
    bool alreadyFallen = false;
    bool infoon = false;

    public GameObject copac;

    public GameObject infobg;
    public Text infotext;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody>();
        if(player.cook){
            Destroy(this.gameObject);
        }
        rgb.isKinematic = true;
        copac = this.gameObject;
    }

    void Update(){
        if(player.cook){
            Destroy(this.gameObject);
        }
        if(infoon){
            StartCoroutine(InfoDelay());
        }
    }

    public void TakeDamage(float _damage){
        if(health >=_damage && !alreadyFallen){
            health -= _damage;
            source.Play();
        }
        if(health == 0 && !alreadyFallen){
            rgb.isKinematic = false;
            rgb.AddForce(transform.forward*4);
            player.logs += 4;
            SavingSystem.SavePlayer(player);
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Tree cutted(+4 logs)".ToString();
                infoon=true;
            }
            Die();
        }
    }

    void Die(){
        alreadyFallen = true;
        StartCoroutine(DieDelay());
    }
    IEnumerator DieDelay(){
        yield return new WaitForSeconds(5f);
        Destroy(copac);
    }

    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
