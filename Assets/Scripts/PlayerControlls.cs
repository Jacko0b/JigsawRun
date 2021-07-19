using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
/*(TO DO)
       -credits in menu
       -komentarze prowadzacego
       -
        */
public class PlayerControlls : MonoBehaviour
{


    //###############GENERAL##########################
    public bool alive = true;
    public bool gameComplete = false;
    public bool levelComplete = false;
    public float pressedF = 0;

    //###############UI###############################
    public int silverKeys = 0;
    public short goldKeys = 0;
    public bool miniRobot = false;
    public bool miniGun = false;
    public bool miniRemote = false;

    //###############MOVEMENT##########################################
    public float movementSpeed = 5f;
    public float jumpSpeed = 3f;
    public float jumpHeight = 3f;
    public Vector2 v2;
    public float jumpPerformed = 0;
    public bool isInAir = false;
    private bool reachedMaxHeight = false;
    private bool landed = false;

    //###########OBJECTS#################################################
    public Rigidbody2D rb;
    public UI ui;
    public MovementControlls mc;
    public GameObject child;

    //###############AUDIO###############################
    public AudioSource smierc;
    public AudioSource wygrana;
    public AudioSource skok;
    public AudioSource landedd;
    public AudioSource bieg; 
    public AudioSource use;

    private void Awake()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
        silverKeys = PlayerStats.SilverKeys;
    }
  
    void FixedUpdate()
    {
        AfkSniper();
        Alive();
        GameComplete();
        NextLevel();
        move();
        jump();

        GetComponentInChildren<PlayerKurwa>().setAnimation(v2, (int)jumpPerformed);
    }


    public void move()
    {
        if(v2!= Vector2.zero) bieg.Play();
       

        gameObject.transform.Translate(
                            v2.x * Time.deltaTime * movementSpeed,
                            v2.y * Time.deltaTime * movementSpeed,
                            0
                            );

        /*Vector2 temp = Vector2.zero;

        if (v2.x != 0f || v2.y != 0f)
        {
            if (v2.x > 0.7f && v2.x < 1f) v2.Set(2, v2.y);
            if (v2.x < -0.7f && v2.x > -1f) v2.Set(3, v2.y);
            switch (v2.x)
            {
                case -1f:
                    temp.Set(-0.7f, 0.7f);
                    break;
                case 0f:
                    if (v2.y == 1f) temp.Set(0.7f, 0.7f);
                    else temp.Set(-0.7f, -0.7f);
                    break;
                case 1f:
                    temp.Set(0.7f, -0.7f);
                    break;
                case 2:
                    if (v2.y > 0.7f && v2.y < 1f) temp.Set(1, 0);
                    else temp.Set(0, -1);
                    break;
                case 3:
                    if (v2.y < -0.7f && v2.y > -1f) temp.Set(-1f, 0f);
                    else temp.Set(0f, 1f);
                    
                    break;
                default:
                    break;
            }
            print(v2.x);
        }
                   gameObject.transform.Translate(
                                        temp.x * Time.deltaTime * movementSpeed,
                                        temp.y * Time.deltaTime * movementSpeed,
                                        0);
        print("v2 " + v2 + " | temp "+ temp);*/
    }
    public void jump()
    {

        if (isInAir)
        {

            if (reachedMaxHeight)
            {
                if (landed)
                {
                    isInAir = false;
                    reachedMaxHeight = false;
                    landed = false;
                    landedd.Play();

                }
                else
                {
                    jumpFall();
                }
            }
            else
            {
                jumpRise();
            }
        }
        else
        {
            if (jumpPerformed == 1)
            {
                skok.Play();
                isInAir = true;
                jumpRise();
                
            }
        }


    }
    public void jumpRise()
    {
       // print("jump performed "+jumpPerformed);
       // print("isInAir " + isInAir);
       
        child.transform.localPosition =new Vector3(0, child.transform.localPosition.y+jumpSpeed*Time.deltaTime,0);
        if(child.transform.localPosition.y >= jumpHeight) reachedMaxHeight=true;
    }
  
    public void jumpFall()
    {
        child.transform.localPosition = new Vector3(0, child.transform.localPosition.y - jumpSpeed * Time.deltaTime, 0);
        if (child.transform.localPosition.y <= 0.0)
        {
            landed = true;
            child.transform.localPosition = new Vector3(0,0, 0);
        }
    }
    public void readMove(InputAction.CallbackContext value)
    {
        v2 = value.ReadValue<Vector2>();

    }
    public void readJump(InputAction.CallbackContext value)
    {
        jumpPerformed = value.ReadValue<float>();


    }
    public void readUse(InputAction.CallbackContext value)
    {
        pressedF = value.ReadValue<float>();
    }
    public void readMenu(InputAction.CallbackContext value)
    {
        
        ui.openMenu();
    }
    public void Alive()
    {
        if (!alive)
        {

            //swap animation to death
            smierc.Play();            //wait 0-2s
            ui.DeathScreen();
        }

    }
    public void GameComplete()
    {
        if (gameComplete)
        {
            //swap animation to victory pose
            //play victory sound
            //wait 0-2s
            ui.VictoryScreen();
            //show victory screen (text "you won", button "continue" ---> transfer to credits)
            wygrana.Play();
        }
       
    }
    
    public void AfkSniper()
    {
        if (Time.timeSinceLevelLoad >= 300)//sniper po 5min
        {
           // alive = false;
            //gunshot
        }

    }
    public void NextLevel()
    {
        if (levelComplete)
        {
            wygrana.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnDestroy()
    {
        if(SceneManager.GetActiveScene().buildIndex==4)
            if(silverKeys>0)
        PlayerStats.SilverKeys=1;
    }


}
