using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MLSkillHeatMap : MonoBehaviour
{
	public Color DiodeColor;
	public Color ActivateColor;
	public int Turns;
	public Image[] Diodes;
	public int[] _counters;


	public void UpdtaeDiodes()
	{
		Turns++;
		
		byte scale = (byte)(200/ System.Math.Max(_counters.Max(),1));
		for (int i = 0; i < Diodes.Length; i++)
		{
			byte colVal = (byte)(_counters[i]*scale+54);

			Diodes[i].color = new Color32(
				(byte)(DiodeColor.r * 255), 
				(byte)(DiodeColor.g * 255), 
				(byte)(DiodeColor.b * 255), 
				colVal);
		}
	
	}
	public void LightDiode(int num)
	{
		UpdtaeDiodes();
		_counters[num]++;
		Diodes[num].color = ActivateColor;
	}


}
