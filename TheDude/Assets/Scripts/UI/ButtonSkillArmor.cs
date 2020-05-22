using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSkillArmor : MonoBehaviour
{
    [SerializeField]
    public GameObject ArmorUi;
    [SerializeField]
    public GameObject SkillsUi;

    public void ChangeUi()
    {
        if(ArmorUi.activeSelf && SkillsUi.activeSelf != true)
        {
            ArmorUi.SetActive(false);
            SkillsUi.SetActive(true);
        }else if (SkillsUi.activeSelf && ArmorUi.activeSelf != true)
        {
            SkillsUi.SetActive(false);
            ArmorUi.SetActive(true);
        }
    }
}
