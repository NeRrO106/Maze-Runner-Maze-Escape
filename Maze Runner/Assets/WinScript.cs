using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class WinScript : MonoBehaviour
{
    public GameObject WinScreen;
    public CanvasSettings canvas;
    
    AudioSource click;
    public string sceneName;
    public PlayerController player;

    void Start(){
        click = GetComponent<AudioSource>();
    }

    public void Close(){
        click.Play();
        string path = Application.persistentDataPath + "/player.dat";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        MainMenu();

    }

    public void MainMenu(){
        click.Play();
        SceneManager.LoadScene(sceneName);
    }
    
    public void Win(){
        SavingSystem.SavePlayer(player);
        WinScreen.SetActive(true);
        canvas.HideCanvas();
    }
}
