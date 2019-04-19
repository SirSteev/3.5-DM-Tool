using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DM_Tool
{
    public partial class DMToolForm : Form
    {
        StartNewCampaignForm newCampaignForm;
        DiceRolls diceRollsForm;

        float informationTBFontSize;
        
        public DMToolForm()
        {
            InitializeComponent();
            
            pbMap.MouseHover += new EventHandler(pbMap_MouseHover);

            #region EXP Calculator

            InitializeEXPCalculator();

            #endregion

            #region Information Library

            InitializeInformationLibrary();

            #endregion

            #region Initiative Tracker

            InitializeInitiativeTracker();

            #endregion

            #region Calendar

            newCampaignForm = new StartNewCampaignForm();
            
            #endregion
        }

        private void startNewCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newCampaignForm.ShowDialog() == DialogResult.OK)
            {
                RefreshCalendar();

                foreach (var player in InitiativeTracker.InitiativeList)
                {
                    lbInitTrackName.Items.Add(player.Name);
                    lbInitTrackInit.Items.Add(player.Initiative);
                    lbInitTrackHP.Items.Add(player.HPMax);
                }
            }
        }

        #region EXP Calculator

        private void InitializeEXPCalculator()
        {
            ComboBox[] challangeRatingComboBoxArray;
            NumericUpDown[] numberOfMonstersNumericUpDownArray;

            challangeRatingComboBoxArray = new ComboBox[8];
            challangeRatingComboBoxArray[0] = CRNum1;
            challangeRatingComboBoxArray[1] = CRNum2;
            challangeRatingComboBoxArray[2] = CRNum3;
            challangeRatingComboBoxArray[3] = CRNum4;
            challangeRatingComboBoxArray[4] = CRNum5;
            challangeRatingComboBoxArray[5] = CRNum6;
            challangeRatingComboBoxArray[6] = CRNum7;
            challangeRatingComboBoxArray[7] = CRNum8;

            numberOfMonstersNumericUpDownArray = new NumericUpDown[8];
            numberOfMonstersNumericUpDownArray[0] = numOfMonsters1;
            numberOfMonstersNumericUpDownArray[1] = numOfMonsters2;
            numberOfMonstersNumericUpDownArray[2] = numOfMonsters3;
            numberOfMonstersNumericUpDownArray[3] = numOfMonsters4;
            numberOfMonstersNumericUpDownArray[4] = numOfMonsters5;
            numberOfMonstersNumericUpDownArray[5] = numOfMonsters6;
            numberOfMonstersNumericUpDownArray[6] = numOfMonsters7;
            numberOfMonstersNumericUpDownArray[7] = numOfMonsters8;
            
            EXPCalculator.InitializeCalculator(numberOfMonstersNumericUpDownArray, challangeRatingComboBoxArray);
        }

        private void btnEXPCalc_Click(object sender, EventArgs e)
        {
            EXPCalculator.CalculateEXP((int)numOfPartyMembers.Value);
            UpdateXP(EXPCalculator.getLevel);
        }

        private void UpdateXP(Level level) // pulls all info from class and fills the boxes
        {
            addedXP1to3Bx.Text = level._1to3.addedXP;
            totalXP1to3Bx.Text = level._1to3.totalXP;
            totalXPEach1to3Bx.Text = level._1to3.totalXPEach;

            addedXP4Bx.Text = level._4.addedXP;
            totalXP4Bx.Text = level._4.totalXP;
            totalXPEach4Bx.Text = level._4.totalXPEach;

            addedXP5Bx.Text = level._5.addedXP;
            totalXP5Bx.Text = level._5.totalXP;
            totalXPEach5Bx.Text = level._5.totalXPEach;

            addedXP6Bx.Text = level._6.addedXP;
            totalXP6Bx.Text = level._6.totalXP;
            totalXPEach6Bx.Text = level._6.totalXPEach;

            addedXP7Bx.Text = level._7.addedXP;
            totalXP7Bx.Text = level._7.totalXP;
            totalXPEach7Bx.Text = level._7.totalXPEach;

            addedXP8Bx.Text = level._8.addedXP;
            totalXP8Bx.Text = level._8.totalXP;
            totalXPEach8Bx.Text = level._8.totalXPEach;

            addedXP9Bx.Text = level._9.addedXP;
            totalXP9Bx.Text = level._9.totalXP;
            totalXPEach9Bx.Text = level._9.totalXPEach;

            addedXP10Bx.Text = level._10.addedXP;
            totalXP10Bx.Text = level._10.totalXP;
            totalXPEach10Bx.Text = level._10.totalXPEach;

            addedXP11Bx.Text = level._11.addedXP;
            totalXP11Bx.Text = level._11.totalXP;
            totalXPEach11Bx.Text = level._11.totalXPEach;

            addedXP12Bx.Text = level._12.addedXP;
            totalXP12Bx.Text = level._12.totalXP;
            totalXPEach12Bx.Text = level._12.totalXPEach;

            addedXP13Bx.Text = level._13.addedXP;
            totalXP13Bx.Text = level._13.totalXP;
            totalXPEach13Bx.Text = level._13.totalXPEach;

            addedXP14Bx.Text = level._14.addedXP;
            totalXP14Bx.Text = level._14.totalXP;
            totalXPEach14Bx.Text = level._14.totalXPEach;

            addedXP15Bx.Text = level._15.addedXP;
            totalXP15Bx.Text = level._15.totalXP;
            totalXPEach15Bx.Text = level._15.totalXPEach;

            addedXP16Bx.Text = level._16.addedXP;
            totalXP16Bx.Text = level._16.totalXP;
            totalXPEach16Bx.Text = level._16.totalXPEach;

            addedXP17Bx.Text = level._17.addedXP;
            totalXP17Bx.Text = level._17.totalXP;
            totalXPEach17Bx.Text = level._17.totalXPEach;

            addedXP18Bx.Text = level._18.addedXP;
            totalXP18Bx.Text = level._18.totalXP;
            totalXPEach18Bx.Text = level._18.totalXPEach;

            addedXP19Bx.Text = level._19.addedXP;
            totalXP19Bx.Text = level._19.totalXP;
            totalXPEach19Bx.Text = level._19.totalXPEach;

            addedXP20Bx.Text = level._20.addedXP;
            totalXP20Bx.Text = level._20.totalXP;
            totalXPEach20Bx.Text = level._20.totalXPEach;
        }

        private void btnEXPClearInputs_Click(object sender, EventArgs e)
        {
            EXPCalculator.ClearInputs();
        }

        private void btnEXPClearOutputs_Click(object sender, EventArgs e)
        {
            EXPCalculator.ClearOutputs();
            UpdateXP(EXPCalculator.getLevel);
        }

        private void btnEXPClearAll_Click(object sender, EventArgs e)
        {
            EXPCalculator.ClearInputs();
            EXPCalculator.ClearOutputs();
            UpdateXP(EXPCalculator.getLevel);
        }
        #endregion

        #region Information Library

        private void InitializeInformationLibrary()
        {
            InformationLibrary.InitializeLibrary();

            foreach (var plant in InformationLibrary.PlantEntries)
            {
                lbPlants.Items.Add(plant.Name);
            }
            foreach (var weather in InformationLibrary.WeatherEntries)
            {
                lbWeather.Items.Add(weather.Name);
            }
            foreach (var feat in InformationLibrary.FeatEntries)
            {
                lbFeats.Items.Add(feat.Name);
            }

            informationTBFontSize = 8.5f;
            TbInformation.Font = new Font(FontFamily.GenericMonospace, informationTBFontSize);
        }

        private void btnInfoTBFontSizeUp_Click(object sender, EventArgs e)
        {
            informationTBFontSize += 1;
            TbInformation.Font = new Font(FontFamily.GenericMonospace, informationTBFontSize);
        }

        private void btnInfoTBFontSizeDown_Click(object sender, EventArgs e)
        {
            informationTBFontSize -= 1;
            TbInformation.Font = new Font(FontFamily.GenericMonospace, informationTBFontSize);
        }

        // all the searches highlight the keyword in the text box

        private void tbPlantSearchKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnPlantNameSearch_Click(sender, e);
        }

        private void tbWeatherSearchKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnWeatherNameSearch_Click(sender, e);
        }

        private void tbFeatsSearchKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnFeatsSearchName_Click(sender, e);
        }

        private void btnPlantNameSearch_Click(object sender, EventArgs e) // this search im still not sure if i like, something about it feels off but im not sure what
        {
            lbPlants.Items.Clear();
            foreach (var plant in InformationLibrary.PlantNameSearch(tbPlantSearchKeyword.Text))
            {
                bool allFalseRarity = false;
                bool allfalseRegion = false;

                if (!cbPlantSearchVeryCommon.Checked && !cbPlantSearchCommon.Checked &&
                    !cbPlantSearchUncommon.Checked && !cbPlantSearchRare.Checked &&
                    !cbPlantSearchVeryRare.Checked && !cbPlantSearchLegendary.Checked)
                {
                    allFalseRarity = true;
                }
                if (!cbPlantSearchArctic.Checked && !cbPlantSearchCities.Checked &&
                    !cbPlantSearchCoastal.Checked && !cbPlantSearchDeserts.Checked &&
                    !cbPlantSearchForests.Checked && !cbPlantSearchJungles.Checked &&
                    !cbPlantSearchMountains.Checked && !cbPlantSearchOceans.Checked &&
                    !cbPlantSearchPlains.Checked && !cbPlantSearchRivers.Checked &&
                    !cbPlantSearchSwamps.Checked && !cbPlantSearchUnderdarkCave.Checked &&
                    !cbPlantSearchUnknown.Checked)
                {
                    allfalseRegion = true;
                }

                if ((cbPlantSearchVeryCommon.Checked && plant.Rarity == RarityType.VeryCommon) ||
                    (cbPlantSearchCommon.Checked && plant.Rarity == RarityType.Common) ||
                    (cbPlantSearchUncommon.Checked && plant.Rarity == RarityType.Uncommon) ||
                    (cbPlantSearchRare.Checked && plant.Rarity == RarityType.Rare) ||
                    (cbPlantSearchVeryRare.Checked && plant.Rarity == RarityType.VeryRare) ||
                    (cbPlantSearchLegendary.Checked && plant.Rarity == RarityType.Legendary) ||
                    allFalseRarity)
                {
                    if ((cbPlantSearchArctic.Checked && plant.Regions.Contains(RegionSubTypes.Arctic)) ||
                        (cbPlantSearchCities.Checked && plant.Regions.Contains(RegionSubTypes.Cities)) ||
                        (cbPlantSearchCoastal.Checked && plant.Regions.Contains(RegionSubTypes.Coastal)) ||
                        (cbPlantSearchDeserts.Checked && plant.Regions.Contains(RegionSubTypes.Deserts)) ||
                        (cbPlantSearchForests.Checked && plant.Regions.Contains(RegionSubTypes.Forests)) ||
                        (cbPlantSearchJungles.Checked && plant.Regions.Contains(RegionSubTypes.Jungles)) ||
                        (cbPlantSearchMountains.Checked && plant.Regions.Contains(RegionSubTypes.Mountains)) ||
                        (cbPlantSearchOceans.Checked && plant.Regions.Contains(RegionSubTypes.Oceans)) ||
                        (cbPlantSearchPlains.Checked && plant.Regions.Contains(RegionSubTypes.Plains)) ||
                        (cbPlantSearchRivers.Checked && plant.Regions.Contains(RegionSubTypes.Rivers)) ||
                        (cbPlantSearchSwamps.Checked && plant.Regions.Contains(RegionSubTypes.Swamps)) ||
                        (cbPlantSearchUnderdarkCave.Checked && plant.Regions.Contains(RegionSubTypes.UnderdarkCaves)) ||
                        (cbPlantSearchUnknown.Checked && plant.Regions.Contains(RegionSubTypes.Unknown)) ||
                        allfalseRegion)
                    {
                        lbPlants.Items.Add(plant.Name);
                    }
                }
            }
        }

        private void btnPlantDescriptionSearch_Click(object sender, EventArgs e)
        {
            lbPlants.Items.Clear();
            foreach (var plant in InformationLibrary.PlantDescriptionSearch(tbPlantSearchKeyword.Text))
            {
                if ((cbPlantSearchVeryCommon.Checked && plant.Rarity == RarityType.VeryCommon) ||
                    (cbPlantSearchCommon.Checked && plant.Rarity == RarityType.Common) ||
                    (cbPlantSearchUncommon.Checked && plant.Rarity == RarityType.Uncommon) ||
                    (cbPlantSearchRare.Checked && plant.Rarity == RarityType.Rare) ||
                    (cbPlantSearchVeryRare.Checked && plant.Rarity == RarityType.VeryRare) ||
                    (cbPlantSearchLegendary.Checked && plant.Rarity == RarityType.Legendary) ||
                    (cbPlantSearchArctic.Checked && plant.Regions.Contains(RegionSubTypes.Arctic)) ||
                    (cbPlantSearchCities.Checked && plant.Regions.Contains(RegionSubTypes.Cities)) ||
                    (cbPlantSearchCoastal.Checked && plant.Regions.Contains(RegionSubTypes.Coastal)) ||
                    (cbPlantSearchDeserts.Checked && plant.Regions.Contains(RegionSubTypes.Deserts)) ||
                    (cbPlantSearchForests.Checked && plant.Regions.Contains(RegionSubTypes.Forests)) ||
                    (cbPlantSearchJungles.Checked && plant.Regions.Contains(RegionSubTypes.Jungles)) ||
                    (cbPlantSearchMountains.Checked && plant.Regions.Contains(RegionSubTypes.Mountains)) ||
                    (cbPlantSearchOceans.Checked && plant.Regions.Contains(RegionSubTypes.Oceans)) ||
                    (cbPlantSearchPlains.Checked && plant.Regions.Contains(RegionSubTypes.Plains)) ||
                    (cbPlantSearchRivers.Checked && plant.Regions.Contains(RegionSubTypes.Rivers)) ||
                    (cbPlantSearchSwamps.Checked && plant.Regions.Contains(RegionSubTypes.Swamps)) ||
                    (cbPlantSearchUnderdarkCave.Checked && plant.Regions.Contains(RegionSubTypes.UnderdarkCaves)) ||
                    (cbPlantSearchUnknown.Checked && plant.Regions.Contains(RegionSubTypes.Unknown)))
                {
                    lbPlants.Items.Add(plant.Name);
                }
            }
        }

        private void lbPlants_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lineBreaker = Environment.NewLine + "--------------------------------------------" + Environment.NewLine;
            int ndx = 0;
            Plant plnt = InformationLibrary.PlantEntries.Find(entry => entry.Name == lbPlants.SelectedItem.ToString());
            string rarity = "Rarity: ";
            string regions = "Region: ";

            switch (plnt.Rarity)
            {
                case RarityType.VeryCommon:
                    rarity += "Very Common";
                    break;
                case RarityType.Common:
                    rarity += "Common";
                    break;
                case RarityType.Uncommon:
                    rarity += "Uncommon";
                    break;
                case RarityType.Rare:
                    rarity += "Rare";
                    break;
                case RarityType.VeryRare:
                    rarity += "Very Rare";
                    break;
                case RarityType.Legendary:
                    rarity += "Legendary";
                    break;
                default:
                    rarity = "STILL NULL";
                    break;
            }

            foreach (var item in plnt.Regions)
            {
                switch (item)
                {
                    case RegionSubTypes.Arctic:
                        regions += "Arctic";
                        break;
                    case RegionSubTypes.Cities:
                        regions += "Cities";
                        break;
                    case RegionSubTypes.Coastal:
                        regions += "Coastal";
                        break;
                    case RegionSubTypes.Deserts:
                        regions += "Deserts";
                        break;
                    case RegionSubTypes.Forests:
                        regions += "Forests";
                        break;
                    case RegionSubTypes.Jungles:
                        regions += "Jungles";
                        break;
                    case RegionSubTypes.Mountains:
                        regions += "Mountains";
                        break;
                    case RegionSubTypes.Oceans:
                        regions += "Oceans";
                        break;
                    case RegionSubTypes.Plains:
                        regions += "Plains";
                        break;
                    case RegionSubTypes.Rivers:
                        regions += "Rivers";
                        break;
                    case RegionSubTypes.Swamps:
                        regions += "Swamps";
                        break;
                    case RegionSubTypes.UnderdarkCaves:
                        regions += "Underdark Caves";
                        break;
                    case RegionSubTypes.Unknown:
                        regions += "Unknown";
                        break;
                    default:
                        break;
                }
                regions += ", ";
            }
            regions = regions.Remove(regions.Length - 2 ,2);

            string temp = plnt.Name + lineBreaker + rarity + Environment.NewLine + regions + lineBreaker + plnt.Description;

            TbInformation.Text = string.Empty;
            TbInformation.Text = temp;

            string search = tbPlantSearchKeyword.Text;

            while (ndx < TbInformation.TextLength)
            {
                int wordStartIndex = TbInformation.Find(search, ndx, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    TbInformation.SelectionStart = wordStartIndex;
                    TbInformation.SelectionLength = search.Length;
                    TbInformation.SelectionBackColor = Color.Orange;
                }
                else
                    break;
                ndx += wordStartIndex + search.Length;
            }
        }

        private void btnWeatherNameSearch_Click(object sender, EventArgs e)
        {
            lbWeather.Items.Clear();
            foreach (var weather in InformationLibrary.WeatherNameSearch(tbWeatherSearchKeyword.Text))
            {
                lbWeather.Items.Add(weather.Name);
            }
        }

        private void BtnWeatherDescriptionSearch_Click(object sender, EventArgs e)
        {
            lbWeather.Items.Clear();
            foreach (var weather in InformationLibrary.WeatherDescriptionSearch(tbWeatherSearchKeyword.Text))
            {
                lbWeather.Items.Add(weather.Name);
            }
        }

        private void lbWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ndx = 0;
            string lineBreaker = Environment.NewLine + "--------------------------------------------" + Environment.NewLine;
            LibraryEntry lidEntry = InformationLibrary.WeatherEntries.Find(entry => entry.Name == lbWeather.SelectedItem.ToString());


            string temp = lidEntry.Name + lineBreaker + lidEntry.Description;
            TbInformation.Text = string.Empty;
            TbInformation.Text = temp;

            string search = tbWeatherSearchKeyword.Text;

            while (ndx < TbInformation.TextLength)
            {
                int wordStartIndex = TbInformation.Find(search, ndx, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    TbInformation.SelectionStart = wordStartIndex;
                    TbInformation.SelectionLength = search.Length;
                    TbInformation.SelectionBackColor = Color.Orange;
                }
                else
                    break;
                ndx += wordStartIndex + search.Length;
            }
        }

        private void lbFeats_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ndx = 0;
            string lineBreaker = Environment.NewLine + "--------------------------------------------" + Environment.NewLine;
            Feat featEntry = InformationLibrary.FeatEntries.Find(entry => entry.Name == lbFeats.SelectedItem.ToString());


            string temp = featEntry.Name + " " + featEntry.Source + lineBreaker + featEntry.Prerequisite + lineBreaker + featEntry.Description;
            TbInformation.Text = string.Empty;
            TbInformation.Text = temp;

            string search = tbFeatsSearchKeyword.Text;

            while (ndx < TbInformation.TextLength)
            {
                int wordStartIndex = TbInformation.Find(search, ndx, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    TbInformation.SelectionStart = wordStartIndex;
                    TbInformation.SelectionLength = search.Length;
                    TbInformation.SelectionBackColor = Color.Orange;
                }
                else
                    break;
                ndx += wordStartIndex + search.Length;
            }
        }

        private void btnFeatsSearchName_Click(object sender, EventArgs e)
        {
            lbFeats.Items.Clear();

            lbFeats.Items.Add(InformationLibrary.FeatEntries[0].Name);

            foreach (var feat in InformationLibrary.FeatNameSearch(tbFeatsSearchKeyword.Text))
            {
                if (feat == InformationLibrary.FeatEntries[0]) continue;
                lbFeats.Items.Add(feat.Name);
            }
        }

        private void btnFeatsSearchDescription_Click(object sender, EventArgs e)
        {
            lbFeats.Items.Clear();

            lbFeats.Items.Add(InformationLibrary.FeatEntries[0].Name);

            foreach (var feat in InformationLibrary.FeatDescriptionSearch(tbFeatsSearchKeyword.Text))
            {
                if (feat == InformationLibrary.FeatEntries[0]) continue;
                lbFeats.Items.Add(feat.Name);
            }
        }

        private void btnFeatsSearchSource_Click(object sender, EventArgs e)
        {
            lbFeats.Items.Clear();

            lbFeats.Items.Add(InformationLibrary.FeatEntries[0].Name);

            foreach (var feat in InformationLibrary.FeatSourceSearch(tbFeatsSearchKeyword.Text))
            {
                if (feat == InformationLibrary.FeatEntries[0]) continue;
                lbFeats.Items.Add(feat.Name);
            }
        }

        private void btnFeatsSearchPrerequisite_Click(object sender, EventArgs e)
        {
            lbFeats.Items.Clear();

            lbFeats.Items.Add(InformationLibrary.FeatEntries[0].Name);

            foreach (var feat in InformationLibrary.FeatPrerequisiteSearch(tbFeatsSearchKeyword.Text))
            {
                if (feat == InformationLibrary.FeatEntries[0]) continue;
                lbFeats.Items.Add(feat.Name);
            }
        }

        #endregion

        #region Dice Box
        private void btnExportDiceRolls_Click(object sender, EventArgs e)
        {
            DiceRoller.DiceRolls = tbDiceBox.Text;
            diceRollsForm = new DiceRolls();
            diceRollsForm.Show();
        }

        private void btnRandomNumGen_Click(object sender, EventArgs e)
        {
            tbRandomNum.Text = DiceRoller.RandomRangeNumber((int)nudRandMin.Value, (int)nudRandMax.Value).ToString();
        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            List<int> diceList = new List<int>();
            int sum = 0;
            int grandTotal = 0;
            string showWork = string.Empty;
            string lineBreaker = Environment.NewLine + "------------------------------------------------------------------------------------------------------" + Environment.NewLine;

            diceList = DiceRoller.RollD2((uint)nudNumD2.Value, out sum);
            showWork += "D2: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD3((uint)nudNumD3.Value, out sum);
            showWork += "D3: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD4((uint)nudNumD4.Value, out sum);
            showWork += "D4: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD6((uint)nudNumD6.Value, out sum);
            showWork += "D6: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD8((uint)nudNumD8.Value, out sum);
            showWork += "D8: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD10((uint)nudNumD10.Value, out sum);
            showWork += "D10: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD12((uint)nudNumD12.Value, out sum);
            showWork += "D12: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD20((uint)nudNumD20.Value, out sum);
            showWork += "D20: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            diceList = DiceRoller.RollD100((uint)nudNumD100.Value, out sum);
            showWork += "D100: ";
            foreach (var diceRoll in diceList)
            {
                showWork += diceRoll.ToString() + ", ";
            }
            showWork = showWork.Remove(showWork.Length - 2, 2);
            showWork += " : Total: " + sum.ToString() + lineBreaker;
            grandTotal += sum;

            showWork += "Grand Total: " + grandTotal.ToString();

            tbDiceBox.Text = showWork;
        }

        private void btnClearDiceBox_Click(object sender, EventArgs e)
        {
            nudNumD2.Value = 0;
            nudNumD3.Value = 0;
            nudNumD4.Value = 0;
            nudNumD6.Value = 0;
            nudNumD8.Value = 0;
            nudNumD10.Value = 0;
            nudNumD12.Value = 0;
            nudNumD20.Value = 0;
            nudNumD100.Value = 0;

            nudRandMin.Value = 0;
            nudRandMax.Value = 0;

            tbDiceBox.Text = string.Empty;
            tbRandomNum.Text = string.Empty;
        }


        #endregion

        #region Calendar

        public void RefreshCalendar()
        {
            this.Text = "3.5 DM Tool - " + Calendar.campaignName;
        }

        #endregion
        
        #region Sound Board

        private void btnSoundOcean_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundOcean();
        }

        private void btnSoundThunder_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundThunder();
        }

        private void btnSoundRainLight_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundRainLight();
        }

        private void btnSoundRainHeavy_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundRainHeavy();
        }

        private void btnSoundRoughOcean_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundRoughOcean();
        }

        private void btnSoundWindLight_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundWindLight();
        }

        private void btnSoundWindHeavy_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundWindHeavy();
        }

        private void btnSoundFireLight_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundFireLight();
        }

        private void btnSoundFireHeavy_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundFireHeavy();
        }

        private void btnSoundNightBugs_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundNightBugs();
        }

        private void btnSoundNightSwamp_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundNightSwamp();
        }

        private void btnSoundLute_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundLute();
        }

        private void btnSoundDrum_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundDrum();
        }

        private void btnSoundHarp_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundHarp();
        }

        private void btnSoundHarpLuteDrum_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundHarpLuteDrum();
        }

        private void btnSoundDrumWar_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundDrumWar();
        }

        private void btnSoundRainIndoors_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundRainIndoors();
        }

        private void btnSoundTavern_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundTavern();
        }

        private void btnSoundSeaShanties_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundSeaShanties();
        }

        private void btnSoundThunderCrack_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundThunderCrack();
        }

        private void btnSoundChoirChants_Click(object sender, EventArgs e)
        {
            InformationLibrary.SoundMedievalChantsInRain();
        }

        #endregion

        #region Initiative Tracker

        private void InitializeInitiativeTracker()
        {
            InitiativeTracker.InitializeInitiativeTracker(this);
            
            btnInitTrackEndInitiative.Enabled = false;
        }

        private void btnInitTrackEndTurn_Click(object sender, EventArgs e)
        {
            InitiativeTracker.EndTurn();
        }

        private void lbInitTrackName_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitiativeTracker.NameSelectedIndexChanged();
        }

        private void lbInitTrackInit_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitiativeTracker.InitiativeSelectedIndexChanged();
        }

        private void lbInitTrackHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitiativeTracker.HPSelectedIndexChanged();
        }

        private void btnInitTrackAddCombatant_Click(object sender, EventArgs e)
        {
            InitiativeTracker.AddCombatant();
        }

        private void btnInitTrackApplyDamage_Click(object sender, EventArgs e)
        {
            if (lbInitTrackName.SelectedItem != null)
            {
                InitiativeTracker.ApplyDamageToIndex(Int32.Parse(nudInitTrackDamageApplyer.Text), lbInitTrackName.SelectedIndex);
            }
        }

        private void btnInitTrackRemoveFromInit_Click(object sender, EventArgs e)
        {
            if (lbInitTrackName.SelectedItem != null)
            {
                InitiativeTracker.RemoveIndexFromInitiative(lbInitTrackName.SelectedIndex);
            }
        }

        private void btnInitTrackStartInitiative_Click(object sender, EventArgs e)
        {
            if (InitiativeTracker.StartInitiative())
            {
                btnInitTrackSortInitiative.Enabled = false;

                btnInitTrackStartInitiative.Enabled = false;
                btnInitTrackEndInitiative.Enabled = true;
            }
        }

        private void btnInitTrackEndInitiative_Click(object sender, EventArgs e)
        {
            InitiativeTracker.EndInitiative();

            btnInitTrackSortInitiative.Enabled = true;

            btnInitTrackStartInitiative.Enabled = true;
            btnInitTrackEndInitiative.Enabled = false;
        }

        private void btnInitTrackUpdate_Click(object sender, EventArgs e)
        {
            if (lbInitTrackName.SelectedItem != null)
            {
                InitiativeTracker.UpdateInitiativeAndHPAtIndex((int)nudInitTrackInitUpdate.Value, (int)nudInitTrackHPUpdate.Value, lbInitTrackName.SelectedIndex);
            }
        }

        private void btnInitTrackUpdateInitUp_Click(object sender, EventArgs e)
        {
            if (lbInitTrackName.SelectedItem != null && lbInitTrackName.SelectedIndex != 0)
            {
                InitiativeTracker.UpdateInitiativeUp(lbInitTrackName.SelectedIndex);
            }
        }

        private void btnInitTrackUpdateInitDown_Click(object sender, EventArgs e)
        {
            if (lbInitTrackName.SelectedItem != null && lbInitTrackName.SelectedIndex != lbInitTrackName.Items.Count - 1)
            {
                InitiativeTracker.UpdateInitializeDown(lbInitTrackName.SelectedIndex);
            }
        }

        private void btnInitTrackHoldAction_Click(object sender, EventArgs e)
        {
            InitiativeTracker.HoldAction();
        }

        private void btnInitTrackUseHeldAction_Click(object sender, EventArgs e)
        {
            InitiativeTracker.UseHeldAction();
        }

        private void btnInitTrackSortInitiative_Click(object sender, EventArgs e)
        {
            InitiativeTracker.SortInitiativeList();
        }

        #endregion

        #region World Map

        private void btnMapSetup_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Map Image|*.jpg;*.jpeg;*.png";
            ofd.Title = "Select a Map File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and an image was selected
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property. 
                InformationLibrary.WorldMapLocation = ofd.FileName;


                Bitmap bmp = new Bitmap(InformationLibrary.WorldMapLocation);
                float zoomFactor = (float)nudMapScale.Value;
                float graphScale = (float)nudGraphScale.Value;
                
                DrawMap(bmp, graphScale, zoomFactor);
            }
        }

        private void btnUpdateMap_Click(object sender, EventArgs e)
        {
            Bitmap map;

            if (InformationLibrary.WorldMapLocation != null)
            {
                map = new Bitmap(InformationLibrary.WorldMapLocation);
            }
            else
            {
                // default, made it big so image could be used in photoshop if wanted
                map = new Bitmap(12000, 5000); 
            }

            
            float zoomFactor = (float)nudMapScale.Value;
            float graphScale = (float)nudGraphScale.Value;

            // scales image
            Size newSize = new Size((int)(map.Width * zoomFactor), (int)(map.Height * zoomFactor));
            Bitmap bmp = new Bitmap(map, newSize);

            DrawMap(bmp, graphScale, zoomFactor);
        }

        private void DrawMap(Bitmap bmp, float graphScale, float zoomFactor) // Draws map grid over image
        {
            if (rbMapSquare.Checked)
            {
                for (int y = 0; y < bmp.Height / graphScale / zoomFactor; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        bmp.SetPixel(x, (int)(y * graphScale * zoomFactor), Color.Black);
                    }
                }

                for (int x = 0; x < bmp.Width / graphScale / zoomFactor; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        bmp.SetPixel((int)(x * graphScale * zoomFactor), y, Color.Black);
                    }
                }
            }
            if (rbMapHex.Checked)
            {
                bool flag;

                for (int y = 0; y < bmp.Height / graphScale / zoomFactor; y++)
                {
                    for (int x = 0; x < bmp.Width / zoomFactor; x++)
                    {
                        int lineX = (int)(x * graphScale * zoomFactor);
                        int lineX1 = (int)((x + 1) * graphScale * zoomFactor);
                        int lineY = (int)(y * graphScale * zoomFactor);

                        if ((x + (y % 2)) % 2 == 0)
                        {
                            bmp = line(lineX, (int)(graphScale * 1 / 4) + lineY, lineX1, lineY, bmp, out flag);
                            bmp = line(lineX, (int)(graphScale * 1 / 4) + lineY, lineX, lineY + (int)(graphScale * zoomFactor), bmp, out flag);
                        }
                        else
                            bmp = line(lineX, lineY, lineX1, (int)(graphScale * 1 / 4) + lineY, bmp, out flag);
                        if (flag)
                        {
                            if ((x + (y % 2)) % 2 == 0)
                                bmp = line(lineX1, lineY, lineX, (int)(graphScale * 1 / 4) + lineY, bmp, out flag);
                            else
                                bmp = line(lineX1, (int)(graphScale * 1 / 4) + lineY, lineX, lineY, bmp, out flag);
                        }
                    }
                }
            }
            pbMap.Image = bmp;
        }

        public Bitmap line(int x1, int y1, int x2, int y2, Bitmap bitmap, out bool flag)
        {
            // found this code online but added a flag incase it tries to draw out of bounds
            flag = false;
            
            int w = x2 - x1;
            int h = y2 - y1;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x1 >= bitmap.Width || y1 >= bitmap.Height)
                {
                    flag = true;
                    return bitmap;
                }

                bitmap.SetPixel(x1, y1, Color.Black);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x1 += dx1;
                    y1 += dy1;
                }
                else
                {
                    x1 += dx2;
                    y1 += dy2;
                }
            }
            return bitmap;
        }

        private void btnMapSaveImage_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the  
                // File type selected in the dialog box.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        pbMap.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        pbMap.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        pbMap.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        pbMap.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

                fs.Close();
            }
        }

        private void pbMap_MouseHover(object sender, EventArgs e)
        {
            spMapPanel.Focus();
        }

        #endregion

        private void DMToolForm_Load(object sender, EventArgs e)
        {

        }
    }
}
