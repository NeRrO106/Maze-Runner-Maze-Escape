using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskMenu : MonoBehaviour
{

    public PlayerController player;

    public GameObject TasksMenu;
    public CanvasSettings canvas;

    AudioSource click;
    
    //TaskMenu
    bool emptyb1 = false;
    bool emptyb2 = false;
    bool emptyb3 = false;
    bool emptyb4 = false;
    bool emptyb5 = false;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;

    public Text TaskText1;
    public Text TaskText2;
    public Text TaskText3;
    public Text TaskText4;
    public Text TaskText5;

    public Text Task1Progress;
    public Text Task2Progress;
    public Text Task3Progress;
    public Text Task4Progress;
    public Text Task5Progress;

    bool taskopen = false;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        click = GetComponent<AudioSource>();
    }

    void Update(){
        if(taskopen){
            UpdateRunnerTask();
            UpdateCookTask();
            UpdateBuilderTask();
        }
    }
    void UpdateRunnerTask(){
        if(player.runner == true){
            if(emptyb1 == false){//item1
                if(player.keys == 3){
                    item1.SetActive(false);
                    emptyb1 = true;
                    player.coins +=5;
                    player.collectedcoins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item1.SetActive(true);
                    emptyb1 = false;
                    TaskText1.text = "Buy 3 keys".ToString();
                    Task1Progress.text = player.keys + "/3".ToString();
                }
            }
            if(emptyb2 == false){//item2
                if(player.potionbuy == 1){
                    item2.SetActive(false);
                    emptyb2 = true;
                    player.coins += 5;
                    player.collectedcoins += 5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item2.SetActive(true);
                    emptyb2 = false;
                    TaskText2.text = "Buy 1 health potion".ToString();
                    Task2Progress.text = player.potionbuy + "/1".ToString();
                }
            }
            if(emptyb3 == false){//item3
                if(player.objfind >= 5){
                    item3.SetActive(false);
                    emptyb3 = true;
                    player.coins += 5;
                    player.collectedcoins += 5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item3.SetActive(true);
                    emptyb3 = false;
                    TaskText3.text = "Find 5 hidden objects".ToString();
                    Task3Progress.text = player.objfind + "/5".ToString();
                }
            }
            if(emptyb4 == false){//item4
                if(player.coins == 100){
                    item4.SetActive(false);
                    emptyb4 = true;
                    player.coins += 5;
                    player.collectedcoins += 5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item4.SetActive(true);
                    emptyb4 = false;
                    TaskText4.text = "Collect 100 coins".ToString();
                    Task4Progress.text = player.collectedcoins + "/100".ToString();
                }
            }
            if(emptyb5 == false){//item5
                if(player.mazeescape == 1){
                    item5.SetActive(false);
                    emptyb5 = true;
                    player.coins +=5;
                    player.collectedcoins += 5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item5.SetActive(true);
                    emptyb5 = false;
                    TaskText5.text = "Escape the maze".ToString();
                    Task5Progress.text = player.mazeescape + "/1".ToString();
                }
            }
        }
    }

    void UpdateCookTask(){
        if(player.cook == true){
            if(emptyb1 == false){//item1
                if(player.keys == 3){
                    item1.SetActive(false);
                    emptyb1 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item1.SetActive(true);
                    emptyb1 = false;
                    TaskText1.text = "Buy 3 keys".ToString();
                    Task1Progress.text = player.keys + "/3".ToString();
                }
            }
            if(emptyb2 == false){//item2
                if(player.potionbuy == 1){
                    item2.SetActive(false);
                    emptyb2 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item2.SetActive(true);
                    emptyb2 = false;
                    TaskText2.text = "Buy 1 health potion".ToString();
                    Task2Progress.text = player.potionbuy + "/1".ToString();
                }
            }
            if(emptyb3 == false){//item3
                if(player.objfind >= 5){
                    item3.SetActive(false);
                    emptyb3 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item3.SetActive(true);
                    emptyb3 = false;
                    TaskText3.text = "Find 5 hidden vegetables".ToString();
                    Task3Progress.text = player.objfind + "/5".ToString();
                }
            }
            if(emptyb4 == false){//item4deschimbat
                item4.SetActive(false);
                emptyb4 = true;
            }
            if(emptyb5 == false){//item5
                if(player.mazeescape == 1){
                    item5.SetActive(false);
                    emptyb5 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item5.SetActive(true);
                    emptyb5 = false;
                    TaskText5.text = "Escape the maze".ToString();
                    Task5Progress.text = player.mazeescape + "/1".ToString();
                }
            }
        }
    }

    void UpdateBuilderTask(){
        if(player.builder == true){
            if(emptyb1 == false){//item1
                if(player.objaxefind == 3 && player.craftaxe ==1){
                    item1.SetActive(false);
                    emptyb1 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item1.SetActive(true);
                    emptyb1 = false;
                    TaskText1.text = "Find 3 axes and craft one".ToString();
                    Task1Progress.text = player.objaxefind + "/3".ToString();
                }
            }
            if(emptyb2 == false){//item2
                if(player.objshieldfind == 3 && player.craftshield == 1){
                    item2.SetActive(false);
                    emptyb2 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item2.SetActive(true);
                    emptyb2 = false;
                    TaskText2.text = "FInd 3 shield and craft one".ToString();
                    Task2Progress.text = player.objshieldfind + "/3".ToString();
                }
            }
            if(emptyb3 == false){//item3
                if(player.zombiekill == 1){
                    item3.SetActive(false);
                    emptyb3 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item3.SetActive(true);
                    emptyb3 = false;
                    TaskText3.text = "Kill the zombie".ToString();
                    Task3Progress.text = player.zombiekill + "/1".ToString();
                }
            }
            if(emptyb4 == false){//item4
                if(player.spiderkill == 1){
                    item4.SetActive(false);
                    emptyb4 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item4.SetActive(true);
                    emptyb4 = false;
                    TaskText4.text = "Kill the spider".ToString();
                    Task4Progress.text = player.spiderkill + "/1".ToString();
                }
            }
            if(emptyb5 == false){//item5
                if(player.mazeescape == 1){
                    item5.SetActive(false);
                    emptyb5 = true;
                    player.coins +=5;
                    SavingSystem.SavePlayer(player);
                }
                else{
                    item5.SetActive(true);
                    emptyb5 = false;
                    TaskText5.text = "Escape the maze".ToString();
                    Task5Progress.text = player.mazeescape + "/1".ToString();
                }
            }
        }
    }

    public void Task(){
        click.Play();
        TasksMenu.SetActive(true);
        canvas.HideCanvas();
        taskopen = true;
    }
    public void ExitTask(){
        click.Play();
        TasksMenu.SetActive(false);
        canvas.ShowCanvas();
        taskopen = false;
    }
}
