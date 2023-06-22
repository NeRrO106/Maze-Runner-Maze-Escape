using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityMenu2 : MonoBehaviour
{
    PlayerController player;
    AudioSource click;

    public GameObject AbilityMenuInfo;
    public Text infotext;
    public CanvasSettings canvas;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        click = GetComponent<AudioSource>();
    }

    public void AbilityInfo(){
        AbilityMenuInfo.SetActive(true);
        if(player.runner){
            infotext.text = "Your ability now is RUNNER as a runner you need to go in the glade and in the maze as well to find the coins and the hidden objects(treasures) to make money and then to buy some keys and potions whici will help you find the way out of the maze".ToString();
        }
        if(player.cook){
            infotext.text = "Your ability now is COOK as a cook(you can`t leave the glade whithout 3keys) you need to find vegetables from the glade and the maze as well, plant it, collect it from the plot and then to sell the vegetables to make money for buying keys and potions whici will help you find the way out of the maze.".ToString();
        }
        if(player.builder){
            infotext.text = "Your ability now is BUILDER as a builder you need to find 3 axes(and then to craft one axe from shop), find 3shield(and then to craft one shield from shop), cut tree from the maze and the glade(and to sell the logs), to kill the zombie and the spider for making money for buying keys and potions whici will help you find the way out of the maze. ".ToString();
        }
    }

    public void ExitMenu(){
        click.Play();
        AbilityMenuInfo.SetActive(false);
        player.abilityinfo = true;
        player.transform.position = new Vector3(50f, 0.5f, 45f);
        SavingSystem.SavePlayer(player);
        canvas.ShowCanvas();
    }

}
