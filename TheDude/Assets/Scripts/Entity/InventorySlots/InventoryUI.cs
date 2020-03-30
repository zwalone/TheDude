using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform MainSlots;
    public Transform SkillsSlots;
    public Transform ArmorSlots;

    InventorySlots[] slotsMain;
    ArmorSlots[] slotsArmor;
    AbilitySlots[] slotsSkill;

    void Start()
    {
        //Main slots
        Inventory.instace.eqMainChange += MainSlotsUpdateUi;
        slotsMain = MainSlots.GetComponentsInChildren<InventorySlots>();

        //Armor & Subscribe Main eq Ui Change
        
        Inventory.instace.eqArmorsChange += ArmorSlotsUpdateUi;
        Inventory.instace.eqArmorsChange += MainSlotsUpdateUi;
        slotsArmor = ArmorSlots.GetComponentsInChildren<ArmorSlots>();

        //Skills
        Inventory.instace.eqSkillsChange += SkillsSlotsUpdateUi;
        Inventory.instace.eqSkillsChange += MainSlotsUpdateUi;
        slotsSkill = SkillsSlots.GetComponentsInChildren<AbilitySlots>();

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
        //Change Ui to Armors
        //Update Armor Slots
        for (int i = 0; i < slotsArmor.Length; i++)
        {
            foreach (var item in Inventory.instace.eqArmors)
            {
                slotsArmor[i].AddItem(item);
            }
        }
    }

    void SkillsSlotsUpdateUi()
    {
        for (int i = 0; i < slotsSkill.Length; i++)
        {
            if (i < Inventory.instace.eqSkills.Count)
            {
                slotsSkill[i].AddItem(Inventory.instace.eqSkills[i]);
            }
        }
    }
}
