using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndOfMissionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject CanvasShop;
    private void OnTriggerEnter(Collider other)
    {
        CanvasShop.SetActive(true);
    }
}

