using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public CanvasSettings canvas;

    public string sceneName;
    AudioSource click;
    public PlayerController player;

    MainMenu main;

    void Start(){
        click = GetComponent<AudioSource>();
    }

    public void MainMenu(){
        click.Play();
        SavingSystem.SavePlayer(player);
        SceneManager.LoadScene(sceneName);
    }
    public void Pause(){
        click.Play();
        PauseMenu.SetActive(true);
        SavingSystem.SavePlayer(player);
        canvas.HideCanvas();
    }

    public void Resume(){
        click.Play();
        PauseMenu.SetActive(false);
        canvas.ShowCanvas();
        SavingSystem.SavePlayer(player);
    }
}
