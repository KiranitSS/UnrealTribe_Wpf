using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UnrealTribe;
using UnrealTribe_Wpf.Utils;
using UnrealTribe_Wpf.Extensions;
using UnrealTribe.Controllers.Turns;

namespace UnrealTribe_Wpf.Calendar
{
    public partial class CalendarView : Window
    {
        private List<Label> months;
        private int currentMonthIndex = 0;
        private readonly static string imagesPath = @"\..\..\..\Images";
        private readonly static string calendarImagesPath = Directory.GetCurrentDirectory() + imagesPath + @"\Calendar\";
        private readonly static string firstMonth = "September";

        public Brush OtherMonthsColor { get; set; } = Brushes.White;
        public Brush CurrentMonthColor { get; set; } = Brushes.Aquamarine;


        private readonly static string[] monthsNames = new string[]
        {
            "September",
            "October",
            "November",
            "December",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August"
        };

        private readonly TurnsController turnsController;

        public CalendarView()
        {
            this.InitializeComponent();

            ViewUtils.SetDefaultFont(this);

            this.months = this.GetMonths();

            this.SetBaseMonthsSettings();

            this.turnsController = TurnsController.CreateNew();

            this.turnsController.NextTurnStarted += OnNextTurnStarted;
        }

        private void OnNextTurnStarted(object? sender, EventArgs e)
        {
            this.SelectNextMonth(this.OtherMonthsColor, this.CurrentMonthColor);

            this.SetBackgroundBySeason(this.currentMonthIndex);
        }

        private List<Label> GetMonths()
        {
            List<Label> labels;

            labels = GetLabels();

            if (labels is null || labels.Count == 0)
            {
                MessageBox.Show("Couldn't find months to create a calendar");
                labels = new List<Label>();
            }

            List<Label> months = new List<Label>();

            foreach (var month in monthsNames)
            {
                months.Add(labels.Single(m => m.Content.Equals(month)));
            }

            return months;
        }

        private List<Label> GetLabels()
        {
            List<Label> labels;
            if (this.Content is Panel panel)
            {
                labels = panel.GetControls<Label>().ToList();
            }
            else
            {
                labels = new List<Label>();
            }

            return labels;
        }

        private void SetBaseMonthsSettings()
        {
            this.SetMonthsColor(this.OtherMonthsColor, this.CurrentMonthColor);
            this.SetBackgroundBySeason(this.currentMonthIndex);
        }

        private void SetMonthsColor(Brush otherMonthsColor, Brush currentMonthColor)
        {
            foreach (var month in this.months)
            {
                if (month.Content is string content)
                {
                    if (content.Equals(firstMonth, StringComparison.OrdinalIgnoreCase))
                    {
                        month.Background = currentMonthColor;
                    }
                    else
                    {
                        month.Background = otherMonthsColor;
                    }
                }

            }
        }

        private void SetBackgroundBySeason(int monthIndex)
        {
            if (monthIndex >= (int)Seasons.Autumn && monthIndex < (int)Seasons.Winter)
            {
                this.Background = new ImageBrush(ImageUtils.GetFromFile(calendarImagesPath + "AutumnCalendar.jpg"));
                return;
            }

            if (monthIndex >= (int)Seasons.Winter && monthIndex < (int)Seasons.Spring)
            {
                this.Background = new ImageBrush(ImageUtils.GetFromFile(calendarImagesPath + "WinterCalendar.jpg"));
                return;
            }

            if (monthIndex >= (int)Seasons.Spring && monthIndex < (int)Seasons.Summer)
            {
                this.Background = new ImageBrush(ImageUtils.GetFromFile(calendarImagesPath + "SpringCalendar.jpg"));
                return;
            }

            if (monthIndex >= (int)Seasons.Summer)
            {
                this.Background = new ImageBrush(ImageUtils.GetFromFile(calendarImagesPath + "SummerCalendar.jpg"));
            }
        }

        private void SelectNextMonth(Brush otherMonthsColor, Brush currentMonthColor)
        {
            this.months[currentMonthIndex].Background = otherMonthsColor;

            if (++currentMonthIndex > this.months.Count - 1)
            {
                currentMonthIndex = 0;
            }

            this.months[currentMonthIndex].Background = currentMonthColor;
        }

        private void NextTurnBtn_Click(object sender, RoutedEventArgs e)
        {
            this.turnsController.StartNextTurn();
        }
    }
}
