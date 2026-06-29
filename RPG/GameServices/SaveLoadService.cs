using RPG.Entitites.Characters;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace RPG.GameServices
{
    public class SaveLoadService
    {
        private string folderPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Saves"));

        private static readonly JsonSerializerOptions option = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        public void save(Player player)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, "user.json");
                string json = JsonSerializer.Serialize(player, option);
                File.WriteAllText(filePath, json);
                MessageBox.Show("Game saved successfully!", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving game: " + ex.Message);
            }
        }

        public Player loadViaDialog()
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = folderPath;
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                openFileDialog.Title = "Select your save file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    return JsonSerializer.Deserialize<Player>(json, option);
                }
            }
            return null;
        }

        public void deleteViaDialog()
        {
            if (!Directory.Exists(folderPath)) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = folderPath;
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                openFileDialog.Title = "Select save file to DELETE";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this save?", "Delete Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(openFileDialog.FileName);
                        MessageBox.Show("Save file deleted!", "Deleted");
                    }
                }
            }
        }
    }
}
