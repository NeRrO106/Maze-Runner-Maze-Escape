using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public float health;
    public float maxhealth;
    public float maxstamina;
    public float stamina;
    public float maxhunger;
    public float hunger;

    public int keyg5;
    public int keyg6;
    public int keyg7;
    public int keyg8;
    public int keyg9;
    public int keyg10;
    public int keyg11;
    public int keyg12;

    public int story;

    public int coins;
    public int keys;
    public int objfind;
    public int objaxefind;
    public int craftaxe;
    public int objshieldfind;
    public int craftshield;
    public int potionbuy;
    public int zombiekill;
    public int spiderkill;
    public int mazeescape;
    public int potionred;
    public int potionblue;

    public int logs;
    public int fruits;
    public int potatos;
    public int carrots;
    public int onion;
    public int garlic;
    public int mushrooms;
    public int collectcoins;
    public int collectedcoins;
    public bool plantfruits;
    public bool cancollect;
    public bool potatoplanted;
    public bool carrotplanted;
    public bool onionplanted;
    public bool garlicplanted;
    public bool mushroomsplanted;

    public bool abilityinfo;
    public bool runner;
    public bool cook;
    public bool builder;
    public float speed;
    public float damage;
    public float[] position;

    public PlayerData(PlayerController player){

        health = player.health;
        maxhealth = player.maxhealth;
        stamina = player.stamina;
        maxstamina = player.maxstamina;
        hunger = player.hunger;
        maxhunger = player.maxhunger;

        keyg5 = player.keyg5; 
        keyg6 = player.keyg6;
        keyg7 = player.keyg7;
        keyg8 = player.keyg8;
        keyg9 = player.keyg9;
        keyg10 = player.keyg10;
        keyg11 = player.keyg11;
        keyg12 = player.keyg12;
        story = player.story;

        potatos = player.potatos;
        carrots = player.carrots;
        onion = player.onion;
        garlic = player.garlic;
        mushrooms = player.mushrooms;
        collectcoins = player.collectcoins;
        collectedcoins = player.collectedcoins;
        logs = player.logs;
        fruits = player.fruits;

        coins = player.coins;
        keys = player.keys;
        objfind = player.objfind;
        objaxefind = player.objaxefind;
        craftaxe = player.craftaxe;
        objshieldfind = player.objshieldfind;
        craftshield = player.craftshield;
        potionbuy = player.potionbuy;
        zombiekill = player.zombiekill;
        spiderkill = player.spiderkill;
        mazeescape = player.mazeescape;
        potionred = player.potionred;
        potionblue = player.potionblue;

        abilityinfo = player.abilityinfo;
        runner = player.runner;
        cook = player.cook;
        builder = player.builder;
        speed = player.speed;
        damage = player.damage;
        plantfruits = player.plantfruits;
        cancollect = player.cancollect;
        potatoplanted = player.potatoplanted;
        carrotplanted = player.carrotplanted;
        onionplanted = player.onionplanted;
        garlicplanted = player.garlicplanted;
        mushroomsplanted = player.mushroomsplanted;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}