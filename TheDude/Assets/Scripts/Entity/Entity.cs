using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Entity Opponent { get; set; }
    public CharacterStats Stats;
    public List<Skill> Skills;

    public int MakeChoice()
    {
        return 0;
        //AI will decide which action to choose
    }

    public void MakeAction()
    {
        int act = MakeChoice();
        //can cast skill
        //if (Skills[act].CanActivate(this, Opponent))
            Skills[act].Activate(this, Opponent);
    }
}
