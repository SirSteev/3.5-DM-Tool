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
    // *WIP* alot of theis has to do with players and the calander both of which still arnt done yet

    public partial class StartNewCampaignForm : Form
    {
        private List<Player> players;

        public StartNewCampaignForm()
        {
            InitializeComponent();

            players = new List<Player>();

            cbSeasonalFestivals.Items.Add("Midwinter");
            cbSeasonalFestivals.Items.Add("Spring Equinox");
            cbSeasonalFestivals.Items.Add("Greengrass");
            cbSeasonalFestivals.Items.Add("Summer Solstice");
            cbSeasonalFestivals.Items.Add("Midsummer");
            cbSeasonalFestivals.Items.Add("Shieldmeet");
            cbSeasonalFestivals.Items.Add("Autumn Equinox");
            cbSeasonalFestivals.Items.Add("Highharvestide");
            cbSeasonalFestivals.Items.Add("Feast Of The Moon");
            cbSeasonalFestivals.Items.Add("Winter Solstice");

            cbSeasonalFestivals.SelectedIndex = 0;
        }

        private void btnSetDate_Click(object sender, EventArgs e)
        {
            if (tbCampaignName.Text.Length < 3)
            {
                MessageBox.Show("Please use Campaign Name longer that 3 characters");
            }
            else if (lbPlayerList.Items.Count < 1)
            {
                if (MessageBox.Show("No players found in list." + Environment.NewLine + "do you wish to start campaign anyway?", "No Players Found", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SetDate();
                }
            }
            else
            {
                foreach (var player in players)
                {
                    InformationLibrary.Players.Add(player);
                    InformationLibrary.InitiativeList.Add(player);
                }

                SetDate();
            }
        }

        private void btnSeasonalSetDate_Click(object sender, EventArgs e)
        {
            if (tbCampaignName.Text.Length < 3)
            {
                MessageBox.Show("Please use Campaign Name longer that 3 characters");
            }
            else if (lbPlayerList.Items.Count < 1)
            {
                if (MessageBox.Show("No players found in list." + Environment.NewLine + "do you wish to start campaign anyway?", "No Players Found", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SeasonalSetDate();
                }
            }
            else
            {
                foreach (var player in players)
                {
                    InformationLibrary.Players.Add(player);
                    InformationLibrary.InitiativeList.Add(player);
                }

                SeasonalSetDate();
            }
        }

        private void SeasonalSetDate()
        {
            SeasonalFestival festival = SeasonalFestival.None;

            switch (cbSeasonalFestivals.SelectedText)
            {
                case "Midwinter":
                    festival = SeasonalFestival.Midwinter;
                    break;
                case "Spring Equinox":
                    festival = SeasonalFestival.SpringEquinox;
                    break;
                case "Greengrass":
                    festival = SeasonalFestival.Greengrass;
                    break;
                case "Summer Solstice":
                    festival = SeasonalFestival.SummerSolstice;
                    break;
                case "Midsummer":
                    festival = SeasonalFestival.Midsummer;
                    break;
                case "Shieldmeet":
                    festival = SeasonalFestival.Shieldmeet;
                    break;
                case "Autumn Equinox":
                    festival = SeasonalFestival.AutumnEquinox;
                    break;
                case "Highharvestide":
                    festival = SeasonalFestival.Highharvestide;
                    break;
                case "Feast Of The Moon":
                    festival = SeasonalFestival.FeastOfTheMoon;
                    break;
                case "Winter Solstice":
                    festival = SeasonalFestival.WinterSolstice;
                    break;
                default:
                    festival = SeasonalFestival.None;
                    break;
            }

            Calendar.InitCalendar((int)nudYear.Value, festival, tbCampaignName.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetDate()
        {
            Calendar.InitCalendar((int)nudDay.Value, (int)nudMonth.Value, (int)nudYear.Value, tbCampaignName.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (tbPlayerName.Text.Length < 2)
            {
                MessageBox.Show("Player name must be 3 characters or longer");
            }
            else if (nudPlayerMaxHP.Value <= 0)
            {
                MessageBox.Show("Player max HP must be higher than 0");
            }
            else
            {
                players.Add(new Player(tbPlayerName.Text, (int)nudPlayerMaxHP.Value));
                lbPlayerList.Items.Add(tbPlayerName.Text);
            }
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            if (lbPlayerList.SelectedItem != null)
            {
                players.Remove(players.Find(p => p.Name == lbPlayerList.SelectedItem.ToString()));
                lbPlayerList.Items.Remove(lbPlayerList.SelectedItem);
            }
        }
    }
}
