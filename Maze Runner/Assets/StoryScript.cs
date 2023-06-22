using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour{

    public GameObject StoryScreen;
    public CanvasSettings canvas;
    

    public PlayerController player;
    AudioSource click;
    public AbilityMenu ability;

    public void Start(){
        click = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Story(){
        StoryScreen.SetActive(true);
        canvas.HideCanvas();
    }
    public void Play(){
        click.Play();
        StoryScreen.SetActive(false);
        ability.ChouseAbility();
    }

}
