using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_generator : MonoBehaviour
{
    [SerializeField] GameObject[] fbxObject;









    void Start()
    {

      

       
            // Создание экземпляра объекта на сцене
            GameObject instantiatedObject = Instantiate(fbxObject[0], Vector3.zero, Quaternion.identity);
        
    }

  
}
