using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{       
    private static SaveData _current;

    public static SaveData current
    {

        get 
        {
            if (_current == null)
            {
                _current = new SaveData();
            }

            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
            }
        }
    }

    

    public parameter_mission CurrentMission;

    public int Playerlvl;
    public float PlayerDamage;
    public int PlayerSpeed;

    public float PlayerCurrentKills;

    public bool ActionBase;

   




}
    