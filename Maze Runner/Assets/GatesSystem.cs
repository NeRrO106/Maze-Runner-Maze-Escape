using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatesSystem : MonoBehaviour{

    PlayerController player;
    AudioSource door;
    public GameObject infobg;
    public Text infotext;
    public WinScript winn;
    GameObject gate;

    string text = "";
    private TouchScreenKeyboard keyboard;

    //moving
    public Vector3 endPos;
    float speed = 1.0f;
    Vector3 startPos;
    bool opening = true;
    bool moving = false;
    bool infoon = false;
    float delay = 0.0f;

    //gatesbool
    public bool gate1 = false;
    public bool gate2 = false;
    public bool gate3 = false;
    public bool gate4 = false;
    public bool gate5 = false;
    public bool gate6 = false;
    public bool gate7 = false;
    public bool gate8 = false;
    public bool gate9 = false;
    public bool gate10 = false;
    public bool gate11 = false;
    public bool gate12 = false;
    public bool gate13 = false;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        door = GetComponent<AudioSource>();
        if (gate1) startPos = transform.position;
        if (gate2) startPos = transform.position;
        if (gate3) startPos = transform.position;
        if (gate4) startPos = transform.position;
        if (gate5) startPos = transform.position;
        if (gate6) startPos = transform.position;
        if (gate7) startPos = transform.position;
        if (gate8) startPos = transform.position;
        if (gate9) startPos = transform.position;
        if (gate10) startPos = transform.position;
        if (gate11) startPos = transform.position;
        if (gate12) startPos = transform.position;
        if (gate13){
            gate = GameObject.FindGameObjectWithTag("Gate13");
        }
    }

    // Update is called once per frame
    void Update(){
        float distance;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 10f){
            if(gate1 || gate2 || gate3 || gate4){
                if (player.builder || player.runner){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate Open".ToString();
                        infoon = true;
                    }
                }
                if (player.cook){
                    if (player.keys >= 3){
                        moving = true;
                        door.Play();
                        SavingSystem.SavePlayer(player);
                        if (!infoon){
                            infobg.SetActive(true);
                            infotext.text = "Gate Open".ToString();
                            infoon = true;
                        }
                    }
                    else{
                        if (!infoon){
                            infobg.SetActive(true);
                            infotext.text = "You need to have 3 keys or more to exit the glade.".ToString();
                            infoon = true;
                        }
                    }
                }
            }
            if(gate5){
                if (player.keyg5 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate5 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key5 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate6){
                if (player.keyg6 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate6 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key6 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate7){
                if (player.keyg7 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate7 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key7 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate8){
                if (player.keyg8 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate8 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key8 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate9){
                if (player.keyg9 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate9 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key9 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate10){
                if (player.keyg10 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate10 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key10 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate11){
                if (player.keyg11 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate11 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key11 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate12){
                if (player.keyg12 == 1){
                    moving = true;
                    door.Play();
                    SavingSystem.SavePlayer(player);
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "Gate12 Open".ToString();
                        infoon = true;
                    }
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need key12 for this gate.".ToString();
                        infoon = true;
                        moving = false;
                    }
                }
            }
            if(gate13){
                keyboard = TouchScreenKeyboard.Open(text, TouchScreenKeyboardType.NumberPad, false, false, true);
                text = keyboard.text;
                if (!infoon){
                    infobg.SetActive(true);
                    infotext.text = "Gate13(code gate)".ToString();
                    infoon = true;
                }
                if (text == "5728"){
                    var _openRotation = new Vector3(-260f, 30f, 995f);
                    gate.transform.position = _openRotation;
                    winn.Win();
                }
                else{
                    if (!infoon){
                        infobg.SetActive(true);
                        infotext.text = "You need the code. The code is in the maze.".ToString();
                        infoon = true;
                    }
                }
            }
        }
        if (moving){
            if (opening) MoveDoor(endPos);
            else MoveDoor(startPos);
        }
        if (infoon){
            StartCoroutine(InfoDelay());
        }
    }
    void MoveDoor(Vector3 goalPos)
    {
        float distance = Vector3.Distance(transform.position, goalPos);
        if (distance > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        else
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if (delay > 2f)
                {
                    opening = false;
                    if (door.isPlaying)
                    {
                        door.Stop();
                    }
                }
            }
            else
            {
                moving = false;
                opening = true;
                if (door.isPlaying)
                {
                    door.Stop();
                }
            }
        }
    }
    IEnumerator InfoDelay()
    {
        yield return new WaitForSeconds(3f);
        infobg.SetActive(false);
        infotext.text = " ".ToString();
        infoon = false;
        door.Stop();
    }
}
