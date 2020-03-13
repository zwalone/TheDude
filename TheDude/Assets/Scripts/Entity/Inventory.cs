using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instace;

    private void Awake()
    {
        if(instace == null)
        {
            instace = this;
        }
    }
    #endregion

    public List<AbilityController> eqSlots;
    public List<AbilityController> eqSkills;
    public List<AbilityController> eqArmors;

    //Delegate to update Ui
    public delegate void eqSlotsDelegate();
    public eqSlotsDelegate eqMainChange;

    public delegate void eqSkillsDelegate();
    public eqSkillsDelegate eqSkillsChange;

    public delegate void eqArmorsDelegate();
    public eqArmorsDelegate eqArmorsChange;

    //Dadaj do listy głownej
    //jak jest w liscie głownej to dodaj do do listy założonej


    public bool AddItem(AbilityController it)
    {
        // check condition and add create ability controller
        if(eqSlots.Count < 9)
        {
            eqSlots.Add(it);

            //Update Ui
            if (eqMainChange != null)
                eqMainChange.Invoke();

            return true;
        }
        else
        {
            //Show mesage "full inventory slots"
            Debug.Log("Main Eq is full");
            return false;
        }

    }

    public bool Equip(AbilityController it)
    {
        if (it is Armor)
        {
            //Add to Arrmor Eq
            if (eqArmors.Count < 4)
            {
                eqArmors.Add(it);

                //Update Ui
                if (eqArmorsChange != null)
                    eqArmorsChange.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }
        // if it == skills Check and  Update
        return false;
    }

     public void RemoveItem(Item it)
    {
        // check condition and remove ability controller 
    }

    public void DisplayItems(){

        //open Menu with items
        //set items in slots etc.
    }
}
