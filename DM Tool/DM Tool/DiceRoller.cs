using System;
using System.Collections.Generic;

/// <summary>Contains:
/// Built in Random Class,
/// Inclusive random number generator,
/// and multiple ways to roll the following dice:
/// D2, D3, D4, D6, D8, D10, D12, D20, D100.</summary>
public static class DiceRoller
{
	/// <summary>Can be used to store dice rolls for export.</summary>
	public static string DiceRolls;

	private static Random rand = new Random();

	/// <summary>Built in Random class access.</summary>
	public static Random Rand
	{
		get
		{
			return rand;
		}
	}

	/// <summary>Inclusive ranged number generator.</summary>
	public static int RandomRangeNumber(int min, int max)
	{
		if (max + 1 <= min) return 0;

		return rand.Next(min, max + 1);
	}

	#region D2

	/// <summary>Rolls 1 D2 and returns the number.</summary>
	public static int RollD2()
	{
		int D6 = RollD6();

		if (D6 < 4)
		{
			return 1;
		}
		else
		{
			return 2;
		}
	}

	/// <summary>Rolls "howMany" D2 and returns the sum of all rolls.</summary>
	public static int RollD2(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD2();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D2 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD2(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD2();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D3

	/// <summary>Rolls 1 D3 and returns the number./summary>
	public static int RollD3()
	{
		int D6 = RollD6();

		if (D6 <= 2)
		{
			return 1;
		}
		else if (D6 <= 4)
		{
			return 2;
		}
		else
		{
			return 3;
		}
	}

	/// <summary>Rolls "howMany" D3 and returns the sum of all rolls.</summary>
	public static int RollD3(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD3();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D3 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD3(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD3();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D4

	/// <summary>Rolls 1 D4 and returns the number.</summary>
	public static int RollD4()
	{
		int sum = rand.Next(1, 5);

		return sum;
	}

	/// <summary>Rolls "howMany" D4 and returns the sum of all rolls.</summary>
	public static int RollD4(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD4();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D4 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD4(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD4();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D6

	/// <summary>Rolls 1 D6 and returns the number.</summary>
	public static int RollD6()
	{
		int sum = rand.Next(1, 7);

		return sum;
	}

	/// <summary>Rolls "howMany" D6 and returns the sum of all rolls.</summary>
	public static int RollD6(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD6();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D6 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD6(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD6();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D8

	/// <summary>Rolls 1 D8 and returns the number.</summary>
	public static int RollD8()
	{
		int sum = rand.Next(1, 9);

		return sum;
	}

	/// <summary>Rolls "howMany" D8 and returns the sum of all rolls.</summary>
	public static int RollD8(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD8();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D8 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD8(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD8();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D10

	/// <summary>Rolls 1 D10 and returns the number.</summary>
	public static int RollD10()
	{
		int sum = rand.Next(1, 11);

		return sum;
	}

	/// <summary>Rolls "howMany" D10 and returns the sum of all rolls.</summary>
	public static int RollD10(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD10();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D10 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD10(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD10();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D12

	/// <summary>Rolls 1 D12 and returns the number.</summary>
	public static int RollD12()
	{
		int sum = rand.Next(1, 13);

		return sum;
	}

	/// <summary>Rolls "howMany" D12 and returns the sum of all rolls.</summary>
	public static int RollD12(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD12();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D12 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD12(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD12();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D20

	/// <summary>Rolls 1 D20 and returns the number.</summary>
	public static int RollD20()
	{
		int sum = rand.Next(1, 21);

		return sum;
	}

	/// <summary>Rolls "howMany" D20 and returns the sum of all rolls.</summary>
	public static int RollD20(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD20();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D20 and returns the List of all rolled numbers.</summary>
	public static List<int> RollD20(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD20();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion

	#region D100

	/// <summary>Rolls 2 D10 and returns the side by side value.</summary>
	public static int RollD100()
	{
		int tens = RollD10();
		int ones = RollD10();

		if (tens == 10 && ones == 10)
		{
			return 100;
		}
		else
		{
			return (tens * 10) + ones;
		}
	}

	/// <summary>Rolls "howMany" D100 (2 D10) and returns the sum of all rolls.</summary>
	public static int RollD100(uint howMany)
	{
		int sum = 0;

		for (int i = 0; i < howMany; i++)
		{
			sum += RollD100();
		}

		return sum;
	}

	/// <summary>Rolls "howMany" D100 (2 D10) and returns the List of all rolled numbers.</summary>
	public static List<int> RollD100(uint howMany, out int sum)
	{
		sum = 0;
		List<int> rolls = new List<int>();

		for (int i = 0; i < howMany; i++)
		{
			int roll = RollD100();
			rolls.Add(roll);
			sum += roll;
		}

		return rolls;
	}

	#endregion
}
