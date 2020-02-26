using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected CharacterStats stats;

    [SerializeField]
    protected List<AbilityController> ability;

    public void AddAbility(AbilityController ab)
    {
        // check condition and add create ability controller
    }

     public void RemoveAbility(AbilityController ab)
    {
        // check condition and remove ability controller 
    }

}
