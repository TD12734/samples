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

	public record CharacterRecord
	{
		public readonly int ID;
		public readonly string String;

		public CharacterRecord (int id, string str)
		{
			ID = id;
			String = str;
		}

		public static bool operator > (CharacterRecord a, CharacterRecord b) => a.ID > b.ID;
		public static bool operator >= (CharacterRecord a, CharacterRecord b) => a.ID >= b.ID;
		public static bool operator < (CharacterRecord a, CharacterRecord b) => a.ID < b.ID;
		public static bool operator <= (CharacterRecord a, CharacterRecord b) => a.ID <= b.ID;
	}

	public class Characters
	{
		public static readonly CharacterRecord Reimu = new CharacterRecord (0, "Reimu");
		public static readonly CharacterRecord Marisa = new CharacterRecord (1, "Marisa");
		public static readonly CharacterRecord Sakuya = new CharacterRecord (2, "Sakuya");
		public static readonly CharacterRecord Youmu = new CharacterRecord (3, "Youmu");
	}

	public class CharactersV2 : Characters
	{
		public static readonly CharacterRecord Reisen = new CharacterRecord (4, "Reisen");
		public static readonly CharacterRecord Aya = new CharacterRecord (5, "Aya");
		public static readonly CharacterRecord Sanae = new CharacterRecord (6, "Sanae");
	}

	private void Awake ()
	{
		Debug.Log (CharacterEnum.Reimu); // Reimu
		Debug.Log (Characters.Reimu); // CharacterRecord { ID = 0, String = Reimu }
		Debug.Log ((int)CharacterEnum.Marisa); // 1
		Debug.Log (Characters.Marisa.ID); // 1
		Debug.Log (CharactersV2.Marisa.ID); // 1。継承先でも継承元を参照可能なことを確認
		Debug.Log (CharactersV2.Sanae.ID); // 6。継承できていることを確認
		Debug.Log (CharacterEnum.Reimu.ToString ()); // Reimu
		Debug.Log (Characters.Reimu.String); // Reimu
		Debug.Log (CharactersV2.Aya.String); // Aya

		// ここから比較演算子の挙動がenumと同じである事の確認
		CharacterEnum characterEnum = CharacterEnum.Sakuya;
		CharacterRecord characterRecord = Characters.Sakuya;

		Debug.Log (characterEnum == CharacterEnum.Sakuya); // true
		Debug.Log (characterRecord == Characters.Sakuya); // true
		Debug.Log (characterEnum != CharacterEnum.Youmu); // true
		Debug.Log (characterRecord != Characters.Youmu); // true
		Debug.Log (characterEnum > CharacterEnum.Reimu); // true
		Debug.Log (characterRecord > Characters.Reimu); // true
		Debug.Log (characterEnum >= CharacterEnum.Marisa); // true
		Debug.Log (characterRecord >= Characters.Marisa); // true
		Debug.Log (characterEnum < CharacterEnum.Sakuya); // false
		Debug.Log (characterRecord < Characters.Sakuya); // false
		Debug.Log (characterEnum <= CharacterEnum.Youmu); // true
		Debug.Log (characterRecord <= Characters.Youmu); // true

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
		switch (characterRecord)
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

		if (characterRecord == Characters.Reimu)
		{
			Debug.Log ("霊夢");
		}
		else if (characterRecord == Characters.Marisa)
		{
			Debug.Log ("魔理沙");
		}
		else if (characterRecord == Characters.Sakuya)
		{
			Debug.Log ("咲夜"); // このログが出力される
		}
		else if (characterRecord == Characters.Youmu)
		{
			Debug.Log ("妖夢");
		}
		else
		{
			Debug.Log ("");
		}
	}
}
