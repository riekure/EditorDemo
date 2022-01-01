using UnityEngine;

public enum ItemType
{
	Weapon,
	Armor,
	Heal,
	Trap,
	ReinforcementMaterial,
	EvolutionaryMaterial,
	Important,
}

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
	[System.Serializable]
	public class Item
	{
		public int id;
		public string name;
		public string caption;
		public ItemType type;
	}

	public string fileName;
	public string fileCaption;
	public Item[] items;

	public ItemData Clone()
	{
		return Instantiate(this);
	}
}
