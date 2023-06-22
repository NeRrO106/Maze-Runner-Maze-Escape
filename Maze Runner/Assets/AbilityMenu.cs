using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class AbilityMenu : MonoBehaviour{
    
    public AbilityMenu2 ability;

    public GameObject AbilityScreen;
    public CanvasSettings canvas;

    PlayerController player;

    AudioSource click;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        click = GetComponent<AudioSource>();
    }

    public void ChouseAbility(){
        AbilityScreen.SetActive(true);
        canvas.HideCanvas();
    }
    public void AbilityRunner(){
        click.Play();
        AbilityScreen.SetActive(false);

        player.story = 1;
        player.runner = true;
        player.cook = false;
        player.builder = false;
        player.maxstamina = 150f;
        player.stamina = 150f;
        player.maxhunger = 130f;
        player.hunger = 0f;
        player.maxhealth = 100f;
        player.health = 100f;
        player.speed = 10f;
        player.damage = 10f;

        //autosave
        SavingSystem.SavePlayer(player);
        //closeautosave
        ability.AbilityInfo();
    }
    public void AbilityCook(){
        click.Play();
        AbilityScreen.SetActive(false);

        player.story = 1;
        player.runner = false;
        player.cook = true;
        player.builder = false;
        player.maxstamina = 120f;
        player.stamina = 120f;
        player.maxhunger = 110f;
        player.hunger = 0f;
        player.maxhealth = 100f;
        player.health = 100f;
        player.speed = 7f;
        player.damage = 10f;

        //autosave
        SavingSystem.SavePlayer(player);
        //closeautosave
        ability.AbilityInfo();
    }
    public void AbilityBuilder(){
        click.Play();
        AbilityScreen.SetActive(false);

        player.story = 1;
        player.runner = false;
        player.cook = false;
        player.builder = true;
        player.maxstamina = 100f;
        player.stamina = 100f;
        player.maxhunger = 90f;
        player.hunger = 0f;
        player.maxhealth = 100f;
        player.health = 100f;
        player.speed = 5f;
        player.damage = 15f;

        //autosave
        SavingSystem.SavePlayer(player);
        //closeautosave
        ability.AbilityInfo();
    }
    public void PlayGameWithAbility(){
        if(player.runner|| player.cook|| player.builder){
            if(player.abilityinfo){
                AbilityScreen.SetActive(false);
                canvas.ShowCanvas();
            }
            else{
                ability.AbilityInfo();
                canvas.HideCanvas();
            }
        }
        else{
            ChouseAbility();
            canvas.HideCanvas();
        }
    }
}
