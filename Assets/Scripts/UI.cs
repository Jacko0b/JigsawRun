using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UI : MonoBehaviour
{
    public GameObject coments;
    public GameObject gameMenu;
    public GameObject optionsMenu; 
    public GameObject exitConfirm;
    public GameObject defeatScreen;
    public GameObject victoryScreen;
    public GameObject items;
    public GameObject redDot;
    public TextMeshProUGUI tGoldKeys;
    public TextMeshProUGUI tSilverKeys;
    public TextMeshProUGUI comment;
    public GameObject comments;

    public GameObject remote;
    public GameObject robot;
    public GameObject gun;
    public GameObject pressF;
    public PlayerControlls player;

    public string l1 = "Welcome to the first ever episode of Jigsaw Run! Aren't you dying out of this excitement? Well, hold your horses... We will get to that dying part later...Wait wait wait... Something is off, u should be able to complete this level! Oh my co-host is telling me there was an issue, just wait a sec...";
    public string l2 = "Oh! Now Is better. Good luck. You'll need it.";
    public string l3 = "Welcome to the Jigsaw Run! Just so you know, there is more running stuff than puzzle stuff… So don't worry about your IQ";
    public string l4 = "It's a race between you and that wall full of spikes behind’ya… Ready, set, go!";
    public string l5 = "Grand chest trial~! In one we got Bakugo sweat! Other one got hydrogen sulfide and ammonia in very high density. Of course one got the key! Don't worry!";
    public string l6 = "Imagine that in the first project of this level we wanted 2nd floor, be glad we’re lazy! ";


    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControlls>();

       
    }
    public void printCom(string com)
    {
        comment.SetText(com);
        del(com);

    }
    private void FixedUpdate()
    {
        printEq();
        if (SceneManager.GetActiveScene().buildIndex == 1)
            printCom(l1);
        if (SceneManager.GetActiveScene().buildIndex == 2)
            printCom(l2);
        if (SceneManager.GetActiveScene().buildIndex == 3)
            printCom(l3);
        if (SceneManager.GetActiveScene().buildIndex == 4)
            printCom(l4);
        if (SceneManager.GetActiveScene().buildIndex == 5)
            printCom(l5);
        if (SceneManager.GetActiveScene().buildIndex == 6)
            printCom(l6);
        
        
    }
    public void del(string com)
    {
        if (Time.timeSinceLevelLoad > com.Length / 12)
        {
            comments.SetActive(false);
            if(SceneManager.GetActiveScene().buildIndex == 1) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        redDot.SetActive(false);
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        redDot.SetActive(true);
    }
    
    public void openMenu()
    {
        if (!gameMenu.activeInHierarchy)
        {
            Pause();
            gameMenu.SetActive(true);
        }
        else
        {
            Unpause();
            gameMenu.SetActive(false);
            if (optionsMenu.activeInHierarchy)
                optionsMenu.SetActive(false);
            if (exitConfirm.activeInHierarchy)
                exitConfirm.SetActive(false);
        }
       
    }
    public void DeathScreen()
    {
        Pause();
        defeatScreen.SetActive(true);
    }
    public void VictoryScreen()
    {
        Pause();
        victoryScreen.SetActive(true);
    }
    public void playAgainGame()
    {
        SceneManager.LoadScene(3);

    }
    public void exitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void playAgainLevel()
    {
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void printEq()
    {
        tGoldKeys.SetText(player.goldKeys + ""); 
        tSilverKeys.SetText(player.silverKeys + "");
        if (player.miniRemote)remote.SetActive(true);
        else remote.SetActive(false);
        if (player.miniRobot)robot.SetActive(true);
        else robot.SetActive(false);
        if (player.miniGun)gun.SetActive(true);
        else gun.SetActive(false);
    }
    public void showF()
    {
        pressF.SetActive(true);
    }
    public void hideF()
    {
        pressF.SetActive(false);
    }
}
