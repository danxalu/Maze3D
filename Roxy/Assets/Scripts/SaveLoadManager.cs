using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //Библиотек для работы с файлами
using System.Runtime.Serialization.Formatters.Binary; //Библиотека для работы бинарной сериализацией

[System.Serializable]
public class SaveData
{
	public string Player;
	public List<string> Players;
	public List<string> Players_Shop;
	public List<string> Players_Gifts;

	public int Crystals;
	public bool Music_On;
	public bool Sounds_On;
	public SaveData()
	{
		Player = Wardrobe.Player.name;
		Players = Wardrobe.Players.ConvertAll(GameObject => GameObject.name);
		Players_Shop = Wardrobe.Players_Shop.ConvertAll(GameObject => GameObject.name);
		Players_Gifts = Wardrobe.Players_Gifts.ConvertAll(GameObject => GameObject.name);

		Crystals = CrystalsScript.crystals;
		Music_On = Music.Music_On;
		Sounds_On = Sounds.Sounds_On;
	}

}

public static class SaveLoad
{
	private static string path = Application.persistentDataPath + "/info.save";
	private static BinaryFormatter formatter = new BinaryFormatter(); //Создание сериализатора 
	public static void SaveGame() //Метод для сохранения
	{

		FileStream fs = new FileStream(path, FileMode.Create); //Создание файлового потока

		SaveData data = new SaveData(); //Получение данных

		formatter.Serialize(fs, data); //Сериализация данных

		fs.Close(); //Закрытие потока
	}

	public static SaveData LoadGame() //Метод загрузки
	{
		if (File.Exists(path))
		{
			FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока

			SaveData data = formatter.Deserialize(fs) as SaveData; //Получение данных

			fs.Close(); //Закрытие потока

			return data; //Возвращение данных
		}
		else
		{
			return null;
		}

	}
}

public static class LoadData
{
	public static void LoadGame()
	{
		SaveData data = SaveLoad.LoadGame(); //Получение данных

		if (data != null)
		{
			GameObject Wardrobe_ = GameObject.Find("Wardrobe_");
			GameObject Canvas = Wardrobe_.transform.Find("Canvas").gameObject;
			GameObject Player = Canvas.transform.Find("Player").gameObject;
			Wardrobe.Player = Player.transform.Find(data.Player).gameObject;

			Wardrobe.Players.Clear();
			foreach (string name in data.Players)
            {
				Wardrobe.Players.Add(Player.transform.Find(name).gameObject);
			}
			Wardrobe.Players_Shop.Clear();
			foreach (string name in data.Players_Shop)
			{
				Wardrobe.Players_Shop.Add(Player.transform.Find(name).gameObject);
			}
			Wardrobe.Players_Gifts.Clear();
			foreach (string name in data.Players_Gifts)
			{
				Wardrobe.Players_Gifts.Add(Player.transform.Find(name).gameObject);
			}

			CrystalsScript.crystals = data.Crystals;
			Music.Music_On = data.Music_On;
			Sounds.Sounds_On = data.Sounds_On;
		}
	}
}
