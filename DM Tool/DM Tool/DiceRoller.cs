using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM_Tool
{
    public static class DiceRoller // ALL THE RANDOM NUMBER simple class that makes rolling fake dice easier
    {
        public static string diceRolls;

        private static Random rand = new Random();

        public static int RandomNum(int min, int max)
        {
            if (max + 1 <= min) return 0;

            return rand.Next(min, max + 1);
        }

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

        public static int RollD2(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD2();
            }

            return sum;
        }

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

        public static int RollD3(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD3();
            }

            return sum;
        }

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

        public static int RollD4()
        {
            int sum = rand.Next(1, 5);

            return sum;
        }

        public static int RollD4(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD4();
            }

            return sum;
        }

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

        public static int RollD6()
        {
            int sum = rand.Next(1, 7);
            
            return sum;
        }

        public static int RollD6(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD6();
            }

            return sum;
        }

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

        public static int RollD8()
        {
            int sum = rand.Next(1, 9);

            return sum;
        }

        public static int RollD8(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD8();
            }

            return sum;
        }

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

        public static int RollD10()
        {
            int sum = rand.Next(1, 11);

            return sum;
        }

        public static int RollD10(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD10();
            }

            return sum;
        }

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

        public static int RollD12()
        {
            int sum = rand.Next(1, 13);

            return sum;
        }

        public static int RollD12(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD12();
            }

            return sum;
        }

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

        public static int RollD20()
        {
            int sum = rand.Next(1, 21);

            return sum;
        }

        public static int RollD20(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD20();
            }

            return sum;
        }

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

        public static int RollD100(uint howMany)
        {
            int sum = 0;

            for (int i = 0; i < howMany; i++)
            {
                sum += RollD100();
            }

            return sum;
        }

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
    }
}
