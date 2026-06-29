
using System;
using System.Windows.Forms;
using RPG.Forms;

namespace RPG
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CharacterSelectionForm selectForm = new CharacterSelectionForm();
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(selectForm.SelectedPlayer));
            }
        }
    }
}
