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
		public static new readonly Character Youmu = new Character (7, "Youmu"); // �p�����̃v���p�e�B�̏㏑�����\

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
		Debug.Log (CharacterV2.Marisa.ID); // 1�B�p����ł��p�������Q�Ɖ\�Ȃ��Ƃ��m�F
		Debug.Log (CharacterV2.Sanae.ID); // 6�B�p���ł��Ă��邱�Ƃ��m�F
		Debug.Log (CharacterEnum.Reimu.ToString ()); // Reimu
		Debug.Log (Character.Reimu.String); // Reimu
		Debug.Log (CharacterV2.Aya.String); // Aya
		Debug.Log (Character.Youmu.ID); // 3
		Debug.Log (CharacterV2.Youmu.ID); // 7

		// ���������r���Z�q�̋�����enum�Ɠ����ł��鎖�̊m�F
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
			Debug.Log ("�얲");
			break;
		case CharacterEnum.Marisa:
			Debug.Log ("������");
			break;
		case CharacterEnum.Sakuya:
			Debug.Log ("���"); // ���̃��O���o�͂����
			break;
		case CharacterEnum.Youmu:
			Debug.Log ("�d��");
			break;
		default:
			Debug.Log ("");
			break;
		}

		/*
		// �R���p�C���G���[���o��
		switch (character)
		{
		case Characters.Reimu:
			Debug.Log ("�얲");
			break;
		case Characters.Marisa:
			Debug.Log ("������");
			break;
		case Characters.Sakuya:
			Debug.Log ("���");
			break;
		case Characters.Youmu:
			Debug.Log ("�d��");
			break;
		default:
			Debug.Log ("");
			break;
		}
		*/

		if (character == Character.Reimu)
		{
			Debug.Log ("�얲");
		}
		else if (character == Character.Marisa)
		{
			Debug.Log ("������");
		}
		else if (character == Character.Sakuya)
		{
			Debug.Log ("���"); // ���̃��O���o�͂����
		}
		else if (character == Character.Youmu)
		{
			Debug.Log ("�d��");
		}
		else
		{
			Debug.Log ("");
		}
	}
}
