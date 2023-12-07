using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopUI : MonoBehaviour
{
    [SerializeField] private GameObject CanvasShop;
    private void OnTriggerEnter(Collider other)
    {
        CanvasShop.SetActive(true);
    }
}
