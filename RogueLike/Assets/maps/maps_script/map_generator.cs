using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_generator : MonoBehaviour
{
    [SerializeField] GameObject[] fbxObject;









    void Start()
    {

      

       
            // �������� ���������� ������� �� �����
            GameObject instantiatedObject = Instantiate(fbxObject[0], Vector3.zero, Quaternion.identity);
        
    }

  
}
