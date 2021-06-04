using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textControler : MonoBehaviour
{
    //START TEXT
    public TextMeshPro Start_Text_1;
    public TextMeshPro Start_Text_2;
    public GameObject helicopter_1;
    public GameObject helicopter_2;
    public GameObject police_1;
    public GameObject police_2;
    public Light auxLight;

    //WIN TEXT
    public TextMeshPro Win_Text_1;
    public TextMeshPro Win_Text_2;

    //GAME OVER TEXT
    public TextMeshPro Game_Over_Text_1;
    public TextMeshPro Game_Over_Text_2;

    //COUNTER TEXT
    public TextMeshPro Counter_Text_1;
    public TextMeshPro Counter_Text_2;

    private float globalTime = 0.0f;
    public float counterTime = 20;
    private bool timeOver = false;

    void Start()
    {
        //Definir visivilidad
        Start_Text_1.enabled = true;
        Start_Text_2.enabled = true;
        helicopter_1.SetActive(true);
        helicopter_2.SetActive(true);
        police_1.SetActive(true);
        police_2.SetActive(true);
        auxLight.enabled = true;

        Win_Text_1.enabled = false;
        Win_Text_2.enabled = false;

        Game_Over_Text_1.enabled = false;
        Game_Over_Text_2.enabled = false;

        Counter_Text_1.enabled = true;
        Counter_Text_2.enabled = true;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;
        startText();
        counter();
    }

    void startText(){
        if(globalTime > 10){
            Start_Text_1.enabled = false;
            Start_Text_2.enabled = false;
            helicopter_1.SetActive(false);
            helicopter_2.SetActive(false);
            police_1.SetActive(false);
            police_2.SetActive(false);
            auxLight.enabled = false;
        }
    }

    public void win(){}

    public void gameOver(){
        Game_Over_Text_1.enabled = true;
        Game_Over_Text_2.enabled = true;
        Counter_Text_1.enabled = false;
        Counter_Text_2.enabled = false;
    }

    void counter(){
        if(counterTime>0){
        counterTime -= Time.deltaTime;
        }else{
            timeOver = true;
            gameOver();
        }
        DisplayTime(counterTime);
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0) timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string counterText = minutes.ToString() +":"+ seconds.ToString();
        Counter_Text_1.SetText(counterText);
        Counter_Text_2.SetText(counterText);

    }

}
