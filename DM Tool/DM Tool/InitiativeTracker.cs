using DM_Tool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class Player
{
	// add way to track current exp and save player to text doc
	// this way i done have to re type in all the player info

	private string name;
	private int hpMax;
	private int hpCurrent;
	public int Initiative;

	private List<Feat> feats;

	public string Name
	{
		get { return name; }
	}

	public List<Feat> Feats
	{
		get { return feats; }
	}

	public int HPMax
	{
		get { return hpMax; }
	}
	public int HPCurrent
	{
		get { return hpCurrent; }
		set { hpCurrent = value; }
	}

	public Player(string _name, int _hp)
	{
		name = _name;
		hpMax = _hp;
		Initiative = 0;
		feats = new List<Feat>();
		hpCurrent = _hp;
	}

	public Player(string _name, int _hp, int _initiative)
	{
		name = _name;
		hpMax = _hp;
		Initiative = _initiative;
		feats = new List<Feat>();
		hpCurrent = _hp;
	}

	public void SetName(string _name)
	{
		name = _name;
	}
	public void AddFeat(Feat _feat)
	{
		feats.Add(_feat);
	}

	public void SetHP(int _hp)
	{
		hpMax = _hp;
	}
}

public static class InitiativeTracker
{
	private static DMToolForm dMToolForm;

	private static List<Player> currentPlayers;
	private static List<Player> initiativeList;

	private static int InitiativeTrackerNdx;

	public static List<Player> InitiativeList
	{
		get { return initiativeList; }
		set { initiativeList = value; }
	}

	public static List<Player> Players
	{
		get { return currentPlayers; }
	}

	public static void InitializeInitiativeTracker(DMToolForm form)
	{
		dMToolForm = form;

		currentPlayers = new List<Player>();
		initiativeList = new List<Player>();
	}

	public static void EndTurn()
	{
		if (dMToolForm.lbInitTrackName.Items.Count > 0)
		{
			InitiativeTrackerNdx++;

			if (InitiativeTrackerNdx > InitiativeList.Count - 1) InitiativeTrackerNdx = 0;

			if (dMToolForm.lbInitTrackName.Items[InitiativeTrackerNdx].ToString().Contains("*"))
			{
				dMToolForm.lbInitTrackName.Items[InitiativeTrackerNdx] = dMToolForm.lbInitTrackName.Items[InitiativeTrackerNdx].ToString().Replace("*", "");
			}

			dMToolForm.lblInitTrackTurnName.Text = InitiativeList[InitiativeTrackerNdx].Name;
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnName);
			dMToolForm.lblInitTrackTurnHP.Text = "HP: " + InitiativeList[InitiativeTrackerNdx].HPCurrent;
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnHP);
		}
		else
		{
			dMToolForm.lblInitTrackTurnName.Text = "*_____*";
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnName);
			dMToolForm.lblInitTrackTurnHP.Text = "HP: --";
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnHP);
			MessageBox.Show("No Combatants");
		}
	}

	private static void InitiativetTrackCenterLable(Label lbl)
	{
		lbl.Location = new Point((int)(227 + ((627 - 227 - lbl.Width) / 2)), lbl.Location.Y);
	}

	public static void NameSelectedIndexChanged()
	{
		if (dMToolForm.lbInitTrackInit.SelectedIndex != dMToolForm.lbInitTrackName.SelectedIndex && dMToolForm.lbInitTrackName.SelectedItem != null)
		{
			dMToolForm.lbInitTrackInit.SelectedIndex = dMToolForm.lbInitTrackName.SelectedIndex;
			dMToolForm.lbInitTrackHP.SelectedIndex = dMToolForm.lbInitTrackName.SelectedIndex;

			dMToolForm.tbInitTrackSelectedCombatant.Text = dMToolForm.lbInitTrackName.SelectedItem.ToString();
			dMToolForm.nudInitTrackHPUpdate.Value = Int32.Parse(dMToolForm.lbInitTrackHP.Text);
			dMToolForm.nudInitTrackInitUpdate.Value = Int32.Parse(dMToolForm.lbInitTrackInit.Text);
		}
	}

	public static void InitiativeSelectedIndexChanged()
	{
		if (dMToolForm.lbInitTrackName.SelectedIndex != dMToolForm.lbInitTrackInit.SelectedIndex && dMToolForm.lbInitTrackInit.SelectedItem != null)
		{
			dMToolForm.lbInitTrackName.SelectedIndex = dMToolForm.lbInitTrackInit.SelectedIndex;
			dMToolForm.lbInitTrackHP.SelectedIndex = dMToolForm.lbInitTrackInit.SelectedIndex;

			dMToolForm.tbInitTrackSelectedCombatant.Text = dMToolForm.lbInitTrackName.SelectedItem.ToString();
			dMToolForm.nudInitTrackHPUpdate.Value = Int32.Parse(dMToolForm.lbInitTrackHP.Text);
			dMToolForm.nudInitTrackInitUpdate.Value = Int32.Parse(dMToolForm.lbInitTrackInit.Text);
		}
	}

	public static void HPSelectedIndexChanged()
	{
		if (dMToolForm.lbInitTrackName.SelectedIndex != dMToolForm.lbInitTrackHP.SelectedIndex && dMToolForm.lbInitTrackHP.SelectedItem != null)
		{
			dMToolForm.lbInitTrackName.SelectedIndex = dMToolForm.lbInitTrackHP.SelectedIndex;
			dMToolForm.lbInitTrackInit.SelectedIndex = dMToolForm.lbInitTrackHP.SelectedIndex;

			dMToolForm.tbInitTrackSelectedCombatant.Text = dMToolForm.lbInitTrackName.SelectedItem.ToString();
			dMToolForm.nudInitTrackHPUpdate.Value = Int32.Parse(dMToolForm.lbInitTrackHP.Text);
			dMToolForm.nudInitTrackInitUpdate.Value = Int32.Parse(dMToolForm.lbInitTrackInit.Text);
		}
	}

	public static void AddCombatant()
	{
		if (dMToolForm.tbInitTrackAddCombatant.Text.Contains("*"))
		{
			dMToolForm.tbInitTrackAddCombatant.Text = dMToolForm.tbInitTrackAddCombatant.Text.Replace("*", "");
		}

		if ((dMToolForm.lbInitTrackName.Items.Contains(dMToolForm.tbInitTrackAddCombatant.Text) && dMToolForm.nudInitTrackAddIndex.Value == 0) ||
			 dMToolForm.nudInitTrackAddIndex.Value > 0 && dMToolForm.lbInitTrackName.Items.Contains(dMToolForm.tbInitTrackAddCombatant.Text + " - " + dMToolForm.nudInitTrackAddIndex.Value))
		{
			MessageBox.Show("Combatant already in queue.", "Error");
			return;
		}

		if (dMToolForm.tbInitTrackAddCombatant.Text == string.Empty)
		{
			MessageBox.Show("Please enter Combatant Name", "Error");
			return;
		}

		if (dMToolForm.nudInitTrackAddHP.Value <= 0)
		{
			MessageBox.Show("Combatant HP must be higher than 0.", "Error");
			return;
		}
		else if (dMToolForm.nudInitTrackAddIndex.Value != 0)
		{
			Player newCombatant = new Player(dMToolForm.tbInitTrackAddCombatant.Text + " - " + dMToolForm.nudInitTrackAddIndex.Value, (int)dMToolForm.nudInitTrackAddHP.Value, (int)dMToolForm.nudInitTrackAddInit.Value);
			InitiativeList.Add(newCombatant);

			dMToolForm.lbInitTrackName.Items.Add(newCombatant.Name);
			dMToolForm.lbInitTrackInit.Items.Add(newCombatant.Initiative);
			dMToolForm.lbInitTrackHP.Items.Add(newCombatant.HPMax);

			SortInitiativeList();
		}
		else
		{
			Player newCombatant = new Player(dMToolForm.tbInitTrackAddCombatant.Text, (int)dMToolForm.nudInitTrackAddHP.Value, (int)dMToolForm.nudInitTrackAddInit.Value);
			InitiativeList.Add(newCombatant);

			dMToolForm.lbInitTrackName.Items.Add(newCombatant.Name);
			dMToolForm.lbInitTrackInit.Items.Add(newCombatant.Initiative);
			dMToolForm.lbInitTrackHP.Items.Add(newCombatant.HPMax);

			SortInitiativeList();
		}

		if (dMToolForm.nudInitTrackAddIndex.Value > 0)
		{
			dMToolForm.nudInitTrackAddIndex.Value++;
		}
	}

	public static void SortInitiativeList()
	{
		dMToolForm.lbInitTrackName.Items.Clear();
		dMToolForm.lbInitTrackInit.Items.Clear();
		dMToolForm.lbInitTrackHP.Items.Clear();

		InitiativeList = InitiativeList.OrderBy(p => -p.Initiative).ToList();

		foreach (Player player in InitiativeList)
		{
			dMToolForm.lbInitTrackName.Items.Add(player.Name);
			dMToolForm.lbInitTrackInit.Items.Add(player.Initiative);
			dMToolForm.lbInitTrackHP.Items.Add(player.HPCurrent);
		}
	}

	private static void RefreshInitiativeList()
	{
		List<int> heldActions = new List<int>();
		foreach (object thing in dMToolForm.lbInitTrackName.Items)
		{
			if (thing.ToString().Contains("*"))
			{
				heldActions.Add(dMToolForm.lbInitTrackName.Items.IndexOf(thing));
			}
		}

		dMToolForm.lbInitTrackName.Items.Clear();
		dMToolForm.lbInitTrackInit.Items.Clear();
		dMToolForm.lbInitTrackHP.Items.Clear();

		foreach (Player player in InitiativeList)
		{
			dMToolForm.lbInitTrackName.Items.Add(player.Name);
			dMToolForm.lbInitTrackInit.Items.Add(player.Initiative);
			dMToolForm.lbInitTrackHP.Items.Add(player.HPCurrent);
		}

		foreach (int thing in heldActions)
		{
			dMToolForm.lbInitTrackName.Items[thing] += "*";
		}
	}

	public static void ApplyDamageToIndex(int damage, int index)
	{
		InitiativeList.Find(p => p.Name == dMToolForm.lbInitTrackName.SelectedItem.ToString()).HPCurrent -= damage;

		dMToolForm.lbInitTrackHP.Items[index] = InitiativeList.Find(p => p.Name == dMToolForm.lbInitTrackName.SelectedItem.ToString()).HPCurrent;

		dMToolForm.nudInitTrackDamageApplyer.Value = 0;
	}

	public static void RemoveIndexFromInitiative(int index)
	{
		InitiativeList.Remove(InitiativeList.Find(p => p.Name == dMToolForm.lbInitTrackName.SelectedItem.ToString()));

		dMToolForm.lbInitTrackName.Items.RemoveAt(index);
		dMToolForm.lbInitTrackInit.Items.RemoveAt(index);
		dMToolForm.lbInitTrackHP.Items.RemoveAt(index);
	}

	public static bool StartInitiative()
	{
		InitiativeTrackerNdx = 0;

		dMToolForm.tbInitTrackAddCombatant.Text = string.Empty;
		dMToolForm.nudInitTrackAddInit.Value = 0;
		dMToolForm.nudInitTrackAddHP.Value = 0;
		dMToolForm.nudInitTrackAddIndex.Value = 0;

		if (dMToolForm.lbInitTrackName.Items.Count > 0)
		{
			dMToolForm.lblInitTrackTurnName.Text = InitiativeList[InitiativeTrackerNdx].Name;
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnName);
			dMToolForm.lblInitTrackTurnHP.Text = "HP: " + InitiativeList[InitiativeTrackerNdx].HPCurrent;
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnHP);

			return true;
		}
		else
		{
			dMToolForm.lblInitTrackTurnName.Text = "*_____*";
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnName);
			dMToolForm.lblInitTrackTurnHP.Text = "HP: --";
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnHP);
			MessageBox.Show("No Combatants in queue.", "Error");

			return false;
		}
	}

	public static void EndInitiative()
	{
		dMToolForm.lblInitTrackTurnName.Text = "*_____*";
		InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnName);
		dMToolForm.lblInitTrackTurnHP.Text = "HP: --";
		InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnHP);
		InitiativeTrackerNdx = 0;
	}

	public static void UpdateInitiativeAndHPAtIndex(int initiative, int HP, int index)
	{
		InitiativeList[index].HPCurrent = HP;
		InitiativeList[index].Initiative = initiative;

		RefreshInitiativeList();

		dMToolForm.lbInitTrackName.SelectedIndex = index;
	}

	public static void UpdateInitiativeUp(int index)
	{
		Player temp = InitiativeList[index - 1];
		InitiativeList[index - 1] = InitiativeList[index];
		InitiativeList[index] = temp;

		RefreshInitiativeList();

		dMToolForm.lbInitTrackName.SelectedIndex = index - 1;
	}

	public static void UpdateInitializeDown(int index)
	{
		Player temp = InitiativeList[index + 1];
		InitiativeList[index + 1] = InitiativeList[index];
		InitiativeList[index] = temp;

		RefreshInitiativeList();

		dMToolForm.lbInitTrackName.SelectedIndex = index + 1;
	}

	public static void HoldAction()
	{
		dMToolForm.lbInitTrackName.Items[InitiativeTrackerNdx] = dMToolForm.lbInitTrackName.Items[InitiativeTrackerNdx] + "*";

		EndTurn();
	}

	public static void UseHeldAction()
	{
		if (dMToolForm.lbInitTrackName.SelectedItem.ToString().Contains("*"))
		{
			dMToolForm.tbInitTrackSelectedCombatant.Text = string.Empty;

			int selectedNdx = dMToolForm.lbInitTrackName.SelectedIndex;

			Player temp = InitiativeList[selectedNdx];
			InitiativeList.Remove(InitiativeList[selectedNdx]);

			InitiativeTrackerNdx--;

			dMToolForm.lbInitTrackName.Items[selectedNdx] = dMToolForm.lbInitTrackName.Items[selectedNdx].ToString().Replace("*", "");

			InitiativeList.Insert(InitiativeTrackerNdx, temp);

			RefreshInitiativeList();

			dMToolForm.lblInitTrackTurnName.Text = InitiativeList[InitiativeTrackerNdx].Name;
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnName);
			dMToolForm.lblInitTrackTurnHP.Text = "HP: " + InitiativeList[InitiativeTrackerNdx].HPCurrent;
			InitiativetTrackCenterLable(dMToolForm.lblInitTrackTurnHP);
		}
	}
}

