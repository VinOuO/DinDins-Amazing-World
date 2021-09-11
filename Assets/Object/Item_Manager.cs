using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour {

	public Sprite[] Item_Sprite;
	GameObject Back_Pack, Player;
	GameObject Floor_creater;
	GameObject Object_Manager;
	GameObject Calender;

	void Start () {
		Back_Pack = GameObject.Find("Back_Pack");
		Player = GameObject.Find("Player");
		Floor_creater = GameObject.Find("Floor_creater");
		Object_Manager = GameObject.Find("Object_Manager");
		Calender = GameObject.Find("GUI").transform.GetChild(1).gameObject;
	}

	void Update () {
		
	}

	public Sprite Find_Item_Sprite(string _Item_Name)
	{
		switch (_Item_Name)
		{
			case "Obj_Flower":
				return Item_Sprite[1];
			case "Obj_Branch":
				return Item_Sprite[2];
			case "Obj_Little_Rock":
				return Item_Sprite[3];
			case "Obj_Axe":
				return Item_Sprite[4];
			case "Obj_Pick":
				return Item_Sprite[5];
			case "Obj_Shovel":
				return Item_Sprite[6];
			case "Obj_Wood":
				return Item_Sprite[7];
			case "Obj_Wood_Fire_B":
				return Item_Sprite[8];
			case "Obj_Wood_Fire":
				return Item_Sprite[8];
			case "Obj_Tree1_Seed":
				return Item_Sprite[9];
			case "Obj_Berry_Tree_Seed":
				return Item_Sprite[10];
			case "Obj_Blue_Berry":
				return Item_Sprite[11];
			case "Obj_Red_Berry":
				return Item_Sprite[12];
			case "Obj_Yellow_Berry":
				return Item_Sprite[13];
			case "Obj_Crop_Seed":
				return Item_Sprite[14];
			case "Obj_Farm_B":
				return Item_Sprite[15];
			case "Obj_Farm":
				return Item_Sprite[15];
			case "Obj_Apple":
				return Item_Sprite[16];
			case "Obj_Banana":
				return Item_Sprite[17];
			case "Obj_Pineapple":
				return Item_Sprite[18];
			case "Obj_Watermelon":
				return Item_Sprite[19];
			case "Obj_Lemon":
				return Item_Sprite[20];
			case "Obj_Pot_B":
				return Item_Sprite[21];
			case "Obj_Pot":
				return Item_Sprite[21];
			case "Obj_Meat":
				return Item_Sprite[22];
			case "Obj_Fruit_Platter":
				return Item_Sprite[23];
			case "Obj_Salad":
				return Item_Sprite[24];
			case "Obj_Pork_Knuckle":
				return Item_Sprite[25];
			case "Obj_Pork_Knuckle_Noodle":
				return Item_Sprite[26];
			case "Obj_Rice":
				return Item_Sprite[27];
			case "Obj_Flour":
				return Item_Sprite[28];
			case "Obj_Soft_Branch":
				return Item_Sprite[29];
			case "Obj_Tree2_Seed":
				return Item_Sprite[30];
			case "Obj_Magic_Bean":
				return Item_Sprite[31];
			case "Obj_Tesla_Tower":
				return Item_Sprite[32];
			case "Obj_Tesla_Tower_B":
				return Item_Sprite[32];
			case "Obj_Corkong_Hammer":
				return Item_Sprite[33];
			case "Obj_Lightning_Staff":
				return Item_Sprite[34];
			case "Obj_Box_B":
				return Item_Sprite[35];
			case "Obj_Box":
				return Item_Sprite[35];
			case "Obj_Wool":
				return Item_Sprite[36];
			case "Obj_Shofar":
				return Item_Sprite[37];
			case "Obj_Corkong_Hand":
				return Item_Sprite[38];

		}
		return Item_Sprite[0];
	}

	public int Item_Use(string _Item_Name)
	{
		switch (_Item_Name)
		{
			//----------------------------Food
			case "Obj_Flower":
				//加素質
				Player.GetComponent<Player>().health += 1;
				Player.GetComponent<Player>().sanity += 1;
				Player.GetComponent<Player>().hunger += 1;
				return 100;
			case "Obj_Blue_Berry":
				Player.GetComponent<Player>().health += 5;
				Player.GetComponent<Player>().sanity += 5;
				Player.GetComponent<Player>().hunger += 5;
				return 100;
			case "Obj_Red_Berry":
				Player.GetComponent<Player>().health -= 10;
				Player.GetComponent<Player>().hunger += 5;
				return 100;
			case "Obj_Yellow_Berry":
				Player.GetComponent<Player>().sanity -= 10;
				Player.GetComponent<Player>().hunger += 5;
				return 100;
			case "Obj_Apple":
				Player.GetComponent<Player>().health += 10;
				Player.GetComponent<Player>().sanity += 15;
				Player.GetComponent<Player>().hunger += 10;
				return 100;
			case "Obj_Banana":
				Player.GetComponent<Player>().health += 15;
				Player.GetComponent<Player>().sanity += 10;
				Player.GetComponent<Player>().hunger += 10;
				return 100;
			case "Obj_Pineapple":
				Player.GetComponent<Player>().health += 10;
				Player.GetComponent<Player>().sanity += 10;
				Player.GetComponent<Player>().hunger += 10;
				return 100;
			case "Obj_Watermelon":
				Player.GetComponent<Player>().health += 10;
				Player.GetComponent<Player>().sanity += 15;
				Player.GetComponent<Player>().hunger += 10;
				return 100;
			case "Obj_Lemon":
				Player.GetComponent<Player>().health += 20;
				Player.GetComponent<Player>().sanity += 10;
				Player.GetComponent<Player>().hunger += 5;
				return 100;
			case "Obj_Meat":
				Player.GetComponent<Player>().health += 20;
				Player.GetComponent<Player>().sanity += 10;
				Player.GetComponent<Player>().hunger += 20;
				return 100;
			case "Obj_Fruit_Platter":
				Player.GetComponent<Player>().health += 30;
				Player.GetComponent<Player>().sanity += 5;
				Player.GetComponent<Player>().hunger += 5;
				return 100;
			case "Obj_Salad":
				Player.GetComponent<Player>().health += 30;
				Player.GetComponent<Player>().sanity += 10;
				Player.GetComponent<Player>().hunger += 5;
				return 100;
			case "Obj_Pork_Knuckle":
				Player.GetComponent<Player>().health += 30;
				Player.GetComponent<Player>().sanity -= 15;
				Player.GetComponent<Player>().hunger += 15;
				return 100;
			case "Obj_Pork_Knuckle_Noodle":
				Player.GetComponent<Player>().health += 30;
				Player.GetComponent<Player>().sanity += 30;
				Player.GetComponent<Player>().hunger += 30;
				return 100;
			case "Obj_Rice":
				Player.GetComponent<Player>().health += 10;
				Player.GetComponent<Player>().sanity -= 10;
				Player.GetComponent<Player>().hunger += 10;
				return 100;
			case "Obj_Flour":
				Player.GetComponent<Player>().health += 10;
				Player.GetComponent<Player>().sanity -= 10;
				Player.GetComponent<Player>().hunger += 10;
				return 100;
			//----------------------------Food
			//----------------------------Material
			case "Obj_Branch":
				switch (Player.GetComponent<Player>().Dir)
				{
					case 1:
						if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.left, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
						{
							if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.left, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.name == "Obj_Wood_Fire")
							{
								if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.left, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size <= 6)
								{
									Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.left, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size++;
									return 100;
								}
							}
						}
						return 0;
					case 2:
						if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.right, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
						{
							if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.right, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.name == "Obj_Wood_Fire")
							{
								if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.right, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size <= 6)
								{
									Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.right, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size++;
									return 100;
								}
							}
						}
						return 0;
					case 3:
						if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.up, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
						{
							if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.up, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.name == "Obj_Wood_Fire")
							{
								if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.up, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size <= 6)
								{
									Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.up, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size++;
									return 100;
								}
							}
						}
						return 0;
					case 4:
						if (!Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.down, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
						{
							if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.down, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.name == "Obj_Wood_Fire")
							{
								if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.down, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size <= 6)
								{
									Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.down, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Object_Up.GetComponent<Object_Normal>().Fire_Size++;
									return 100;
								}
							}
						}
						return 0;
				}
				return 0;
				/*
			case "Obj_Little_Rock":
				return 0;
				*/
			//----------------------------Material
			//----------------------------Building
			case "Obj_Wood_Fire_B":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Wood_Fire")))
				{
					Debug.Log("100");
					return 100;
				}
				else
				{
					Debug.Log("0");
					return 0;
				}
			case "Obj_Tesla_Tower_B":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Tesla_Tower")))
				{
					Debug.Log("100");
					return 100;
				}
				else
				{
					Debug.Log("0");
					return 0;
				}
			case "Obj_Farm_B":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Farm")))
				{
					return 100;
				}
				else
				{
					return 0;
				}
			case "Obj_Tree1_Seed":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Tree1")))
				{
					return 100;
				}
				else
				{
					return 0;
				}
			case "Obj_Tree2_Seed":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Tree2")))
				{
					return 100;
				}
				else
				{
					return 0;
				}
			case "Obj_Magic_Bean":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Magic_Tree")))
				{
					return 100;
				}
				else
				{
					return 0;
				}
			case "Obj_Berry_Tree_Seed":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Berry_Tree")))
				{
					return 100;
				}
				else
				{
					return 0;
				}
			case "Obj_Crop_Seed":
				if (!Player_Ahead_Floor().GetComponent<Floor_Normal>().Is_Empty)
				{
					if (Player_Ahead_Floor().GetComponent<Floor_Normal>().Object_Up.name == "Obj_Farm")
					{
						if (!Player_Ahead_Floor().GetComponent<Floor_Normal>().Object_Up.GetComponent<Obj_Farm>().Is_Planted)
						{
							Player_Ahead_Floor().GetComponent<Floor_Normal>().Object_Up.GetComponent<Obj_Farm>().Planted_Round = Calender.GetComponent<Calendar>().Round;
							Player_Ahead_Floor().GetComponent<Floor_Normal>().Object_Up.GetComponent<Obj_Farm>().Is_Planted = true;
							return 100;
						}
					}
				}
				return 0;
			case "Obj_Pot_B":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Pot")))
				{
					return 100;
				}
				else
				{
					return 0;
				}
			case "Obj_Box_B":
				if (Build(Object_Manager.GetComponent<Object_Manager>().Find_Object("Obj_Box")))
				{
					return 100;
				}
				else
				{
					return 0;
				}
			//----------------------------Building
			//----------------------------Tool
			case "Obj_Axe":
				return -1;
			case "Obj_Pick":
				return -1;
			case "Obj_Shovel":
				return -1;
			case "Obj_Corkong_Hammer":
				return -1;
			case "Obj_Lightning_Staff":
				return -1;
				//----------------------------Tool
		}
		return 0;
	}

	public bool Build(GameObject _Building)
	{
		switch (Player.GetComponent<Player>().Dir)
		{
			case 1:
				if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.left, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
				{
					Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.left, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(_Building);
					return true;
				}
				return false;
			case 2:
				if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.right, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
				{
					Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.right, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(_Building);
					return true;
				}
				return false;
			case 3:
				if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.up, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
				{
					Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.up, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(_Building);
					return true;
				}
				return false;
			case 4:
				if (Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.down, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Is_Empty)
				{
					Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.down, Player.GetComponent<Player>().Class_Now).GetComponent<Floor_Normal>().Spown(_Building);
					return true;
				}
				return false;
		}
		return false;
	}

	GameObject Player_Ahead_Floor()
	{
		switch (Player.GetComponent<Player>().Dir)
		{
			case 1:
				return Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.left, Player.GetComponent<Player>().Class_Now);
			case 2:
				return Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.right, Player.GetComponent<Player>().Class_Now);
			case 3:
				return Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.up, Player.GetComponent<Player>().Class_Now);
			case 4:
				return Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position + Vector3.down, Player.GetComponent<Player>().Class_Now);
		}
		return Floor_creater.GetComponent<Floor_crtater>().Floor_Find(Player.transform.position, Player.GetComponent<Player>().Class_Now);
	}

	public void God_Item_Combin(string _Item_Name)
	{
		Back_Pack.GetComponent<Back_Pack>().Put_In(_Item_Name, 100);
	}

	public void Item_Conbin(string _Item_Name)
	{
		switch (_Item_Name)
		{
			case "Obj_Axe":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Little_Rock", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Branch", 1))
				{
					Debug.Log("CONBIN_AXE");
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Axe", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Little_Rock", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Branch", 1);
					}
	
				}
				break;
			case "Obj_Pick":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Little_Rock", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Branch", 1))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Pick", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Little_Rock", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Branch", 1);
					}
				}
				break;
			case "Obj_Shovel":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Little_Rock", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Branch", 1))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Shovel", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Little_Rock", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Branch", 1);
					}
				}
				break;
			case "Obj_Wood_Fire":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Little_Rock", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Wood", 1))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Wood_Fire_B", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Little_Rock", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Wood", 1);
					}
				}
				break;
			case "Obj_Farm":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Wood", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Soft_Branch", 1))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Farm_B", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Wood", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Soft_Branch", 1);
					}
				}
				break;
			case "Obj_Pot":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Wood_Fire_B", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Little_Rock", 1))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Pot_B", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Wood_Fire_B", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Little_Rock", 1);
					}
				}
				break;
			case "Obj_Tesla_Tower":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Little_Rock", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Wood", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Shofar", 1))
				{
					Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Little_Rock", 1);
					Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Wood", 1);
					Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Shofar", 1);
					Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Tesla_Tower_B", 100);
				}
				break;
			case "Obj_Corkong_Hammer":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Corkong_Hand", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Soft_Branch", 1))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Corkong_Hammer", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_CorKong_Hand", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Soft_Branch", 1);
					}
				}
				break;
			case "Obj_Lightning_Staff":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Shofar", 1) && Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Wood", 1))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Lightning_Staff", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Shofar", 1);
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Wood", 1);
					}
				}
				break;
			case "Obj_Box":
				if (Back_Pack.GetComponent<Back_Pack>().Check_Item("Obj_Wood", 2))
				{
					if (Back_Pack.GetComponent<Back_Pack>().Put_In("Obj_Box_B", 100))
					{
						Back_Pack.GetComponent<Back_Pack>().Consume_Item("Obj_Wood", 2);
					}
				}
				break;
		}
		//return 0;
	}
}
