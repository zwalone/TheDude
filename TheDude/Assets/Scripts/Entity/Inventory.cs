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
        if(eqSlots.Count < 10)
        {
            eqSlots.Add(it);

            //Update Ui
            if (eqMainChange != null)
                eqMainChange.Invoke();
            if (eqArmorsChange != null)
                eqArmorsChange.Invoke();

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
        return true;
        //if (it is Armor)
        //{
        //    //Add to Arrmor Eq
        //    //if exist others iteams type like new item
          

        //    if (eqArmors.Count != 0)
        //    {
        //        foreach (Armor item in eqArmors)
        //        {
        //            //Replece Iteam
        //            if (it.GetComponent<Armor>().Typee == item.Typee)
        //            {
        //                eqSlots.Add(item);
        //                eqArmors.Add(it);
        //                eqArmors.Remove(item);
        //                eqSlots.Remove(it);

        //                //Update Ui
        //                if (eqArmorsChange != null)
        //                    eqArmorsChange.Invoke();
                        

        //                return true;
        //            }
        //        }
        //    }
          
        //    Debug.Log("elo");
        //    //if no this same type and is place equip item
        //    if (eqArmors.Count < 5)
        //    {

        //        eqArmors.Add(it);
        //        eqSlots.Remove(it);

        //        //Update Ui
        //        if (eqArmorsChange != null)
        //            eqArmorsChange.Invoke();

        //        return true;
        //    }
            

        //}
        //else //it is skills TODO
        //{

        //}
        //return false;
    }

    public bool UnEquip(AbilityController it)
    {
        return true;
        //if (it is Armor)
        //{
        //    if (eqSlots.Count < 10)
        //    {
        //        //Remove from eq and and to main slots
        //        eqSlots.Add(it);
        //        eqArmors.Remove(it);

        //       //UpdateUi
        //        if (eqArmorsChange != null)
        //            eqArmorsChange.Invoke();

        //        return true;
        //    }
        //    return false;
        //}
        //else //if its skill
        //{

        //}
        //return true;
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
