namespace DM_Tool
{
	enum SeasonalFestival
	{
		None,
		Midwinter,
		SpringEquinox,
		Greengrass,
		SummerSolstice,
		Midsummer,
		Shieldmeet,
		AutumnEquinox,
		Highharvestide,
		FeastOfTheMoon,
		WinterSolstice
	}

	static class Calendar
	{
		// *WIP* still dont know how i want to do this just playing around
		// keep track of date and keep a log of what the players have done day by day
		// save log in text doc with exp earned that day

		static int currentYear;
		static int currentDayOfYear;
		static int currentDayOfMonth;
		static int currentMonthOfYear;
		static SeasonalFestival festival;
		public static string campaignName;

		const int midwinter = 31;
		const int springEquinox = 80;
		const int greengrass = 122;
		const int summerSolstice = 172;
		const int midsummer = 213;
		const int shieldmeet = 214;
		// if leap year add 1 to rest
		const int autumnEquinox = 264;
		const int highharvestide = 274;
		const int feastOfTheMoon = 335;
		const int winterSolstice = 354;

		const int daysInYear = 365;
		const int daysInLeapYear = 366;
		static bool isLeapYear;

		static public void InitCalendar(int month, int day, int year, string _campaignName)
		{
			isLeapYear = year % 4 == 0;

			currentYear = year;
			currentDayOfMonth = day;
			currentMonthOfYear = month;
			currentDayOfYear = CalculateDayOfYear(month, day);
			campaignName = _campaignName;

			festival = CheckHoliday();
		}

		static public void InitCalendar(int year, SeasonalFestival festival, string _campaignName)
		{
			isLeapYear = year % 4 == 0;

			currentYear = year;
			currentDayOfMonth = 0;
			currentMonthOfYear = 0;

			currentDayOfYear = CalculateDayOfYear(festival);

			festival = CheckHoliday();
		}

		static private int CalculateDayOfYear(int month, int day)
		{
			int dayOfYear = ((month - 1) * 30) + day;

			if (month == 12)
			{
				dayOfYear += 5;
			}
			else if (month >= 10)
			{
				dayOfYear += 4;
			}
			else if (month >= 8)
			{
				dayOfYear += 3;
			}
			else if (month >= 5)
			{
				dayOfYear += 2;
			}
			else if (month >= 2)
			{
				dayOfYear += 1;
			}
			if (isLeapYear && dayOfYear > shieldmeet) dayOfYear += 1;

			return dayOfYear;
		}

		static private int CalculateDayOfYear(SeasonalFestival festival)
		{
			int dayOfYear = 0;

			switch (festival)
			{
				case SeasonalFestival.None:
					break;
				case SeasonalFestival.Midwinter:
					currentDayOfYear = midwinter;
					break;
				case SeasonalFestival.SpringEquinox:
					currentDayOfYear = springEquinox;
					break;
				case SeasonalFestival.Greengrass:
					currentDayOfYear = greengrass;
					break;
				case SeasonalFestival.SummerSolstice:
					currentDayOfYear = summerSolstice;
					break;
				case SeasonalFestival.Midsummer:
					currentDayOfYear = midwinter;
					break;
				case SeasonalFestival.Shieldmeet:
					currentDayOfYear = shieldmeet;
					break;
				case SeasonalFestival.AutumnEquinox:
					currentDayOfYear = autumnEquinox;
					break;
				case SeasonalFestival.Highharvestide:
					currentDayOfYear = highharvestide;
					break;
				case SeasonalFestival.FeastOfTheMoon:
					currentDayOfYear = feastOfTheMoon;
					break;
				case SeasonalFestival.WinterSolstice:
					currentDayOfYear = winterSolstice;
					break;
				default:
					break;
			}

			if (isLeapYear && dayOfYear > shieldmeet) dayOfYear += 1;

			return dayOfYear;
		}

		static private string SetMonthAndDay(int dayOfYear)
		{
			//int tempDayOfYear = dayOfYear;
			if (isLeapYear && dayOfYear > shieldmeet) dayOfYear += 1;

			currentMonthOfYear = dayOfYear / 30;
			currentDayOfMonth = dayOfYear % 30;

			return GetDate();
		}

		static public SeasonalFestival CheckHoliday()
		{
			if (currentDayOfYear == midwinter)
			{
				return SeasonalFestival.Midwinter;
			}
			else if (currentDayOfYear == springEquinox)
			{
				return SeasonalFestival.SpringEquinox;
			}
			else if (currentDayOfYear == greengrass)
			{
				return SeasonalFestival.Greengrass;
			}
			else if (currentDayOfYear == summerSolstice)
			{
				return SeasonalFestival.SummerSolstice;
			}
			else if (currentDayOfYear == midsummer)
			{
				return SeasonalFestival.Midsummer;
			}
			else if (currentDayOfYear == shieldmeet && isLeapYear)
			{
				return SeasonalFestival.Shieldmeet;
			}
			else if (currentDayOfYear == autumnEquinox || (isLeapYear && currentDayOfYear == autumnEquinox + 1))
			{
				return SeasonalFestival.AutumnEquinox;
			}
			else if (currentDayOfYear == highharvestide || (isLeapYear && currentDayOfYear == highharvestide + 1))
			{
				return SeasonalFestival.Highharvestide;
			}
			else if (currentDayOfYear == feastOfTheMoon || (isLeapYear && currentDayOfYear == feastOfTheMoon + 1))
			{
				return SeasonalFestival.FeastOfTheMoon;
			}
			else if (currentDayOfYear == winterSolstice || (isLeapYear && currentDayOfYear == winterSolstice + 1))
			{
				return SeasonalFestival.WinterSolstice;
			}
			else
			{
				return SeasonalFestival.None;
			}
		}

		static public string GetDate()
		{
			if (festival != SeasonalFestival.None)
			{
				return currentDayOfMonth + " / " + currentMonthOfYear + " / " + currentYear;
			}
			else
			{
				switch (festival)
				{
					case SeasonalFestival.None:
						return "NONE";
					case SeasonalFestival.Midwinter:
						return "Midwinter";
					case SeasonalFestival.SpringEquinox:
						return "Spring Equinox";
					case SeasonalFestival.Greengrass:
						return "Greengrass";
					case SeasonalFestival.SummerSolstice:
						return "Summer Solstice";
					case SeasonalFestival.Midsummer:
						return "Midwinter";
					case SeasonalFestival.Shieldmeet:
						return "Shieldmeet";
					case SeasonalFestival.AutumnEquinox:
						return "Autumn Equinox";
					case SeasonalFestival.Highharvestide:
						return "Highharvestide";
					case SeasonalFestival.FeastOfTheMoon:
						return "Feast Of The Moon";
					case SeasonalFestival.WinterSolstice:
						return "Winter Solstice";
					default:
						return "NULL";
				}
			}
		}

		static public string NextDay()
		{
			currentDayOfYear++;

			return SetMonthAndDay(currentDayOfYear);
		}
	}
}
