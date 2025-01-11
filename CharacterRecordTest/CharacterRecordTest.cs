using UnityEngine;

public class CharacterRecordTest : MonoBehaviour
{
	public enum CharacterEnum
	{
		Reimu,
		Marisa,
		Sakuya,
		Youmu
	}

	public record Character
	{
		public static readonly Character Reimu = new Character (0, "Reimu");
		public static readonly Character Marisa = new Character (1, "Marisa");
		public static readonly Character Sakuya = new Character (2, "Sakuya");
		public static readonly Character Youmu = new Character (3, "Youmu");

		public readonly int ID;
		public readonly string String;

		public Character (int id, string str)
		{
			ID = id;
			String = str;
		}

		public static bool operator > (Character a, Character b) => a.ID > b.ID;
		public static bool operator >= (Character a, Character b) => a.ID >= b.ID;
		public static bool operator < (Character a, Character b) => a.ID < b.ID;
		public static bool operator <= (Character a, Character b) => a.ID <= b.ID;
	}

	public record CharacterV2 : Character
	{
		public static readonly Character Reisen = new Character (4, "Reisen");
		public static readonly Character Aya = new Character (5, "Aya");
		public static readonly Character Sanae = new Character (6, "Sanae");
		public static new readonly Character Youmu = new Character (7, "Youmu"); // 継承元のプロパティの上書きも可能

		public CharacterV2 (int id, string str) : base (id, str)
		{

		}
	}

	private void Awake ()
	{
		Debug.Log (CharacterEnum.Reimu); // Reimu
		Debug.Log (Character.Reimu); // CharacterRecord { ID = 0, String = Reimu }
		Debug.Log ((int)CharacterEnum.Marisa); // 1
		Debug.Log (Character.Marisa.ID); // 1
		Debug.Log (CharacterV2.Marisa.ID); // 1。継承先でも継承元を参照可能なことを確認
		Debug.Log (CharacterV2.Sanae.ID); // 6。継承できていることを確認
		Debug.Log (CharacterEnum.Reimu.ToString ()); // Reimu
		Debug.Log (Character.Reimu.String); // Reimu
		Debug.Log (CharacterV2.Aya.String); // Aya
		Debug.Log (Character.Youmu.ID); // 3
		Debug.Log (CharacterV2.Youmu.ID); // 7

		// ここから比較演算子の挙動がenumと同じである事の確認
		CharacterEnum characterEnum = CharacterEnum.Sakuya;
		Character character = Character.Sakuya;

		Debug.Log (characterEnum == CharacterEnum.Sakuya); // true
		Debug.Log (character == Character.Sakuya); // true
		Debug.Log (characterEnum != CharacterEnum.Youmu); // true
		Debug.Log (character != Character.Youmu); // true
		Debug.Log (characterEnum > CharacterEnum.Reimu); // true
		Debug.Log (character > Character.Reimu); // true
		Debug.Log (characterEnum >= CharacterEnum.Marisa); // true
		Debug.Log (character >= Character.Marisa); // true
		Debug.Log (characterEnum < CharacterEnum.Sakuya); // false
		Debug.Log (character < Character.Sakuya); // false
		Debug.Log (characterEnum <= CharacterEnum.Youmu); // true
		Debug.Log (character <= Character.Youmu); // true

		switch (characterEnum)
		{
		case CharacterEnum.Reimu:
			Debug.Log ("霊夢");
			break;
		case CharacterEnum.Marisa:
			Debug.Log ("魔理沙");
			break;
		case CharacterEnum.Sakuya:
			Debug.Log ("咲夜"); // このログが出力される
			break;
		case CharacterEnum.Youmu:
			Debug.Log ("妖夢");
			break;
		default:
			Debug.Log ("");
			break;
		}

		/*
		// コンパイルエラーが出る
		switch (character)
		{
		case Characters.Reimu:
			Debug.Log ("霊夢");
			break;
		case Characters.Marisa:
			Debug.Log ("魔理沙");
			break;
		case Characters.Sakuya:
			Debug.Log ("咲夜");
			break;
		case Characters.Youmu:
			Debug.Log ("妖夢");
			break;
		default:
			Debug.Log ("");
			break;
		}
		*/

		if (character == Character.Reimu)
		{
			Debug.Log ("霊夢");
		}
		else if (character == Character.Marisa)
		{
			Debug.Log ("魔理沙");
		}
		else if (character == Character.Sakuya)
		{
			Debug.Log ("咲夜"); // このログが出力される
		}
		else if (character == Character.Youmu)
		{
			Debug.Log ("妖夢");
		}
		else
		{
			Debug.Log ("");
		}
	}
}
