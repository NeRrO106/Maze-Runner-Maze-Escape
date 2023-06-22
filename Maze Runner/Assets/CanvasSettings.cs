using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSettings : MonoBehaviour
{
    public GameObject pausebutton;
    public GameObject inventorybutton;
    public GameObject health;
    public GameObject stamina;
    public GameObject hunger;
    public GameObject coins;
    public GameObject shopbutton;
    public GameObject taskbutton;
    public GameObject joystick;
    public GameObject cjoystick;

    public void HideCanvas(){
        pausebutton.SetActive(false);
        inventorybutton.SetActive(false);
        health.SetActive(false);
        stamina.SetActive(false);
        hunger.SetActive(false);
        coins.SetActive(false);
        shopbutton.SetActive(false);
        taskbutton.SetActive(false);
        cjoystick.SetActive(false);
        joystick.SetActive(false);

    }
    public void ShowCanvas(){
        pausebutton.SetActive(true);
        inventorybutton.SetActive(true);
        health.SetActive(true);
        stamina.SetActive(true);
        hunger.SetActive(true);
        coins.SetActive(true);
        shopbutton.SetActive(true);
        taskbutton.SetActive(true);
        cjoystick.SetActive(true);
        joystick.SetActive(true);
    }
}
