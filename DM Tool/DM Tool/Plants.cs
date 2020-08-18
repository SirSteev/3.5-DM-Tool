using System.Collections.Generic;

namespace DM_Tool
{
	public class Plants
	{
		private List<Dice> SearchRolls = new List<Dice>();
		private RegionSubTypes SearchRegion = RegionSubTypes.Forests;

		public bool CanSearch => NumberOfPlants > 0;
		public int NumberOfPlants { get; private set; } = 0;

		public string GetDiceRollFromSearchRoll(int searchRoll)
		{
			SearchRolls = new List<Dice>();

			if (searchRoll < 10)
				return "None";

			if (searchRoll >= 20)
			{
				SearchRolls.Add(Dice.d8);
				SearchRolls.Add(Dice.d4);
				SearchRolls.Add(Dice.d4);

				return "1d8 + 2d4";
			}

			if (searchRoll >= 15)
			{
				SearchRolls.Add(Dice.d8);
				SearchRolls.Add(Dice.d4);

				return "1d8 + 1d4";
			}

			SearchRolls.Add(Dice.d8);

			return "1d8";
		}

		public int RollNumberOnPlantsFound()
		{
			int total = 0;

			foreach (Dice die in SearchRolls)
			{
				if (die == Dice.d8)
					total += DiceRoller.RollD8();

				if (die == Dice.d4)
					total += DiceRoller.RollD4();
			}

			NumberOfPlants = total;

			return total;
		}

		public List<string> RollFindAllPlants()
		{
			List<string> plants = new List<string>();

			while (NumberOfPlants > 0)
			{
				NumberOfPlants--;

				int d100 = DiceRoller.RollD100();

				plants.Add(GetRandomPlantNameBasedOn(GetPlantSearchCategory(d100)));
			}

			return plants;
		}

		private PlantCategories GetPlantSearchCategory(int roll)
		{
			PlantCategories plantCategories = new PlantCategories();
			plantCategories.Regions.Add(SearchRegion);

			if (roll == 100)
			{
				plantCategories.Rarities.Add(RarityType.Legendary);
				plantCategories.Rarities.Add(RarityType.VeryRare);
				return plantCategories;
			}

			if (roll == 99)
			{
				plantCategories.Rarities.Add(RarityType.VeryRare);
				return plantCategories;
			}

			if (roll >= 94)
			{
				plantCategories.Rarities.Add(RarityType.Rare);
				return plantCategories;
			}

			if (roll >= 82)
			{
				plantCategories.Rarities.Add(RarityType.Uncommon);
				return plantCategories;
			}

			if (roll >= 56)
			{
				plantCategories.Rarities.Add(RarityType.Common);
				return plantCategories;
			}

			plantCategories.Rarities.Add(RarityType.VeryCommon);

			return plantCategories;
		}

		private string GetRandomPlantNameBasedOn(PlantCategories plantCategories)
		{
			List<Plant> plants = InformationLibrary.PlantClosedSearchByCategory(plantCategories);

			Plant plant = plants[DiceRoller.RandomRangeNumber(0, plants.Count - 1)];

			return plant.Name;
		}

		public string RollFindPlant(int roll)
		{
			NumberOfPlants--;

			PlantCategories plantCategories = GetPlantSearchCategory(roll);

			return GetRandomPlantNameBasedOn(plantCategories);
		}

		public void SetSearchRegion(RegionSubTypes region)
		{
			SearchRegion = region;
		}

		public void SetNumberOfPlantsFound(int number)
		{
			NumberOfPlants = number;
		}
	}
}