using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    int score = 0;
    public float jumpForce = 7f; // Adjust the force to control the jump height
    private Rigidbody2D rb;
    private bool isGrounded = false;
    int lives = 2;
    
    int currentPlayerState;

    List<int> playerState = new List<int>();
    

    private void Start()
    {
        initPlayerState();
        setPlayerState();
       
        
        rb = GetComponent<Rigidbody2D>();
      
    }

    private void Update()
    {

        Controls();

        
    }




    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            Jump();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            ChangeState();
        }

        
    }


   void ChangeState()
    {
        currentPlayerState++;
        if (currentPlayerState >= playerState.Count)
        {
            currentPlayerState = 0;
        }
        Debug.Log(currentPlayerState);
        setPlayerState();
    }

    void Jump()
    {
        // Apply a vertical force to make the player jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        isGrounded=false;
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeState();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch(collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true; 
                break;

            case "enemy_stone"://0
                showdownStone("enemy_stone");

                

                break;
            
            case "enemy_paper"://1
                showdownPaper("enemy_paper");

                break;
            
            case "enemy_scissor"://2
                showdownScissor("enemy_scissor");

                break;

            
            default: 
                break;


        }
        
        
        
    }
void livesleft()
    {
        lives--;
       
        if(lives == 0)
        {
            Debug.Log("GameOver");
           
        }

    }

   void initPlayerState()
    {
      

        for(int i = 0; i < 3; i++)
        {
            playerState.Add(i);
        }
      

        
        //currentPlayerState = playerstate[UnityEngine.Random.Range(0, playerstate.Length)];
        currentPlayerState = playerState[UnityEngine.Random.Range(0, playerState.Count)];

    }

    void setPlayerState()
    {
        switch (currentPlayerState)
        {
            case 0:
                //change appearance
                break;
            
           
            case 1:
                //change appearance
                break;
            
            
            case 2:
                //change appearance
                break;

            default: break;
        
        
        
        }


    }
    void showdownStone(string enemy)//enemy is stone
    {
        switch (currentPlayerState)
        {

            case 0://stone vs stone
                disableState(enemy);
                break;

            case 1: //paper vs stone
                score++;
                break;

            case 2://scissor vs stone
                livesleft();
                break;

            default : break;
        }
    }
    
    
    void showdownPaper(string enemy)//enemy is paper
    {
        switch (currentPlayerState)
        {

            case 0://stone vs paper
                livesleft();
                break;

            case 1: //paper vs paper
                disableState(enemy);
                break;

            case 2://scissor vs paper
                score++;
                break;

            default: break;
        }
    }

    void showdownScissor(string enemy)//enemy is scissor
    {
        switch (currentPlayerState)
        {

            case 0://stone vs scissor
                score++;
                break;

            case 1: //paper vs scissor
                livesleft();
                break;

            case 2://scissor vs scissor
                disableState(enemy);
                break;

            default: break;
        }
    }


    void disableState(string enemy)
    {
        int indexToRemove = -1;

        switch (enemy)
        {
            case "enemy_stone":
                indexToRemove = 0;
                break;

            case "enemy_paper":
                indexToRemove = 1;
                break;

            case "enemy_scissor":
                indexToRemove = 2;
                break;

            default:
                break;
        }

        if (indexToRemove != -1)
        {
            StartCoroutine(RemoveAndAddBack(indexToRemove, 2.0f)); 
        }
    }

    IEnumerator RemoveAndAddBack(int indexToRemove, float duration)
    {
        if (playerState.Contains(indexToRemove))
        {
            playerState.RemoveAt(indexToRemove);
        }
        else
        {
            yield break;
        }

        yield return new WaitForSeconds(duration);

        playerState.Insert(indexToRemove, indexToRemove);
    }

}


