using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System;


public class CreatingAction 
{
   void SetActionEnabled(GameObject gameObject)
    {
        if (SaveData.current.ActionBase)
        {
            CreatingAction.CreateAction("PauseAction", gameObject);
            CreatingAction.CreateAction("StrafeAction", gameObject);
            CreatingAction.CreateAction("RunAction", gameObject);
            CreatingAction.CreateAction("AttackAction", gameObject);
        }




    }
    void a ()
    
    {
   
    
    
    }






   public static void CreateAction(string typeName,GameObject self )
    {
        // Get the Type object for the given type name
        Type type = Type.GetType(typeName);

        // Check if the type is valid
        if (type != null)
        {
            // Add the component to the GameObject
            self.AddComponent(type);
        }
        else
        {
            Debug.LogError($"Type '{typeName}' not found.");
        }
    }
}
