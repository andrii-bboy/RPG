using System;
using System.Windows.Forms;
using System.Collections.Generic;
using RPG.Entitites.Characters;
using RPG.Items;
using RPG.GameServices;

namespace RPG.Forms
{
    public partial class ShopForm : Form
    {
        private Player _player;
        private List<Item> _shopItems = new List<Item>();

        public ShopForm(Player player)
        {
            InitializeComponent();
            _player = player;
            this.Text = "General Equipment Merchant";

            GenerateStock();
            UpdateShopListBox();
        }

        private void GenerateStock()
        {
            _shopItems.Clear();

            WeaponGenerator wg = new WeaponGenerator();
            List<Weapon> weapons = wg.createMany(3, _player.getLevel());
            foreach (var w in weapons) _shopItems.Add(w);

            ArmorGenerator ag = new ArmorGenerator();
            List<Armor> armors = ag.createMany(3, _player.getLevel());
            foreach (var a in armors) _shopItems.Add(a);
        }

        private void UpdateShopListBox()
        {
            label1.Text = $"Your Gold: {_player.Gold}G";

            lstProducts.Items.Clear();
            foreach (Item item in _shopItems)
            {
                if (item == null)
                {
                    lstProducts.Items.Add("[ SOLD OUT ]");
                    continue;
                }

                if (item is Weapon w)
                {
                    lstProducts.Items.Add($"[WEAPON] {w.Name} (Atk: {w.getDamage()}) - Price: {w.getPrice()}G");
                }
                else if (item is Armor a)
                {
                    lstProducts.Items.Add($"[ARMOR] {a.Name} (Def: {a.getDefense()}) - Price: {a.getPrice()}G");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuy_Click_1(object sender, EventArgs e)
        {
            int index = lstProducts.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Select an item from the list!");
                return;
            }

            if (_shopItems[index] == null)
            {
                MessageBox.Show("This item is already sold out! You cannot buy it again.");
                return;
            }

            Item targetItem = _shopItems[index];

            if (_player.Gold >= targetItem.getPrice())
            {
                _player.spendGold(targetItem.getPrice());

                if (targetItem is Weapon w)
                {
                    _player.Weapon = w;
                }
                else if (targetItem is Armor a)
                {
                    _player.Armor = a;
                }

                _shopItems[index] = null;
                UpdateShopListBox();
                MessageBox.Show($"You successfully bought and equipped {targetItem.Name}!");
            }
            else
            {
                MessageBox.Show("Not enough gold!");
            }
        }
    }
}
