using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FarmScript : MonoBehaviour{

    PlayerController player;
    Ads ads;

    bool infoon = false;

    public GameObject infobg;
    public Text infotext;

    public GameObject plantbutton;
    public GameObject collectbutton;
    //popatos
    public GameObject Potato1;
    public GameObject Potato2;
    public GameObject Potato3;
    public GameObject Potato4;
    public GameObject Potato5;
    public GameObject Potato6;

    //carrot
    public GameObject Carrot1;
    public GameObject Carrot2;
    public GameObject Carrot3;
    public GameObject Carrot4;
    public GameObject Carrot5;
    public GameObject Carrot6;
    //onion
    public GameObject Onion1;
    public GameObject Onion2;
    public GameObject Onion3;
    public GameObject Onion4;
    public GameObject Onion5;
    public GameObject Onion6;
    //garlic
    public GameObject Garlic1;
    public GameObject Garlic2;
    public GameObject Garlic3;
    public GameObject Garlic4;
    public GameObject Garlic5;
    public GameObject Garlic6;
    //mushrooms
    public GameObject Mushrooms1;
    public GameObject Mushrooms2;
    public GameObject Mushrooms3;
    public GameObject Mushrooms4;
    public GameObject Mushrooms5;
    public GameObject Mushrooms6;

    float rangeDetection = 10f;

    //PlantMenu
    public GameObject PlantMenu;
    public GameObject potatobtn;
    public GameObject carrotbtn;
    public GameObject onionbtn;
    public GameObject mushroombtn;
    public GameObject garlicbtn;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ads = GetComponent<Ads>();
    }

    
    void Update(){
        float distance;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= rangeDetection){
            if(player.cook){
                if(!player.plantfruits && !player.cancollect){
                    plantbutton.SetActive(true);
                    collectbutton.SetActive(false);
                }
                if(player.plantfruits && player.cancollect){
                    collectbutton.SetActive(true);
                    plantbutton.SetActive(false);
                }
            }
        }
        else{
            collectbutton.SetActive(false);
            plantbutton.SetActive(false);
        }
        if(infoon){
            StartCoroutine(InfoDelay());
        }
        if(player.cancollect){
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "You can collect your vegetables.".ToString();
                infoon=true;
            }
        }
    }

    public void Plant(){
        PlantMenu.SetActive(true);
        if(player.potatos == 6){
            potatobtn.SetActive(true);
        }
        if(player.carrots == 6){
            carrotbtn.SetActive(true);
        }
        if(player.garlic == 6){
            garlicbtn.SetActive(true);
        }
        if(player.onion == 6){
            onionbtn.SetActive(true);
        }
        if(player.mushrooms == 6){
            mushroombtn.SetActive(true);
        }
    }

    public void PlantPotato(){
        if(player.potatos >0  && player.cook){
            if(!player.plantfruits){
                Potato1.SetActive(true);
                Potato2.SetActive(true);
                Potato3.SetActive(true);
                Potato4.SetActive(true);
                Potato5.SetActive(true);
                Potato6.SetActive(true);
                player.potatos -= 6;
                player.plantfruits = true;
                player.cancollect = false;
                player.potatoplanted = true;
                PlantMenu.SetActive(false);
                ads.ShowInterstitialAd();
                player.stamina--;
                StartCoroutine(CanCollectPlot());   
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Potatos planted".ToString();
                    infoon=true;
                }
            }
        }
    }
    public void PlantCarrot(){
        if(player.carrots >0  && player.cook){
            if(!player.plantfruits){
                Carrot1.SetActive(true);
                Carrot2.SetActive(true);
                Carrot3.SetActive(true);
                Carrot4.SetActive(true);
                Carrot5.SetActive(true);
                Carrot6.SetActive(true);
                player.carrots -= 6;
                player.plantfruits = true;
                player.cancollect = false;
                player.carrotplanted = true;
                PlantMenu.SetActive(false);
                ads.ShowInterstitialAd();
                player.stamina--;
                StartCoroutine(CanCollectPlot()); 
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Carrots planted".ToString();
                    infoon=true;
                }  
            }
        }
    }
    public void PlantOnion(){
        if(player.onion >0  && player.cook){
            if(!player.plantfruits){
                Onion1.SetActive(true);
                Onion2.SetActive(true);
                Onion3.SetActive(true);
                Onion4.SetActive(true);
                Onion5.SetActive(true);
                Onion6.SetActive(true);
                player.onion -= 6;
                player.plantfruits = true;
                player.cancollect = false;
                player.onionplanted = true;
                PlantMenu.SetActive(false);
                ads.ShowInterstitialAd();
                player.stamina--;
                StartCoroutine(CanCollectPlot());
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Onions planted".ToString();
                    infoon=true;
                }
            }
        }
    }
    public void PlantGarlic(){
        if(player.garlic >0  && player.cook){
            if(!player.plantfruits){
                Garlic1.SetActive(true);
                Garlic2.SetActive(true);
                Garlic3.SetActive(true);
                Garlic4.SetActive(true);
                Garlic5.SetActive(true);
                Garlic6.SetActive(true);
                player.garlic -= 6;
                player.plantfruits = true;
                player.cancollect = false;
                player.garlicplanted = true;
                PlantMenu.SetActive(false);
                ads.ShowInterstitialAd();
                player.stamina--;
                StartCoroutine(CanCollectPlot());
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Garlics planted".ToString();
                    infoon=true;
                }
            }
        }
    }
    public void PlantMushrooms(){
        if(!player.plantfruits){
            if(player.mushrooms >0  && player.cook){
                Mushrooms1.SetActive(true);
                Mushrooms2.SetActive(true);
                Mushrooms3.SetActive(true);
                Mushrooms4.SetActive(true);
                Mushrooms5.SetActive(true);
                Mushrooms6.SetActive(true);
                player.mushrooms -= 6;
                player.plantfruits = true;
                player.cancollect = false;
                player.mushroomsplanted = true;
                PlantMenu.SetActive(false);
                ads.ShowInterstitialAd();
                player.stamina--;
                StartCoroutine(CanCollectPlot());
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Mushrooms planted".ToString();
                    infoon=true;
                }
            }
        }
    }
    public void CollectPotato(){
        float distance;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= rangeDetection){
            if(player.cancollect && player.plantfruits && player.cook){
                if(player.potatoplanted){
                    Potato1.SetActive(false);
                    Potato2.SetActive(false);
                    Potato3.SetActive(false);
                    Potato4.SetActive(false);
                    Potato5.SetActive(false);
                    Potato6.SetActive(false);
                    player.fruits +=15;
                    player.potatos +=6;
                    player.plantfruits = false;
                    player.cancollect = false;
                    player.potatoplanted = false;
                    player.stamina--;
                    ads.ShowInterstitialAd();
                    if(!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Potatos collected".ToString();
                        infoon=true;
                    }
                }
                if(player.carrotplanted){
                    Carrot1.SetActive(false);
                    Carrot2.SetActive(false);
                    Carrot3.SetActive(false);
                    Carrot4.SetActive(false);
                    Carrot5.SetActive(false);
                    Carrot6.SetActive(false);
                    player.fruits +=15;
                    player.carrots +=6;
                    player.plantfruits = false;
                    player.cancollect = false;
                    player.carrotplanted = false;
                    player.stamina--;
                    ads.ShowInterstitialAd();
                    if(!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Carros collected".ToString();
                        infoon=true;
                    }
                }
                if(player.onionplanted){
                    Onion1.SetActive(false);
                    Onion2.SetActive(false);
                    Onion3.SetActive(false);
                    Onion4.SetActive(false);
                    Onion5.SetActive(false);
                    Onion6.SetActive(false);
                    player.fruits +=15;
                    player.onion +=6;
                    player.plantfruits = false;
                    player.cancollect = false;
                    player.onionplanted = false;
                    player.stamina--;
                    ads.ShowInterstitialAd();
                    if(!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Onions collected".ToString();
                        infoon=true;
                    }
                }
                if(player.garlicplanted){
                    Garlic1.SetActive(false);
                    Garlic2.SetActive(false);
                    Garlic3.SetActive(false);
                    Garlic4.SetActive(false);
                    Garlic5.SetActive(false);
                    Garlic6.SetActive(false);
                    player.fruits +=15;
                    player.garlic +=6;
                    player.plantfruits = false;
                    player.cancollect = false;
                    player.garlicplanted = false;
                    player.stamina--;
                    ads.ShowInterstitialAd();
                    if(!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Garlics collected".ToString();
                        infoon=true;
                    }
                }
                if(player.mushroomsplanted){
                    Mushrooms1.SetActive(false);
                    Mushrooms2.SetActive(false);
                    Mushrooms3.SetActive(false);
                    Mushrooms4.SetActive(false);
                    Mushrooms5.SetActive(false);
                    Mushrooms6.SetActive(false);
                    player.fruits +=15;
                    player.mushrooms +=6;
                    player.plantfruits = false;
                    player.cancollect = false;
                    player.mushroomsplanted = false;
                    player.stamina--;
                    ads.ShowInterstitialAd();
                    if(!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Mushrooms collected".ToString();
                        infoon=true;
                    }
                }
            }
        }
        SavingSystem.SavePlayer(player);
    }
    IEnumerator CanCollectPlot(){
        yield return new WaitForSeconds(120f);
        player.cancollect = true;
    }
    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(3f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
}
