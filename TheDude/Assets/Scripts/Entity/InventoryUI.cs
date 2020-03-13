using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform MainSlots;
    //public Transform SkillsSlots;
    public Transform ArmorSlots;

    InventorySlots[] slotsMain;
    ArmorSlots[] slotsArmor;

    //Change 
    InventorySlots[] slotsSkills;

    void Start()
    {
        //Main slots
        Inventory.instace.eqMainChange += MainSlotsUpdateUi;
        slotsMain = MainSlots.GetComponentsInChildren<InventorySlots>();

        //Armor
        Inventory.instace.eqArmorsChange += ArmorSlotsUpdateUi;
        //slotsArmor = 

        //Skills
        //Inventory.instace.eqSkillsChange += SkillsSlotsUpdateUi;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainSlotsUpdateUi()
    {
        for (int i = 0; i < slotsMain.Length; i++)
        {
            if (i < Inventory.instace.eqSlots.Count)
            {
                slotsMain[i].AddItem(Inventory.instace.eqSlots[i]);
            }
            else
            {
                slotsMain[i].ClearSlot();
            }
        }
    }

    void ArmorSlotsUpdateUi()
    {
        //Update Armor Slots
    }

    void SkillsSlotsUpdateUi()
    {
        //Update Skills Slots
    }
}
