using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Manager : MonoBehaviour {

	public GameObject[] Object, Tool;

	void Start () {
		
	}

	void Update () {
		
	}

	public GameObject Find_Object(string _Object_Name)
	{
		switch (_Object_Name)
		{
			case "Obj_Little_Rock":
				return Object[0];
			case "Obj_Branch":
				return Object[1];
			case "Obj_Flower":
				return Object[2];
			case "Obj_Axe":
				return Object[3];
			case "Obj_Pick":
				return Object[4];
			case "Obj_Shovel":
				return Object[5];
			case "Obj_Wood":
				return Object[6];
			case "Obj_Wood_Fire":
				return Object[7];
			case "Obj_Tree1_Seed":
				return Object[8];
			case "Obj_Tree1":
				return Object[9];
			case "Obj_Rock":
				return Object[10];
			case "Obj_Berry_Tree_Seed":
				return Object[11];
			case "Obj_Berry_Tree":
				return Object[12];
			case "Obj_Crop_Seed":
				return Object[13];
			case "Obj_Farm":
				return Object[14];
			case "Obj_Apple":
				return Object[15];
			case "Obj_Banana":
				return Object[16];
			case "Obj_Pineapple":
				return Object[17];
			case "Obj_Watermelon":
				return Object[18];
			case "Obj_Lemon":
				return Object[19];
			case "Obj_Pot":
				return Object[20];
			case "Obj_Meat":
				return Object[21];
			case "Obj_Fruit_Platter":
				return Object[22];
			case "Obj_Salad":
				return Object[23];
			case "Obj_Pock_Knuckle":
				return Object[24];
			case "Obj_Pock_Knuckle_Noodle":
				return Object[25];
			case "Obj_Rice":
				return Object[26];
			case "Obj_Flour":
				return Object[27];
			case "Obj_Wood_Fire_B":
				return Object[28];
			case "Obj_Blue_Berry":
				return Object[29];
			case "Obj_Red_Berry":
				return Object[30];
			case "Obj_Yellow_Berry":
				return Object[31];
			case "Obj_Soft_Branch":
				return Object[32];
			case "Obj_Tree2_Seed":
				return Object[33];
			case "Obj_Tree2":
				return Object[34];
			case "Obj_Magic_Bean":
				return Object[35];
			case "Obj_Magic_Tree":
				return Object[36];
			case "Obj_Magic_Tree_Top":
				return Object[37];
			case "Obj_Cave":
				return Object[38];
			case "Obj_Tesla_Tower":
				return Object[39];
			case "Obj_Corkong_Hammer":
				return Object[40];
			case "Obj_Box":
				return Object[41];
			case "Obj_Tesla_Tower_B":
				return Object[42];
			case "Obj_Pot_B":
				return Object[43];
			case "Obj_Box_B":
				return Object[44];
			case "Obj_Lightning_Staff":
				return Object[45];
			case "Obj_Pork_Knuckle":
				return Object[46];
			case "Obj_Wool":
				return Object[47];
			case "Obj_Shofar":
				return Object[48];
			case "Obj_Corkong_Hand":
				return Object[49];
			case "Obj_Farm_B":
				return Object[50];

		}
		return Object[0];
	}

	public GameObject Find_Tool(string _Object_Name)
	{
		switch (_Object_Name)
		{
			case "Obj_Axe":
				return Tool[0];
			case "Obj_Pick":
				return Tool[1];
			case "Obj_Shovel":
				return Tool[2];
			case "Obj_Corkong_Hammer":
				return Tool[3];
			case "Obj_Lightning_Staff":
				return Tool[4];
		}
		return Tool[0];
	}
}
