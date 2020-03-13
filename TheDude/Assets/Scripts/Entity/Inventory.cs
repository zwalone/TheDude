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

    [SerializeField]
    protected List<AbilityController> eqSlots;

    //Dadaj do listy głownej
    //jak jest w liscie głownej to dodaj do do listy założonej


    public void AddItem(Item it)
    {
        // check condition and add create ability controller

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
