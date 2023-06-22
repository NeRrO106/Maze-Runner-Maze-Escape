using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LossMenu : MonoBehaviour
{

    public string sceneName;
    public string sceneName2;

    public GameObject LossScreen;
    public CanvasSettings canvas;
    
    AudioSource click;
    public PlayerController player;

    void Start(){
        click = GetComponent<AudioSource>();
    }

    public void TryAgain(){
        click.Play();
        string path = Application.persistentDataPath + "/player.dat";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu(){
        click.Play();
        string path = Application.persistentDataPath + "/player.dat";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SceneManager.LoadScene(sceneName2);
    }
    
    public void Loss(){
        LossScreen.SetActive(true);
        canvas.HideCanvas();
    }
}
