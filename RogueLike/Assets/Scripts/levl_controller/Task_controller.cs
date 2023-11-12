using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Task : MonoBehaviour
{
    public Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();





    }
    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        rend.material.color = Color.green;
    }








}
