using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Odev2;

namespace Odev2.Views
{
    public partial class Yapilacaklar : ContentPage
    {
        private List<TaskItem> tasks;
        private string jsonFilePath;

        public Yapilacaklar()
        {
            InitializeComponent();
            jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.json");
            tasks = LoadTasks();
        }

        private List<TaskItem> LoadTasks()
        {
            if (File.Exists(jsonFilePath))
            {
                var json = File.ReadAllText(jsonFilePath);
                return JsonSerializer.Deserialize<List<TaskItem>>(json);
            }
            return new List<TaskItem>();
        }

        private void SaveTasks()
        {
            var json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(jsonFilePath, json);
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            YapilacaklarLayout.IsVisible = !YapilacaklarLayout.IsVisible;
        }

        private void KaydetButton_Clicked(object sender, EventArgs e)
        {
            if (tasks == null)
            {
                tasks = new List<TaskItem>();
            }

            var task = new TaskItem
            {
                Baslik = BaslikEntry.Text,
                Yapilacak = YapilacakEntry.Text,
                Tarih = TarihPicker.Date,
                Saat = SaatPicker.Time
            };
            tasks.Add(task);
            SaveTasks();
        }

        public class TaskItem
        {
            public string Baslik { get; set; }
            public string Yapilacak { get; set; }
            public DateTime Tarih { get; set; }
            public TimeSpan Saat { get; set; }
        }
    }
}
