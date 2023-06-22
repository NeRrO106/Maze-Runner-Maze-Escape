using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour{
    
    public PlayerController player;

    public GameObject ShopsMenu;
    public CanvasSettings canvas;

    public AudioSource click;
    public AudioSource craft;
    Ads ads;

    bool infoon = false;
    bool crafting = false;

    public GameObject infobg;
    public Text infotext;

    //ShopMenu-bg
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject item7;
    public GameObject item8;
    public GameObject item9;
    public GameObject item10;
    public GameObject item11;
    public GameObject item12;
    public GameObject item13;
    public GameObject item14;

    public GameObject keybg;
    public GameObject craftbg;
    public GameObject buybg;
    public GameObject sellbg;

    //btn
    public GameObject shopbtn;
    public GameObject craftingbtn;
    public GameObject sellbtn;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ads = GetComponent<Ads>();
        if(player.runner){
            craftingbtn.SetActive(false);
            sellbtn.SetActive(false);
        }
        if(player.cook){
            craftingbtn.SetActive(false);
        }
    }

    
    void Update(){
        float distance;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 2f){
            shopbtn.SetActive(true);
        }
        else{
            shopbtn.SetActive(false);
        }
        if (player.runner){
            craftingbtn.SetActive(false);
            sellbtn.SetActive(false);
        }
        if (player.cook){
            craftingbtn.SetActive(false);
        }      
        if(infoon){
            StartCoroutine(InfoDelay());
        }
        if(crafting){
            StartCoroutine(Crafting());
        }
    }

    public void Shop(){
        click.Play();
        ads.ShowInterstitialAd();
        ShopsMenu.SetActive(true);
        canvas.HideCanvas();
        if (player.keyg5 == 0){//item1
            item1.SetActive(true);
        }
        else{
            item1.SetActive(false);
        }
        if (player.keyg6 == 0){
            item2.SetActive(true);
        }
        else{
            item2.SetActive(false);
        }
        if (player.keyg7 == 0){//item3
            item3.SetActive(true);
        }
        else{
            item3.SetActive(false);
        }
        if (player.keyg8 == 0){//item4
            item4.SetActive(true);
        }
        else{
            item4.SetActive(false);
        }
        if (player.keyg9 == 0){//item5
            item5.SetActive(true);
        }
        else{
            item5.SetActive(false);
        }
        if (player.keyg10 == 0){//item6
            item6.SetActive(true);
        }
        else{
            item6.SetActive(false);
        }
        if (player.keyg11 == 0){//item7
            item7.SetActive(true);
        }
        else{
            item7.SetActive(false);
        }
        if (player.keyg12 == 0){//item8
            item8.SetActive(true);
        }
        else{
            item8.SetActive(false);
        }
        if (player.potionred < 9){//item9
            item9.SetActive(true);
        }
        else{
            item9.SetActive(false);
        }
        if (player.potionblue < 9){//item10
            item10.SetActive(true);
        }
        else{
            item10.SetActive(false);
        }
        if (player.craftaxe == 0 && player.builder){//item11
            item11.SetActive(true);
        }
        else{
            item11.SetActive(false);
        }
        if (player.craftshield == 0 && player.builder){//item12
            item12.SetActive(true);
        }
        else{
            item12.SetActive(false);
        }
        if (player.builder){
            item14.SetActive(false);
        }
        if(player.cook){
            item13.SetActive(false);
        }
        if(player.craftaxe == 1 && player.craftshield == 1){
            craftingbtn.SetActive(false);
        }
    }

    public void OpenKeyBG(){
        click.Play();
        ads.ShowInterstitialAd();
        keybg.SetActive(true);
        buybg.SetActive(false);
        craftbg.SetActive(false);
        sellbg.SetActive(false);
    }
    public void OpenBuyBG(){
        click.Play();
        ads.ShowInterstitialAd();
        keybg.SetActive(false);
        buybg.SetActive(true);
        craftbg.SetActive(false);
        sellbg.SetActive(false);
    }
    public void OpenCraftBG(){
        click.Play();
        ads.ShowInterstitialAd();
        keybg.SetActive(false);
        buybg.SetActive(false);
        craftbg.SetActive(true);
        sellbg.SetActive(false);
    }
    public void OpenSellBG(){
        click.Play();
        ads.ShowInterstitialAd();
        keybg.SetActive(false);
        buybg.SetActive(false);
        craftbg.SetActive(false);
        sellbg.SetActive(true);
    }
    public void BuyKey5(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg5 == 0){
            player.keyg5 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key5 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item1.SetActive(false);
    }
    public void BuyKey6(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg6 == 0){
            player.keyg6 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key6 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item2.SetActive(false);
    }
    public void BuyKey7(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg7 == 0){
            player.keyg7 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key7 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item3.SetActive(false);
    }
    public void BuyKey8(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg8 == 0){
            player.keyg8 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key8 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item4.SetActive(false);
    }
    public void BuyKey9(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg9 == 0){
            player.keyg9 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key9 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item5.SetActive(false);
    }
    public void BuyKey10(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg10 == 0){
            player.keyg10 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key10 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item6.SetActive(false);
    }
    public void BuyKey11(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg11 == 0){
            player.keyg11 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key11 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item7.SetActive(false);
    }
    public void BuyKey12(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5 && player.keyg12 == 0){
            player.keyg12 =1;
            player.coins -= 5;
            if(player.keys <3){
                player.keys++;
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "Key12 bought".ToString();
                infoon=true;
            }
        }
        SavingSystem.SavePlayer(player);
        item8.SetActive(false);
    }
    public void BuyPotionRed(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=10){
            if(player.potionred == 0 && player.potionbuy ==0){
                player.potionred +=1;
                player.potionbuy =1;
                player.coins -=10;
                SavingSystem.SavePlayer(player);
            }
            else{
                player.potionred +=1;
                player.coins -=10;
                SavingSystem.SavePlayer(player);
            }
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "PotionRed bought".ToString();
                infoon=true;
            }
        }
    }
    public void BuyPotionBlue(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=15){
            player.potionblue +=1;
            player.coins -=15;
            SavingSystem.SavePlayer(player);
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "PotionBlue bought".ToString();
                infoon=true;
            }
        }
    }
    public void CraftAxe(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5){
            if(player.objaxefind >=3 && player.craftaxe ==0){
                player.objaxefind =3;
                player.craftaxe =1;
                player.coins -= 5;
                crafting = true;
                craft.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Axe crafted".ToString();
                    infoon=true;
                }
            }
        }
        SavingSystem.SavePlayer(player);
        item11.SetActive(true);
    }
    public void CraftShield(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.coins >=5){
            if(player.objshieldfind >=3 && player.craftshield ==0){
                player.objshieldfind =3;
                player.craftshield =1;
                player.coins -= 5;
                crafting = true;
                craft.Play();
                if(!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Shield crafted".ToString();
                    infoon=true;
                }
            }
        }
        SavingSystem.SavePlayer(player);
        item11.SetActive(true);
    }
    public void SellLogs(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.logs > 0){
            player.coins += player.logs;
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "You sold "+player.logs+" logs".ToString();
                infoon=true;
            }
            player.logs = 0;
            SavingSystem.SavePlayer(player);
        }
    }
    public void SellFruits(){
        click.Play();
        ads.ShowInterstitialAd();
        if(player.fruits > 0){
            player.coins += player.fruits;
            if(!infoon){
                infobg.SetActive(true);
                infotext.text = "You sold "+player.fruits+" vegetables".ToString();
                infoon=true;
            }
            player.fruits = 0;
            SavingSystem.SavePlayer(player);
        }
    }

    public void ExitShop(){
        click.Play();
        ads.ShowInterstitialAd();
        ShopsMenu.SetActive(false);
        canvas.ShowCanvas();
        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);
        item4.SetActive(false);
        item5.SetActive(false);
        item6.SetActive(false);
        item7.SetActive(false);
        item8.SetActive(false);
        item9.SetActive(false);
        item10.SetActive(false);
        item11.SetActive(false);
        item12.SetActive(false);
        item13.SetActive(false);
        item14.SetActive(false);
    }
    IEnumerator InfoDelay(){
        yield return new WaitForSeconds(2f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon=false;
    }
    IEnumerator Crafting(){
        yield return new WaitForSeconds(3f);
        craft.Stop();
        crafting = false;
    }
}
