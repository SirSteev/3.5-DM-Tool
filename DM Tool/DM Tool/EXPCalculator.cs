using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DM_Tool
{
    public struct Level // struct to hold all the numbers i wanted to keep track of
    {
        public struct XPBlock
        {
            public string addedXP, totalXP, totalXPEach;
        }

        public XPBlock _1to3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20;
    }

    static class EXPCalculator
    {
        private static NumericUpDown[] numericUpDownArray;
        private static ComboBox[] comboBoxArray;

        public static void InitCalculator(NumericUpDown[] _numericUpDownArray, ComboBox[] _comboBoxArray)
        {
            numericUpDownArray = _numericUpDownArray;
            comboBoxArray = _comboBoxArray;
        }

        private static Level level;

        public static Level getLevel
        {
            get { return level; }
        }

        public static void ClearInputs()
        {
            foreach (ComboBox box in comboBoxArray)
            {
                box.SelectedIndex = 0;
            }

            foreach (NumericUpDown box in numericUpDownArray)
            {
                box.Value = 0;
            }
        }

        public static void ClearOutputs()
        {
            level = new Level();
        }

        public static void CalculateEXP(int _numOfPlayers)
        {
            // finds exp values by passing lvl and challange rating to the number cruncher and adding it all up
            for (int lvl = 3; lvl <= 20; lvl++)
            {
                int i = 0;
                int CR = 0;
                int XP = 0;
                int totalXPGain = 0;
                int temp = 0;
                int numOfPlayers = _numOfPlayers;

                foreach (NumericUpDown numOfMonsters in numericUpDownArray)
                {
                    if (numOfMonsters.Value > 0)
                    {
                        if (comboBoxArray[i].SelectedItem.ToString().Contains('/'))
                        {
                            Int32.TryParse(comboBoxArray[i].SelectedItem.ToString(), out CR);
                            XP = experinceNumberCruncher(lvl, 1);

                            Int32.TryParse(comboBoxArray[i].SelectedItem.ToString().Remove(0, 2), out CR);
                            XP /= CR;
                            XP *= (int)numOfMonsters.Value;
                        }
                        else
                        {
                            Int32.TryParse(comboBoxArray[i].SelectedItem.ToString(), out CR);
                            XP = experinceNumberCruncher(lvl, CR);
                            XP *= (int)numOfMonsters.Value;
                        }
                        totalXPGain += XP;
                    }
                    i++;
                }

                // fills everything in
                switch (lvl)
                {
                    case 3:
                        level._1to3.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._1to3.totalXP, out temp);
                        temp += totalXPGain;
                        level._1to3.totalXP = temp.ToString();
                        level._1to3.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 4:
                        level._4.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._4.totalXP, out temp);
                        temp += totalXPGain;
                        level._4.totalXP = temp.ToString();
                        level._4.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 5:
                        level._5.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._5.totalXP, out temp);
                        temp += totalXPGain;
                        level._5.totalXP = temp.ToString();
                        level._5.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 6:
                        level._6.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._6.totalXP, out temp);
                        temp += totalXPGain;
                        level._6.totalXP = temp.ToString();
                        level._6.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 7:
                        level._7.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._7.totalXP, out temp);
                        temp += totalXPGain;
                        level._7.totalXP = temp.ToString();
                        level._7.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 8:
                        level._8.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._8.totalXP, out temp);
                        temp += totalXPGain;
                        level._8.totalXP = temp.ToString();
                        level._8.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 9:
                        level._9.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._9.totalXP, out temp);
                        temp += totalXPGain;
                        level._9.totalXP = temp.ToString();
                        level._9.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 10:
                        level._10.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._10.totalXP, out temp);
                        temp += totalXPGain;
                        level._10.totalXP = temp.ToString();
                        level._10.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 11:
                        level._11.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._11.totalXP, out temp);
                        temp += totalXPGain;
                        level._11.totalXP = temp.ToString();
                        level._11.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 12:
                        level._12.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._12.totalXP, out temp);
                        temp += totalXPGain;
                        level._12.totalXP = temp.ToString();
                        level._12.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 13:
                        level._13.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._13.totalXP, out temp);
                        temp += totalXPGain;
                        level._13.totalXP = temp.ToString();
                        level._13.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 14:
                        level._14.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._14.totalXP, out temp);
                        temp += totalXPGain;
                        level._14.totalXP = temp.ToString();
                        level._14.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 15:
                        level._15.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._15.totalXP, out temp);
                        temp += totalXPGain;
                        level._15.totalXP = temp.ToString();
                        level._15.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 16:
                        level._16.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._16.totalXP, out temp);
                        temp += totalXPGain;
                        level._16.totalXP = temp.ToString();
                        level._16.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 17:
                        level._17.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._17.totalXP, out temp);
                        temp += totalXPGain;
                        level._17.totalXP = temp.ToString();
                        level._17.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 18:
                        level._18.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._18.totalXP, out temp);
                        temp += totalXPGain;
                        level._18.totalXP = temp.ToString();
                        level._18.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 19:
                        level._19.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._19.totalXP, out temp);
                        temp += totalXPGain;
                        level._19.totalXP = temp.ToString();
                        level._19.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                    case 20:
                        level._20.addedXP = totalXPGain.ToString();
                        Int32.TryParse(level._20.totalXP, out temp);
                        temp += totalXPGain;
                        level._20.totalXP = temp.ToString();
                        level._20.totalXPEach = (temp / numOfPlayers).ToString();
                        break;
                }
            }
        }

        private static int experinceNumberCruncher(int LVL, int CR)
        {
            // how D&D 3.5 does exp, took a while to turn their exp table into an equation i could use
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
}
