using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour{


    public PlayerController player;

    public GameObject InventoryMenu;

    public GameObject KeyBG;
    public GameObject PotionBG;

    public Text potionred;
    public Text potionblue;


    public CanvasSettings canvas;

    public AudioSource click;
    public AudioSource drink;

    //InventoryText

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject item7;
    public GameObject item8;


    bool keyinventoryopen = false;
    bool potionopen = false;

    bool drinking = false;

    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Update(){
        if(keyinventoryopen){
            if (player.keyg6 != 0){
                item1.SetActive(true);
            }
            if (player.keyg6 != 0){
                item2.SetActive(true);
            }
            if (player.keyg7 != 0){
                item3.SetActive(true);
            }
            if (player.keyg8 != 0){
                item4.SetActive(true);
            }
            if (player.keyg9 != 0){
                item5.SetActive(true);
            }
            if (player.keyg10 != 0){
                item6.SetActive(true);
            }
            if (player.keyg11 != 0){
                item7.SetActive(true);
            }
            if (player.keyg12 != 0){
                item8.SetActive(true);
            }
        }
        if(potionopen){
            potionred.text = player.potionred.ToString();
            potionblue.text = player.potionblue.ToString();
        }
        if(drinking){
            StartCoroutine(Drinking());
        }
    }
    public void Inventory(){
        click.Play();
        InventoryMenu.SetActive(true);
        canvas.HideCanvas();
    }

    public void OpenPotionBG(){
        click.Play();
        KeyBG.SetActive(false);
        keyinventoryopen = false;
        potionopen = true;
        PotionBG.SetActive(true);
    }

    public void OpenKeyBG(){
        click.Play();
        potionopen = false;
        PotionBG.SetActive(false);
        keyinventoryopen = true;
        KeyBG.SetActive(true);
    }

    public void UseRedPotion(){
        if(player.potionred > 0 && player.health < player.maxhealth || player.hunger > 5){
            drink.Play();
            drinking = true;
            player.potionred --;
            player.health = player.maxhealth;
            player.hunger = 0;
            SavingSystem.SavePlayer(player);
        }
    }
    public void UseBluePotion(){
        if (player.potionblue > 0 && player.stamina < player.maxstamina){
            drink.Play();
            drinking = true;
            player.potionblue--;
            player.stamina = player.maxstamina;
            SavingSystem.SavePlayer(player);
        }
    }
    public void ExitInventory(){
        click.Play();
        InventoryMenu.SetActive(false);
        canvas.ShowCanvas();
    }
    IEnumerator Drinking(){
        yield return new WaitForSeconds(3f);
        drink.Stop();
        drinking = false;
    }
}
