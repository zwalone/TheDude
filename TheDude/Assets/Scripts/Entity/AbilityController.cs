using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    //inheritance items object after this class
    // have change name of its class
    protected CharacterStats stats;
    public int cost;
    // Start is called before the first frame update

    public virtual void Equip(){
        //efect happend after equip ability like flat modifires or passive skills
    }    

    public virtual void Use(){
        //active skills like cast spell attacks and so on
    }     
    public virtual void Remove(){
         //remove skill and undo changes
    }
       
}
