using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bord_animator : MonoBehaviour
{
    
    [SerializeField]   private CinemachineVirtualCamera BordCamera;


    private GameObject player;
    private CinemachineVirtualCamera CharacterCamera;
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;

        CharacterCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();

        ChangeCamera();

        StartCoroutine(WaitForButton());
        
        StopMovement();
    }






    IEnumerator WaitForButton()
    {

      yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        {
            Leave();
            StartMovement();
        }
    
    }

    private void Leave()
    {
        ChangeCamera();


    }

    private void StopMovement()
    {
       // player.GetComponent<PlayerController>().PlayerMove();

     //   player.gameObject.SetActive(false);

    }
    private void StartMovement()
    {
       // player.gameObject.SetActive(true);

        gameObject.GetComponent<Collider>().enabled = false;

        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);

        gameObject.GetComponent<Collider>().enabled = true;
    }
    

    private void ChangeCamera()
    {
        if (CharacterCamera.Priority == 0) 
        {
            CharacterCamera.Priority = 1;

            BordCamera.Priority = 0;
        }else  { BordCamera.Priority = 1; CharacterCamera.Priority = 0; }



    }




}
