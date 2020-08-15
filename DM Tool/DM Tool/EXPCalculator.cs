using System;
using System.Linq;
using System.Windows.Forms;

/// <summary>Container to hold all the information about experience points for a session, for all levels.</summary>
public struct Level
{
	public struct XPBlock
	{
		public string addedXP, totalXP, totalXPEach;
	}

	public XPBlock _1to3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20;
}

/// <summary>Experience point Calculator for D&D 3.5.</summary>
static class EXPCalculator
{
	private static NumericUpDown[] numberOfMonstersNumericUpDownArray;
	private static ComboBox[] challangeRatingComboBoxArray;

	/// <summary>Takes in an array of NumericUpDowns and ComboBoxes to pull information from for calculating experience when needed. Both arrays should be of equal size.</summary>
	public static void InitializeCalculator(NumericUpDown[] _numberOfMonstersNumericUpDownArray, ComboBox[] _challangeRatingComboBoxArray)
	{
		if (_numberOfMonstersNumericUpDownArray.Length != _challangeRatingComboBoxArray.Length)
		{
			throw new Exception("Both arrays sare not of equal size.");
		}

		numberOfMonstersNumericUpDownArray = _numberOfMonstersNumericUpDownArray;
		challangeRatingComboBoxArray = _challangeRatingComboBoxArray;

		foreach (ComboBox box in challangeRatingComboBoxArray) // adds challange ratings to drop down
		{
			box.Items.Add("1/10");
			box.Items.Add("1/8");
			box.Items.Add("1/6");
			box.Items.Add("1/4");
			box.Items.Add("1/3");
			box.Items.Add("1/2");
			for (int i = 1; i <= 30; i++)
			{
				box.Items.Add(i.ToString());
			}

			box.SelectedIndex = 0;
		}
	}

	private static Level level;

	/// <summary>Returns container that holds all the information about experience points for a session.</summary>
	public static Level getLevel
	{
		get { return level; }
	}

	/// <summary>Resets the CR ComboBoxes and number of monster NumericUpDowns.</summary>
	public static void ClearInputs()
	{
		foreach (ComboBox box in challangeRatingComboBoxArray)
		{
			box.SelectedIndex = 0;
		}

		foreach (NumericUpDown box in numberOfMonstersNumericUpDownArray)
		{
			box.Value = 0;
		}
	}

	/// <summary>Resets the Level struct containing all the saved information about experience gained durring the session.</summary>
	public static void ClearOutputs()
	{
		level = new Level();
	}

	/// <summary>Cycles through all mosters and CRs, and puts that information in the Level struct</summary>
	public static void CalculateEXP(int _numOfPlayers)
	{
		// CR = Callange Rating
		int ndx, CR, XP, totalXPGain, tempXP;
		int numOfPlayers = _numOfPlayers;

		for (int lvl = 3; lvl <= 20; lvl++)
		{
			ndx = 0;
			CR = 0;
			XP = 0;
			totalXPGain = 0;
			tempXP = 0;

			foreach (NumericUpDown numOfMonsters in numberOfMonstersNumericUpDownArray)
			{
				if (numOfMonsters.Value > 0)
				{
					if (challangeRatingComboBoxArray[ndx].SelectedItem.ToString().Contains('/'))
					{
						Int32.TryParse(challangeRatingComboBoxArray[ndx].SelectedItem.ToString(), out CR);
						XP = ExperinceNumberCruncher(lvl, 1);

						Int32.TryParse(challangeRatingComboBoxArray[ndx].SelectedItem.ToString().Remove(0, 2), out CR);
						XP /= CR;
						XP *= (int)numOfMonsters.Value;
					}
					else
					{
						Int32.TryParse(challangeRatingComboBoxArray[ndx].SelectedItem.ToString(), out CR);
						XP = ExperinceNumberCruncher(lvl, CR);
						XP *= (int)numOfMonsters.Value;
					}
					totalXPGain += XP;
				}
				ndx++;
			}

			// fills everything in
			switch (lvl)
			{
				case 3:
					level._1to3.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._1to3.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._1to3.totalXP = tempXP.ToString();
					level._1to3.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 4:
					level._4.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._4.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._4.totalXP = tempXP.ToString();
					level._4.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 5:
					level._5.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._5.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._5.totalXP = tempXP.ToString();
					level._5.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 6:
					level._6.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._6.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._6.totalXP = tempXP.ToString();
					level._6.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 7:
					level._7.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._7.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._7.totalXP = tempXP.ToString();
					level._7.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 8:
					level._8.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._8.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._8.totalXP = tempXP.ToString();
					level._8.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 9:
					level._9.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._9.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._9.totalXP = tempXP.ToString();
					level._9.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 10:
					level._10.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._10.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._10.totalXP = tempXP.ToString();
					level._10.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 11:
					level._11.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._11.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._11.totalXP = tempXP.ToString();
					level._11.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 12:
					level._12.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._12.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._12.totalXP = tempXP.ToString();
					level._12.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 13:
					level._13.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._13.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._13.totalXP = tempXP.ToString();
					level._13.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 14:
					level._14.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._14.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._14.totalXP = tempXP.ToString();
					level._14.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 15:
					level._15.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._15.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._15.totalXP = tempXP.ToString();
					level._15.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 16:
					level._16.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._16.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._16.totalXP = tempXP.ToString();
					level._16.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 17:
					level._17.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._17.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._17.totalXP = tempXP.ToString();
					level._17.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 18:
					level._18.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._18.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._18.totalXP = tempXP.ToString();
					level._18.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 19:
					level._19.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._19.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._19.totalXP = tempXP.ToString();
					level._19.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
				case 20:
					level._20.addedXP = totalXPGain.ToString();
					Int32.TryParse(level._20.totalXP, out tempXP);
					tempXP += totalXPGain;
					level._20.totalXP = tempXP.ToString();
					level._20.totalXPEach = (tempXP / numOfPlayers).ToString();
					break;
			}
		}
	}

	/// <summary>D&D 3.5 experience point algorithm</summary>
	private static int ExperinceNumberCruncher(int LVL, int CR)
	{
		// how D&D 3.5 does exp, took a while to turn their exp table into an equation I could use
		int XP = 0;

		int multiplier = 1;

		if (LVL == 5 && CR == 1) return 300;
		if (LVL == 4 && CR == 1) return 300;

		if (LVL <= 3)
		{
			if (CR == 1) return 300;
			else if (CR == 2) return 600;
			else if (CR == 3) return 900;
			else
			{
				XP = 900;
				multiplier = 450;

				for (int i = 4; i <= CR; i++)
				{
					XP += multiplier;
					if (i % 2 == 1) multiplier *= 2;
				}

				return XP;
			}
		}
		else
		{
			int levelDiffrence = CR - LVL;
			bool canMultiply = true;

			if (!(levelDiffrence >= 0)) canMultiply = false;

			while (levelDiffrence < -1 || levelDiffrence > 1)
			{
				if (levelDiffrence < -1) levelDiffrence += 2;
				if (levelDiffrence > 1) levelDiffrence -= 2;

				multiplier *= 2;
			}

			if (levelDiffrence == 0) XP = 300 * LVL;
			if (levelDiffrence == 1) XP = 400 * LVL;
			if (levelDiffrence == -1) XP = 200 * LVL;

			if (canMultiply) XP *= multiplier;
			else XP /= multiplier;

		}
		return XP;
	}
}