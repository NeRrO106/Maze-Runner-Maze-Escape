﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SpiderScript : MonoBehaviour{
    PlayerController player;
    NavMeshAgent agent;
    Ads ads;
    public Animator animator;
    public AudioSource spider;
    public AudioSource gethit;
    public AudioSource dieing;
    float stopDistance;
    float damage = 10f;
    float health = 100f;
    
    float attackDelay = 2.5f;
    bool canAttack = true;
    public bool alreadydeath = false;
    bool doOnce = false;
    bool infoon = false;

    public GameObject infobg;
    public Text infotext;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ads = GetComponent<Ads>();
        if(player.spiderkill >= 1){
            Destroy(this.gameObject);
        }
        if(player.runner || player.cook){
            Destroy(this.gameObject);
        }
    }

    private void Update(){
        if(player.spiderkill >= 1){
            Destroy(this.gameObject);
        }
        if(player.runner || player.cook){
            Destroy(this.gameObject);
        }
        stopDistance = agent.stoppingDistance + 5f;
        float distance;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < stopDistance &&!alreadydeath){
            animator.SetFloat("Walking", 0f);
            if(canAttack == true){
                if(!doOnce){
                    spider.Play();
                    doOnce = true;
                }
                StartCoroutine(AttackDelay());
            }
        }
        if(infoon){
            StartCoroutine(InfoDelay());
        }
    }
    IEnumerator AttackDelay(){
        canAttack = false;
        player.TakeDamage(damage);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
        doOnce = false;
    }

    public void TakeDamage(float _damage){
        if(_damage <= health){
            health -= _damage;
        }
        else if(health <= _damage){
            health = 0f;
            alreadydeath = true;
            spider.Stop();
            player.coins += 15;
            animator.SetTrigger("Die");
            ads.ShowInterstitialAd();
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Spider killed".ToString();
                infoon=true;
            }
            Die();
        }
    }

    public void Die(){
        StartCoroutine(DieDelay());
    }
    IEnumerator DieDelay(){
        yield return new WaitForSeconds(3f);
        player.spiderkill = 1;
        SavingSystem.SavePlayer(player);
        Destroy(this.gameObject, 1f);
    }
    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
