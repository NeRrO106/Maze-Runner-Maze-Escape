using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    public VariableJoystick joystick;
    public VariableJoystick cjoystick;

    public Animator animator;
    public AudioSource gethit;

    public Transform player;

    public GameObject StoryScreen;
    public LossMenu lost;

    Tree tree;
    ZombieScript zombie;
    SpiderScript spider;
    

    
    public float speed;
    public float damage;
    float cspeed;

    //story
    public int story = 0;
    public StoryScript sscript;
    public AbilityMenu ability;

    //ads
    public Ads ads;
    bool adready = true;

    //ability
    public bool abilityinfo = false;
    public bool runner = false;
    public bool cook = false;
    public bool builder = false;
    bool cancut = true;
    bool canAttack = true;
    float rangeDetection = 40f;


    //health
    public float health = 0f;
    public float maxhealth = 0f;
    public RectTransform Healthbar;
    float takehealth = 0.0004f; 

    //stamina
    public float stamina = 0f;
    public float maxstamina = 0f;
    public RectTransform StaminaBar;
    float takestamina = 0.0004f; 

    //hunger
    public float hunger = 0f;
    public float maxhunger = 0f;
    public RectTransform HungerBar;
    float addhunger = 0.0004f; 

    //coins
    public Text cointext;

    //Tasks
    public int keyg5 = 0;
    public int keyg6 = 0;
    public int keyg7 = 0;
    public int keyg8 = 0;
    public int keyg9 = 0;
    public int keyg10 = 0;
    public int keyg11 = 0;
    public int keyg12 = 0;
    public int coins = 0;
    public int keys = 0;
    public int objfind = 0;
    public int objaxefind = 0;
    public int craftaxe = 0;
    public int objshieldfind = 0;
    public int craftshield = 0;
    public int potionbuy = 0;
    public int zombiekill = 0;
    public int spiderkill = 0;
    public int mazeescape = 0;
    public int potionred = 0;
    public int potionblue = 0;

    //shop
    public int logs = 0;
    public int fruits = 0;

    //cook vegetables
    public int potatos = 0;
    public int carrots = 0;
    public int onion = 0;
    public int garlic = 0;
    public int mushrooms = 0;

    //runner coins
    public int collectcoins = 0;
    public int collectedcoins = 0;

    //farm planted
    public bool plantfruits = false;
    public bool cancollect = false;
    public bool potatoplanted = false;
    public bool carrotplanted = false;
    public bool onionplanted = false;
    public bool garlicplanted = false;
    public bool mushroomsplanted = false;


    //builder objects
    public GameObject axe;
    public GameObject shield;
    public GameObject attackbutton;

    //rotation
    Vector3 horizontal;

    public GameObject zombietxt;
    public GameObject spidertxt;

    public void Start(){
        ads = gameObject.GetComponent<Ads>();
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<Tree>();
        zombie = GameObject.FindGameObjectWithTag("Zombie").GetComponent<ZombieScript>();
        spider = GameObject.FindGameObjectWithTag("Spider").GetComponent<SpiderScript>();
        if(story == 0){
            player.transform.position = new Vector3(-278f, 0.5f, 999f);
            sscript.Story();
        }
        Loading();
        if(adready){
            StartCoroutine(IntercalateDelay()); 
        }
        if(runner){
            zombietxt.SetActive(false);
            spidertxt.SetActive(false);
        }
        if(cook){
            zombietxt.SetActive(false);
            spidertxt.SetActive(false);
        }
        if(builder){

        }
    }
    void Awake () {
        Application.targetFrameRate = 60;
        Ability();
    }

    public void Loading(){
        PlayerData data = SavingSystem.LoadPlayer();
        
        //playerhud
        health = data.health;
        maxhealth = data.maxhealth;
        stamina = data.stamina;
        maxstamina = data.maxstamina;
        hunger = data.hunger;
        maxhunger = data.maxhunger;

        story = data.story;

        //keys
        keyg5 = data.keyg5;
        keyg6 = data.keyg6;
        keyg7 = data.keyg7;
        keyg8 = data.keyg8;
        keyg9 = data.keyg9;
        keyg10 = data.keyg10;
        keyg11 = data.keyg11;
        keyg12 = data.keyg12;

        potatos = data.potatos;
        carrots = data.carrots;
        onion = data.onion;
        garlic = data.garlic;
        mushrooms = data.mushrooms;
        collectcoins = data.collectcoins;
        collectedcoins = data.collectedcoins;
        logs = data.logs;
        fruits = data.fruits;

        //tasks
        coins = data.coins;
        keys = data.keys;
        objfind = data.objfind;
        objaxefind = data.objaxefind;
        craftaxe = data.craftaxe;
        objshieldfind = data.objshieldfind;
        craftshield = data.craftshield;
        potionbuy = data.potionbuy;
        zombiekill = data.zombiekill;
        spiderkill = data.spiderkill;
        mazeescape = data.mazeescape;
        potionred = data.potionred;
        potionblue = data.potionblue;

        //ability
        abilityinfo = data.abilityinfo;
        runner = data.runner;
        cook = data.cook;
        builder = data.builder;
        speed = data.speed;
        damage = data.damage;
        plantfruits = data.plantfruits;
        cancollect = data.cancollect;
        potatoplanted = data.potatoplanted;
        carrotplanted = data.carrotplanted;
        onionplanted = data.onionplanted;
        garlicplanted = data.garlicplanted;
        mushroomsplanted = data.mushroomsplanted;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        if(story == 0){
            player.transform.position = new Vector3(-278f, 0.5f, 999f);
            sscript.Story();
        }
        if(story == 1){
            StoryScreen.SetActive(false);
            ability.PlayGameWithAbility();
            player.transform.position = position;
            if(runner){
                speed = 10f;
                damage = 10f;
                axe.SetActive(false);
                attackbutton.SetActive(false);
                shield.SetActive(false);
            }
            if(cook){
                speed = 7f;
                damage = 10f;
                axe.SetActive(false);
                attackbutton.SetActive(false);
                shield.SetActive(false);
            }
            if(builder){
                speed = 5f;
                damage = 15f;
                if(craftaxe == 1){
                    axe.SetActive(true);
                    attackbutton.SetActive(true);
                    damage = 25f;
                }
                else{
                    axe.SetActive(false);
                    attackbutton.SetActive(false);
                }
                if(craftshield == 1){
                    shield.SetActive(true);
                }
                else{
                    shield.SetActive(false);
                }
            }
        }
    }

    private void FixedUpdate(){
        transform.Translate(Vector3.forward * joystick.Vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * joystick.Horizontal * speed * Time.deltaTime);
    }

    void Update(){
        UpdateCanvas();
        Rotation();
        Animation();
        if(adready){
            StartCoroutine(IntercalateDelay()); 
        }
        if(hunger < maxhunger){
            hunger += addhunger;
        }
        if(hunger == maxhunger){
            health -= takehealth;
        }
        if (craftaxe == 1){
            axe.SetActive(true);
            attackbutton.SetActive(true);
            damage = 25f;
        }
        else{
            axe.SetActive(false);
            attackbutton.SetActive(false);
        }
        if (craftshield == 1){
            shield.SetActive(true);
        }
        else{
            shield.SetActive(false);
        }
    }

    public void Ability(){
        if(runner){
            speed = 10f;
            damage = 10f;
            axe.SetActive(false);
            attackbutton.SetActive(false);
            shield.SetActive(false);
        }
        if(cook){
            speed = 7f;
            damage = 10f;
            axe.SetActive(false);
            attackbutton.SetActive(false);
            shield.SetActive(false);
        }
        if(builder){
            speed = 10f;
            damage = 15f;
            if(craftaxe == 1){
                axe.SetActive(true);
                attackbutton.SetActive(true);
                damage = 25f;
            }
            else{
                axe.SetActive(false);
                attackbutton.SetActive(false);
            }
            if(craftshield == 1){
                shield.SetActive(true);
            }
            else{
                shield.SetActive(false);
            }
        }
    }

    public void UpdateCanvas(){
        health = Mathf.Clamp(health, 0f, maxhealth);
        Healthbar.localScale = new Vector3(health / maxhealth, 1f, 1f);

        stamina = Mathf.Clamp(stamina, 0f, maxstamina);
        StaminaBar.localScale = new Vector3(stamina / maxstamina, 1f, 1f);

        hunger = Mathf.Clamp(hunger, 0f, maxhunger);
        HungerBar.localScale = new Vector3(hunger / maxhunger, 1f, 1f);

        cointext.text = coins.ToString();
    }
    public void Rotation(){
        if(cjoystick.Horizontal != 0){
            if(cjoystick.Horizontal > 0){
                horizontal.y += Input.GetAxis("Mouse X") * 20f;
            }
            else{
                horizontal.y += Input.GetAxis("Mouse X") * 10f;
            }
            player.transform.rotation = Quaternion.Euler(horizontal.x, +horizontal.y, horizontal.z);    
        }
    }

    public void AxeAttack(){
        if(craftaxe == 1){
            RaycastHit hit;
            if(cancut){
                if(Physics.Raycast(transform.position, transform.forward, out hit, rangeDetection)){
                    Tree tree = hit.collider.gameObject.GetComponent<Tree>();
                    if(tree != null){
                        if(hit.collider.tag == "Tree"){
                            float distance;
                            distance = Vector3.Distance(tree.transform.position, transform.position);
                            if(distance <= rangeDetection){
                                animator.SetTrigger("Attack");
                                tree.TakeDamage(damage);
                                stamina--;
                                StartCoroutine(CutWood());
                            }
                        }
                    }
                }
            }
            if(canAttack){
                if(Physics.Raycast(transform.position, transform.forward, out hit, rangeDetection)){
                    ZombieScript zombie = hit.collider.gameObject.GetComponent<ZombieScript>();
                    SpiderScript spider = hit.collider.gameObject.GetComponent<SpiderScript>();
                    if(zombie != null){
                        float distancezombie;
                        distancezombie = Vector3.Distance(zombie.transform.position, transform.position);
                        if(distancezombie <=rangeDetection && !zombie.alreadydeath){
                            animator.SetTrigger("Attack");
                            zombie.TakeDamage(damage);
                            stamina--;
                            StartCoroutine(AttackEnemy());
                        }
                    }
                    if(spider != null){
                        float distancespider;
                        distancespider = Vector3.Distance(spider.transform.position, transform.position);
                        if(distancespider <=rangeDetection && !spider.alreadydeath){
                            animator.SetTrigger("Attack");
                            spider.TakeDamage(damage);
                            stamina--;
                            StartCoroutine(AttackEnemy());
                        }
                    }
                }
            }
        }
    }
    public void TakeDamage(float _damage){
        if(runner){
            if(health != 0){
                gethit.Play();
                health -= _damage;
            }
            if(health == 0){
                Die();
            }
        }
        if(cook){
            if(health != 0){
                gethit.Play();
                health -= _damage +5f;
            }
            if(health == 0){
                Die();
            }
        }
        if(builder){
            if(health != 0){
                gethit.Play();
                health -= _damage/2;
            }
            if(health == 0){
                Die();
            }
        }
    }
    void Die(){
        story = 0;
        lost.Loss();
        Time.timeScale = 0;
    }
    IEnumerator IntercalateDelay(){
        adready = false;
        yield return new WaitForSeconds(120f);
        adready = true;
        ads.ShowInterstitialAd();
    }
    IEnumerator CutWood(){
        cancut = false;
        yield return new WaitForSeconds(3f);
        cancut = true;
    }
    IEnumerator AttackEnemy(){
        canAttack = false;
        yield return new WaitForSeconds(3f);
        canAttack = true;
    }
    void Animation(){
        if(joystick.Horizontal > 0){
            animator.SetFloat("Walking",1);
            if(stamina > 0){
                stamina -= takestamina;
            }
        }
        if(joystick.Horizontal < 0){
            animator.SetFloat("Walking",1);
            if(stamina > 0){
                stamina -= takestamina;
            }
        }
        if(joystick.Horizontal == 0){
            animator.SetFloat("Walking",0);
        }

        if(joystick.Vertical > 0){
            animator.SetFloat("Walking",1);
            if(stamina > 0){
                stamina -= takestamina;
            }
        }
        if(joystick.Vertical < 0){
            animator.SetFloat("Walking",1);
            if(stamina > 0){
                stamina -= takestamina;
            }
        }
        if(joystick.Vertical == 0){
            animator.SetFloat("Walking",0);
        }
    }

}
