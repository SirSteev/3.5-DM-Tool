using System;

namespace DM_Tool
{
	// masive finite state mechine still working on it
	// ment to be givin limited input and spit out a ton of information

	public enum Climate
	{
		Cold,
		Temperate,
		Tropical
	}

	public enum Elevation
	{
		SeaLevel,
		LowLands,
		Highlands
	}

	public enum Season
	{
		Spring,
		Summer,
		Fall,
		Winter
	}

	public enum PrecipitationIntensity
	{
		Light,
		Medium,
		Heavy,
		Torrential
	}

	public enum PrecipitationFrequency
	{
		Drought,
		Rare,
		Intermittent,
		Common,
		Constant
	}

	public enum PrecipitationForm
	{
		Drizzle,
		FogLight,
		FogMedium,
		FogHeavy,
		Rain,
		RainLight,
		RainHeavy,
		Sleet,
		SnowLight,
		SnowMedium,
		SnowHeavy,
		Thunderstorm
	}

	public enum CloudCover
	{
		None,
		CloudsLight,
		CloudsMedium,
		Overcast
	}

	public enum WindStrength
	{
		Light,
		Moderate,
		Strong,
		Severe,
		Windstorm
	}

	public enum CharacterSize
	{
		None,
		Fine,
		Diminutive,
		Tiny,
		Small,
		Medium,
		Large,
		Huge,
		Gargantuan,
		Colossal
	}

	public enum SevereWeatherEvent
	{
		None,
		Blizzard,
		Haboob,
		Hail,
		Hurricane,
		Sandstorm,
		Thundersnow,
		Tornado,
		Wildfire
	}

	public class Weather
	{
		Climate climate;
		Elevation elevation;
		Season season;
		PrecipitationIntensity precipitationIntensity;
		PrecipitationFrequency precipitationFrequency;
		PrecipitationForm precipitationForm;
		CloudCover cloudCover;
		WindStrength windStrength;
		CharacterSize windCheckSize;
		CharacterSize windBlownAwaySize;
		SevereWeatherEvent severeWeatherEvent;

		int precipitationFormRoll;
		int precipitationChanceRoll;
		int cloudCoverRoll;
		int tempVariationRoll;
		int windStrengthRoll;

		bool inDesert;
		bool isDay;
		bool isRaining;

		int tempForDays;
		int rainForHours;
		string rainFromTo;

		int tempBaseline;
		int tempVariation;
		int currentTemp;

		int windSpeed;
		int windSkillCheckPenalty;

		public Weather()
		{
			climate = Climate.Temperate;
			elevation = Elevation.SeaLevel;
			season = Season.Spring;
			precipitationIntensity = PrecipitationIntensity.Heavy;
			precipitationFrequency = PrecipitationFrequency.Intermittent;
			precipitationForm = PrecipitationForm.RainHeavy;
			cloudCover = CloudCover.CloudsMedium;
			windStrength = WindStrength.Light;
			windCheckSize = CharacterSize.None;
			windBlownAwaySize = CharacterSize.None;
			severeWeatherEvent = SevereWeatherEvent.None;

			inDesert = false;
			isDay = true;

			RecalculateAll(true);
		}

		public void RecalculateAll(bool reroll)
		{
			SetClimateBaseLine();
			SetTempVariation(reroll);
			SetElevationBaseline();
			SetSeasonalBaseline();
			SetPrecipitationAdjustments();
			SetCloudCover(reroll);

			if (RollPrecipitationChance(reroll))
				GetPrecipitation(reroll);

			SetWindStrength(reroll);
			SetSevereEvents();
		}

		public void NextDay()
		{
			tempForDays--;
			SetClimateBaseLine();

			if (tempForDays <= 0)
				SetTempVariation(true);

			SetElevationBaseline();
			SetSeasonalBaseline();
			SetPrecipitationAdjustments();
			SetCloudCover(true);

			if (RollPrecipitationChance(true))
				GetPrecipitation(true);

			SetWindStrength(true);
			SetSevereEvents();

		}

		#region Sets

		public void SetDayNight(bool isItDay)
		{
			isDay = isItDay;

			RecalculateAll(false);
		}

		public void SetInDesert(bool isInDesert)
		{
			inDesert = isInDesert;

			RecalculateAll(false);
		}

		public void SetSeason(Season newSeason)
		{
			season = newSeason;

			RecalculateAll(false);
		}

		public void SetClimate(Climate newClimate)
		{
			climate = newClimate;

			RecalculateAll(false);
		}

		public void SetElevation(Elevation newElevation)
		{
			elevation = newElevation;

			RecalculateAll(false);
		}

		#endregion

		#region Gets

		public string GetCloudCover()
		{
			return cloudCover.ToString();
		}

		public string GetWindStrength()
		{
			return windStrength.ToString();
		}

		public string GetWindSpeed()
		{
			return windSpeed.ToString();
		}

		public string GetCurrentTempature()
		{
			return currentTemp.ToString();
		}

		public string GetTempatureForDays()
		{
			return tempForDays.ToString();
		}

		public string GetRainIntensity()
		{
			if (!isRaining)
				return "-";

			return precipitationIntensity.ToString();
		}

		public string GetRainFrequency()
		{
			if (!isRaining)
				return "-";

			return precipitationFrequency.ToString();
		}

		public string GetRainType()
		{
			if (severeWeatherEvent != SevereWeatherEvent.None)
				return severeWeatherEvent.ToString();

			if (!isRaining)
				return "-";

			return precipitationForm.ToString();
		}

		public string GetRainForHours()
		{
			if (!isRaining)
				return "-";

			return rainForHours.ToString();
		}

		public string GetRainFromTo()
		{
			if (!isRaining)
				return "-";

			return rainFromTo;
		}

		public string GetIsRaining()
		{
			return isRaining.ToString();
		}

		public string GetSizeCheck()
		{
			return windCheckSize.ToString();
		}

		public string GetBlownAway()
		{
			return windBlownAwaySize.ToString();
		}

		public string GetSkillCheck()
		{
			return windSkillCheckPenalty.ToString();
		}

		#endregion

		// all numbers from here out are pulled from tables in a pathfinder book

		private void SetClimateBaseLine()
		{
			switch (climate)
			{
				case Climate.Cold:
					switch (season)
					{
						case Season.Spring:
							tempBaseline = 30;
							break;
						case Season.Summer:
							tempBaseline = 40;
							break;
						case Season.Fall:
							tempBaseline = 30;
							break;
						case Season.Winter:
							tempBaseline = 20;
							break;
						default:
							break;
					}
					break;
				case Climate.Temperate:
					switch (season)
					{
						case Season.Spring:
							tempBaseline = 60;
							break;
						case Season.Summer:
							tempBaseline = 80;
							break;
						case Season.Fall:
							tempBaseline = 60;
							break;
						case Season.Winter:
							tempBaseline = 30;
							break;
						default:
							break;
					}
					break;
				case Climate.Tropical:
					switch (season)
					{
						case Season.Spring:
							tempBaseline = 75;
							break;
						case Season.Summer:
							tempBaseline = 95;
							break;
						case Season.Fall:
							tempBaseline = 75;
							break;
						case Season.Winter:
							tempBaseline = 50;
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
		}

		private void SetTempVariation(bool reroll)
		{
			if (reroll) tempVariationRoll = DiceRoller.RollD100();

			switch (climate)
			{
				case Climate.Cold:
					if (tempVariationRoll >= 1 && tempVariationRoll <= 20)
					{
						tempVariation = -DiceRoller.RollD10(3);
						tempForDays = DiceRoller.RollD4();
					}
					else if (tempVariationRoll >= 21 && tempVariationRoll <= 40)
					{
						tempVariation = -DiceRoller.RollD10(2);
						tempForDays = DiceRoller.RollD6() + 1;
					}
					else if (tempVariationRoll >= 41 && tempVariationRoll <= 60)
					{
						tempVariation = -DiceRoller.RollD10();
						tempForDays = DiceRoller.RollD6() + 2;
					}
					else if (tempVariationRoll >= 61 && tempVariationRoll <= 80)
					{
						tempVariation = 0;
						tempForDays = DiceRoller.RollD6() + 2;
					}
					else if (tempVariationRoll >= 81 && tempVariationRoll <= 95)
					{
						tempVariation = DiceRoller.RollD10();
						tempForDays = DiceRoller.RollD6() + 1;
					}
					else if (tempVariationRoll >= 96 && tempVariationRoll <= 99)
					{
						tempVariation = DiceRoller.RollD10(2);
						tempForDays = DiceRoller.RollD4();
					}
					else if (tempVariationRoll == 100)
					{
						tempVariation = DiceRoller.RollD10(3);
						tempForDays = DiceRoller.RollD2();
					}
					else
					{
						Console.WriteLine("SetTempVariation() Cold d100: " + tempVariationRoll);
					}
					break;
				case Climate.Temperate:
					if (tempVariationRoll >= 1 && tempVariationRoll <= 5)
					{
						tempVariation = -DiceRoller.RollD10(3);
						tempForDays = DiceRoller.RollD2();
					}
					else if (tempVariationRoll >= 6 && tempVariationRoll <= 15)
					{
						tempVariation = -DiceRoller.RollD10(2);
						tempForDays = DiceRoller.RollD4();
					}
					else if (tempVariationRoll >= 16 && tempVariationRoll <= 35)
					{
						tempVariation = -DiceRoller.RollD10();
						tempForDays = DiceRoller.RollD4() + 1;
					}
					else if (tempVariationRoll >= 36 && tempVariationRoll <= 65)
					{
						tempVariation = 0;
						tempForDays = DiceRoller.RollD6() + 1;
					}
					else if (tempVariationRoll >= 66 && tempVariationRoll <= 85)
					{
						tempVariation = DiceRoller.RollD10();
						tempForDays = DiceRoller.RollD4() + 1;
					}
					else if (tempVariationRoll >= 86 && tempVariationRoll <= 95)
					{
						tempVariation = DiceRoller.RollD10(2);
						tempForDays = DiceRoller.RollD4();
					}
					else if (tempVariationRoll >= 96 && tempVariationRoll <= 100)
					{
						tempVariation = DiceRoller.RollD10(3);
						tempForDays = DiceRoller.RollD2();
					}
					else
					{
						Console.WriteLine("SetTempVariation() Temperate d100: " + tempVariationRoll);
					}
					break;
				case Climate.Tropical:
					if (tempVariationRoll >= 1 && tempVariationRoll <= 10)
					{
						tempVariation = -DiceRoller.RollD10(2);
						tempForDays = DiceRoller.RollD2();
					}
					else if (tempVariationRoll >= 11 && tempVariationRoll <= 25)
					{
						tempVariation = -DiceRoller.RollD10();
						tempForDays = DiceRoller.RollD2();
					}
					else if (tempVariationRoll >= 26 && tempVariationRoll <= 55)
					{
						tempVariation = 0;
						tempForDays = DiceRoller.RollD4();
					}
					else if (tempVariationRoll >= 56 && tempVariationRoll <= 85)
					{
						tempVariation = DiceRoller.RollD10();
						tempForDays = DiceRoller.RollD4();
					}
					else if (tempVariationRoll >= 86 && tempVariationRoll <= 100)
					{
						tempVariation = DiceRoller.RollD10(2);
						tempForDays = DiceRoller.RollD2();
					}
					else
					{
						Console.WriteLine("SetTempVariation() Temperate d100: " + tempVariationRoll);
					}
					break;
				default:
					break;
			}

			if (reroll)
			{
				switch (season)
				{
					case Season.Spring:
						tempVariation -= 10;
						break;
					case Season.Summer:
						tempVariation -= 10;
						break;
					case Season.Fall:
						tempVariation += 10;
						break;
					case Season.Winter:
						tempVariation += 10;
						break;
					default:
						break;
				}
			}
		}

		private void SetElevationBaseline()
		{
			switch (elevation)
			{
				case Elevation.SeaLevel:
					tempBaseline += 10;
					precipitationIntensity = PrecipitationIntensity.Heavy;
					break;
				case Elevation.LowLands:
					precipitationIntensity = PrecipitationIntensity.Medium;
					break;
				case Elevation.Highlands:
					tempBaseline -= 10;
					precipitationIntensity = PrecipitationIntensity.Medium;
					break;
				default:
					break;
			}
		}

		private void SetSeasonalBaseline()
		{
			switch (season)
			{
				case Season.Spring:
					switch (climate)
					{
						case Climate.Cold:
							precipitationFrequency = PrecipitationFrequency.Intermittent;
							break;
						case Climate.Temperate:
							precipitationFrequency = PrecipitationFrequency.Intermittent;
							break;
						case Climate.Tropical:
							precipitationFrequency = PrecipitationFrequency.Common;
							break;
						default:
							break;
					}
					break;
				case Season.Summer:
					switch (climate)
					{
						case Climate.Cold:
							precipitationFrequency = PrecipitationFrequency.Common;
							break;
						case Climate.Temperate:
							precipitationFrequency = PrecipitationFrequency.Common;
							break;
						case Climate.Tropical:
							precipitationFrequency = PrecipitationFrequency.Intermittent;
							break;
						default:
							break;
					}
					break;
				case Season.Fall:
					switch (climate)
					{
						case Climate.Cold:
							precipitationFrequency = PrecipitationFrequency.Intermittent;
							break;
						case Climate.Temperate:
							precipitationFrequency = PrecipitationFrequency.Intermittent;
							break;
						case Climate.Tropical:
							precipitationFrequency = PrecipitationFrequency.Common;
							break;
						default:
							break;
					}
					break;
				case Season.Winter:
					switch (climate)
					{
						case Climate.Cold:
							precipitationFrequency = PrecipitationFrequency.Rare;
							break;
						case Climate.Temperate:
							precipitationFrequency = PrecipitationFrequency.Rare;
							break;
						case Climate.Tropical:
							precipitationFrequency = PrecipitationFrequency.Rare;
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
		}

		private void SetPrecipitationAdjustments()
		{
			switch (climate)
			{
				case Climate.Cold:
					DecreasePrecipitationFrequency();
					DecreasePrecipitationIntensity();
					break;
				case Climate.Temperate:
					break;
				case Climate.Tropical:
					IncreasePrecipitationFrequency();
					IncreasePrecipitationIntensity();
					break;
				default:
					break;
			}

			switch (elevation)
			{
				case Elevation.SeaLevel:
					break;
				case Elevation.LowLands:
					break;
				case Elevation.Highlands:
					DecreasePrecipitationFrequency();
					break;
				default:
					break;
			}

			if (inDesert) precipitationFrequency = PrecipitationFrequency.Drought;

			switch (precipitationFrequency)
			{
				case PrecipitationFrequency.Drought:
					DecreasePrecipitationIntensity();
					DecreasePrecipitationIntensity();
					break;
				case PrecipitationFrequency.Rare:
					break;
				case PrecipitationFrequency.Intermittent:
					break;
				case PrecipitationFrequency.Common:
					break;
				case PrecipitationFrequency.Constant:
					break;
				default:
					break;
			}
		}

		private bool RollPrecipitationChance(bool reroll)
		{
			isRaining = false;

			if (reroll) precipitationChanceRoll = DiceRoller.RollD100();

			switch (precipitationFrequency)
			{
				case PrecipitationFrequency.Drought:
					if (precipitationChanceRoll <= 5)
					{
						cloudCover = CloudCover.Overcast;
						isRaining = true;
					}
					break;
				case PrecipitationFrequency.Rare:
					if (precipitationChanceRoll <= 15)
					{
						cloudCover = CloudCover.Overcast;
						isRaining = true;
					}
					break;
				case PrecipitationFrequency.Intermittent:
					if (precipitationChanceRoll <= 30)
					{
						cloudCover = CloudCover.Overcast;
						isRaining = true;
					}
					break;
				case PrecipitationFrequency.Common:
					if (precipitationChanceRoll <= 60)
					{
						cloudCover = CloudCover.Overcast;
						isRaining = true;
					}
					break;
				case PrecipitationFrequency.Constant:
					if (precipitationChanceRoll <= 95)
					{
						cloudCover = CloudCover.Overcast;
						isRaining = true;
					}
					break;
				default:
					break;
			}

			if (!isDay)
				tempVariation -= DiceRoller.RollD6(2) + 3;

			currentTemp = tempBaseline + tempVariation;

			return isRaining;
		}

		private void GetPrecipitation(bool reroll)
		{
			if (reroll) precipitationFormRoll = DiceRoller.RollD100();

			int startTime = DiceRoller.RollD12();
			string startM = DiceRoller.RollD6() > 3 ? "PM" : "AM";

			if (currentTemp > 32)
			{
				switch (precipitationIntensity)
				{
					case PrecipitationIntensity.Light:
						if (precipitationFormRoll <= 20)
						{
							precipitationForm = PrecipitationForm.FogLight;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 21 && precipitationFormRoll <= 40)
						{
							precipitationForm = PrecipitationForm.FogMedium;
							if (reroll) rainForHours = DiceRoller.RollD6();
						}
						else if (precipitationFormRoll >= 41 && precipitationFormRoll <= 50)
						{
							precipitationForm = PrecipitationForm.Drizzle;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 51 && precipitationFormRoll <= 75)
						{
							precipitationForm = PrecipitationForm.Drizzle;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						else if (precipitationFormRoll >= 76 && precipitationFormRoll <= 90)
						{
							precipitationForm = PrecipitationForm.RainLight;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 91 && precipitationFormRoll <= 100)
						{
							if (currentTemp >= 40) precipitationForm = PrecipitationForm.RainLight;
							else precipitationForm = PrecipitationForm.Sleet;
							if (reroll) rainForHours = 1;
						}
						break;
					case PrecipitationIntensity.Medium:
						if (precipitationFormRoll <= 10)
						{
							precipitationForm = PrecipitationForm.FogMedium;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 11 && precipitationFormRoll <= 20)
						{
							precipitationForm = PrecipitationForm.FogMedium;
							if (reroll) rainForHours = DiceRoller.RollD12();
						}
						else if (precipitationFormRoll >= 21 && precipitationFormRoll <= 30)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 31 && precipitationFormRoll <= 35)
						{
							precipitationForm = PrecipitationForm.Rain;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 36 && precipitationFormRoll <= 70)
						{
							precipitationForm = PrecipitationForm.Rain;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 71 && precipitationFormRoll <= 90)
						{
							precipitationForm = PrecipitationForm.Rain;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						else if (precipitationFormRoll >= 91 && precipitationFormRoll <= 100)
						{
							if (currentTemp >= 40) precipitationForm = PrecipitationForm.Rain;
							else precipitationForm = PrecipitationForm.Sleet;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						break;
					case PrecipitationIntensity.Heavy:
						if (precipitationFormRoll <= 10)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 11 && precipitationFormRoll <= 20)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD6(2);
						}
						else if (precipitationFormRoll >= 21 && precipitationFormRoll <= 50)
						{
							precipitationForm = PrecipitationForm.RainHeavy;
							if (reroll) rainForHours = DiceRoller.RollD12();
						}
						else if (precipitationFormRoll >= 51 && precipitationFormRoll <= 70)
						{
							precipitationForm = PrecipitationForm.RainHeavy;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						else if (precipitationFormRoll >= 71 && precipitationFormRoll <= 85)
						{
							if (currentTemp >= 40) precipitationForm = PrecipitationForm.RainHeavy;
							else precipitationForm = PrecipitationForm.Sleet;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 86 && precipitationFormRoll <= 90)
						{
							precipitationForm = PrecipitationForm.Thunderstorm;
							if (reroll) rainForHours = 1;
						}
						else if (precipitationFormRoll >= 91 && precipitationFormRoll <= 100)
						{
							precipitationForm = PrecipitationForm.Thunderstorm;
							if (reroll) rainForHours = DiceRoller.RollD3();
						}
						break;
					case PrecipitationIntensity.Torrential:
						if (precipitationFormRoll <= 5)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 6 && precipitationFormRoll <= 10)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD6(2);
						}
						else if (precipitationFormRoll >= 11 && precipitationFormRoll <= 30)
						{
							precipitationForm = PrecipitationForm.RainHeavy;
							if (reroll) rainForHours = DiceRoller.RollD6(2);
						}
						else if (precipitationFormRoll >= 31 && precipitationFormRoll <= 60)
						{
							precipitationForm = PrecipitationForm.RainHeavy;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						else if (precipitationFormRoll >= 61 && precipitationFormRoll <= 80)
						{
							if (currentTemp >= 40) precipitationForm = PrecipitationForm.RainHeavy;
							else precipitationForm = PrecipitationForm.Sleet;
							if (reroll) rainForHours = DiceRoller.RollD6(2);
						}
						else if (precipitationFormRoll >= 81 && precipitationFormRoll <= 95)
						{
							precipitationForm = PrecipitationForm.Thunderstorm;
							if (reroll) rainForHours = DiceRoller.RollD3();
						}
						else if (precipitationFormRoll >= 96 && precipitationFormRoll <= 100)
						{
							precipitationForm = PrecipitationForm.Thunderstorm;
							if (reroll) rainForHours = DiceRoller.RollD6();
						}
						break;
					default:
						break;
				}
			}
			else
			{
				switch (precipitationIntensity)
				{
					case PrecipitationIntensity.Light:
						if (precipitationFormRoll <= 20)
						{
							precipitationForm = PrecipitationForm.FogLight;
							if (reroll) rainForHours = DiceRoller.RollD6();
						}
						else if (precipitationFormRoll >= 21 && precipitationFormRoll <= 40)
						{
							precipitationForm = PrecipitationForm.FogLight;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 41 && precipitationFormRoll <= 50)
						{
							precipitationForm = PrecipitationForm.FogMedium;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 51 && precipitationFormRoll <= 60)
						{
							precipitationForm = PrecipitationForm.SnowLight;
							if (reroll) rainForHours = 1;
						}
						else if (precipitationFormRoll >= 61 && precipitationFormRoll <= 75)
						{
							precipitationForm = PrecipitationForm.SnowLight;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 76 && precipitationFormRoll <= 100)
						{
							precipitationForm = PrecipitationForm.SnowLight;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						break;
					case PrecipitationIntensity.Medium:
						if (precipitationFormRoll <= 10)
						{
							precipitationForm = PrecipitationForm.FogMedium;
							if (reroll) rainForHours = DiceRoller.RollD6();
						}
						else if (precipitationFormRoll >= 11 && precipitationFormRoll <= 20)
						{
							precipitationForm = PrecipitationForm.FogMedium;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 21 && precipitationFormRoll <= 30)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 31 && precipitationFormRoll <= 50)
						{
							precipitationForm = PrecipitationForm.SnowMedium;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 51 && precipitationFormRoll <= 90)
						{
							precipitationForm = PrecipitationForm.SnowMedium;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 91 && precipitationFormRoll <= 100)
						{
							precipitationForm = PrecipitationForm.SnowMedium;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						break;
					case PrecipitationIntensity.Heavy:
						if (precipitationFormRoll <= 10)
						{
							precipitationForm = PrecipitationForm.FogMedium;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 11 && precipitationFormRoll <= 20)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD6(2);
						}
						else if (precipitationFormRoll >= 21 && precipitationFormRoll <= 60)
						{
							precipitationForm = PrecipitationForm.SnowLight;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						else if (precipitationFormRoll >= 61 && precipitationFormRoll <= 90)
						{
							precipitationForm = PrecipitationForm.SnowMedium;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 91 && precipitationFormRoll <= 100)
						{
							precipitationForm = PrecipitationForm.SnowHeavy;
							if (reroll) rainForHours = DiceRoller.RollD6();
						}
						break;
					case PrecipitationIntensity.Torrential:
						if (precipitationFormRoll <= 5)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 6 && precipitationFormRoll <= 10)
						{
							precipitationForm = PrecipitationForm.FogHeavy;
							if (reroll) rainForHours = DiceRoller.RollD6(2);
						}
						else if (precipitationFormRoll >= 11 && precipitationFormRoll <= 50)
						{
							precipitationForm = PrecipitationForm.SnowHeavy;
							if (reroll) rainForHours = DiceRoller.RollD4();
						}
						else if (precipitationFormRoll >= 51 && precipitationFormRoll <= 90)
						{
							precipitationForm = PrecipitationForm.SnowHeavy;
							if (reroll) rainForHours = DiceRoller.RollD8();
						}
						else if (precipitationFormRoll >= 91 && precipitationFormRoll <= 100)
						{
							precipitationForm = PrecipitationForm.SnowHeavy;
							if (reroll) rainForHours = DiceRoller.RollD12(2);
						}
						break;
					default:
						break;
				}
			}

			int endTime = startTime + rainForHours;
			string endM = startM;

			while (endTime > 12)
			{
				endTime -= 12;

				if (endM == "AM")
					endM = "PM";
				else
					endM = "AM";
			}

			rainFromTo = $"{startTime}{startM} - {endTime}{endM}";
		}

		private void SetCloudCover(bool reroll)
		{
			if (reroll) cloudCoverRoll = DiceRoller.RollD100();

			if (cloudCoverRoll <= 50)
			{
				cloudCover = CloudCover.None;
			}
			else if (cloudCoverRoll >= 51 && cloudCoverRoll <= 70)
			{
				cloudCover = CloudCover.CloudsLight;
			}
			else if (cloudCoverRoll >= 71 && cloudCoverRoll <= 85)
			{
				cloudCover = CloudCover.CloudsMedium;
			}
			else if (cloudCoverRoll >= 86 && cloudCoverRoll <= 100)
			{
				cloudCover = CloudCover.Overcast;
			}
		}

		private void SetWindStrength(bool reroll)
		{
			if (reroll) windStrengthRoll = DiceRoller.RollD100();

			if (windStrengthRoll <= 50)
			{
				windStrength = WindStrength.Light;
				if (reroll) windSpeed = DiceRoller.RandomRangeNumber(0, 10);
				windCheckSize = CharacterSize.None;
				windBlownAwaySize = CharacterSize.None;
				windSkillCheckPenalty = 0;
			}
			else if (windStrengthRoll >= 51 && windStrengthRoll <= 80)
			{
				windStrength = WindStrength.Moderate;
				if (reroll) windSpeed = DiceRoller.RandomRangeNumber(11, 20);
				windCheckSize = CharacterSize.None;
				windBlownAwaySize = CharacterSize.None;
				windSkillCheckPenalty = 0;
			}
			else if (windStrengthRoll >= 81 && windStrengthRoll <= 90)
			{
				windStrength = WindStrength.Strong;
				if (reroll) windSpeed = DiceRoller.RandomRangeNumber(21, 30);
				windCheckSize = CharacterSize.Tiny;
				windBlownAwaySize = CharacterSize.None;
				windSkillCheckPenalty = -2;
			}
			else if (windStrengthRoll >= 91 && windStrengthRoll <= 95)
			{
				windStrength = WindStrength.Severe;
				if (reroll) windSpeed = DiceRoller.RandomRangeNumber(31, 50);
				windCheckSize = CharacterSize.Small;
				windBlownAwaySize = CharacterSize.Tiny;
				windSkillCheckPenalty = -4;
			}
			else if (windStrengthRoll >= 96 && windStrengthRoll <= 100)
			{
				windStrength = WindStrength.Windstorm;
				if (reroll) windSpeed = DiceRoller.RandomRangeNumber(51, 300);
				windCheckSize = CharacterSize.Medium;
				windBlownAwaySize = CharacterSize.Small;
				windSkillCheckPenalty = -8;
			}
		}

		private void SetSevereEvents() // if the system spits out a crazy number cool things happen
		{
			if ((windStrength == WindStrength.Severe || windStrength == WindStrength.Windstorm) && isRaining && precipitationForm == PrecipitationForm.SnowHeavy)
			{
				if (DiceRoller.RollD100() <= 20) rainForHours = DiceRoller.RollD12(2);
				severeWeatherEvent = SevereWeatherEvent.Blizzard;
			}
			else if ((windStrength == WindStrength.Severe || windStrength == WindStrength.Windstorm) && inDesert)
			{
				severeWeatherEvent = SevereWeatherEvent.Sandstorm;
			}
			else if ((windStrength == WindStrength.Severe || windStrength == WindStrength.Windstorm) && inDesert && precipitationForm == PrecipitationForm.Thunderstorm)
			{
				severeWeatherEvent = SevereWeatherEvent.Haboob;
			}
			else if (precipitationForm == PrecipitationForm.Thunderstorm)
			{
				if (DiceRoller.RollD100() <= 5) severeWeatherEvent = SevereWeatherEvent.Hail;
			}
			else if (precipitationForm == PrecipitationForm.RainHeavy && windStrength == WindStrength.Windstorm && windSpeed >= 75)
			{
				severeWeatherEvent = SevereWeatherEvent.Hurricane;
			}
			else if (windSpeed >= 174)
			{
				severeWeatherEvent = SevereWeatherEvent.Tornado;
			}
			else
				severeWeatherEvent = SevereWeatherEvent.None;
		}

		// -- and ++ for PrecipitationFrequency and PrecipitationIntensity

		private void DecreasePrecipitationFrequency()
		{
			switch (precipitationFrequency)
			{
				case PrecipitationFrequency.Drought:
					break;
				case PrecipitationFrequency.Rare:
					precipitationFrequency = PrecipitationFrequency.Drought;
					break;
				case PrecipitationFrequency.Intermittent:
					precipitationFrequency = PrecipitationFrequency.Rare;
					break;
				case PrecipitationFrequency.Common:
					precipitationFrequency = PrecipitationFrequency.Intermittent;
					break;
				case PrecipitationFrequency.Constant:
					precipitationFrequency = PrecipitationFrequency.Common;
					break;
				default:
					break;
			}
		}

		private void IncreasePrecipitationFrequency()
		{
			switch (precipitationFrequency)
			{
				case PrecipitationFrequency.Drought:
					precipitationFrequency = PrecipitationFrequency.Rare;
					break;
				case PrecipitationFrequency.Rare:
					precipitationFrequency = PrecipitationFrequency.Intermittent;
					break;
				case PrecipitationFrequency.Intermittent:
					precipitationFrequency = PrecipitationFrequency.Common;
					break;
				case PrecipitationFrequency.Common:
					precipitationFrequency = PrecipitationFrequency.Constant;
					break;
				case PrecipitationFrequency.Constant:
					break;
				default:
					break;
			}
		}

		private void DecreasePrecipitationIntensity()
		{
			switch (precipitationIntensity)
			{
				case PrecipitationIntensity.Light:
					break;
				case PrecipitationIntensity.Medium:
					precipitationIntensity = PrecipitationIntensity.Light;
					break;
				case PrecipitationIntensity.Heavy:
					precipitationIntensity = PrecipitationIntensity.Medium;
					break;
				case PrecipitationIntensity.Torrential:
					precipitationIntensity = PrecipitationIntensity.Heavy;
					break;
				default:
					break;
			}
		}

		private void IncreasePrecipitationIntensity()
		{
			switch (precipitationIntensity)
			{
				case PrecipitationIntensity.Light:
					precipitationIntensity = PrecipitationIntensity.Medium;
					break;
				case PrecipitationIntensity.Medium:
					precipitationIntensity = PrecipitationIntensity.Heavy;
					break;
				case PrecipitationIntensity.Heavy:
					precipitationIntensity = PrecipitationIntensity.Torrential;
					break;
				case PrecipitationIntensity.Torrential:
					break;
				default:
					break;
			}
		}
	}
}