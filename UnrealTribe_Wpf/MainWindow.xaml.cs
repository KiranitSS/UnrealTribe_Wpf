using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnrealTribe.MapResources;
using UnrealTribe.TribeResources;
using UnrealTribe.Turns;
using UnrealTribe_Wpf.Calendar;
using UnrealTribe_Wpf.Utils;

namespace UnrealTribe_Wpf
{
    public partial class MainWindow : Window
    {
        private static readonly string wayBack = @"\..\..\..";

        private readonly static string backgroundImageName = "\\OldMapBackground.jpg";
        private readonly static string backgroundImageDir = Directory.GetCurrentDirectory() + wayBack + "\\Images\\Backgrounds";

        private readonly static string backgroundTrackName = "\\Track1.wav";
        private readonly static string backgroundTracksDir = Directory.GetCurrentDirectory() + wayBack + "\\Music";

        private CalendarView calendar;
        private Tribe tribe;
        private TurnsController turnsController;
        private SoundPlayer? backSoundPlayer;

        private readonly int mapHeight = 40;
        private readonly int mapWidth = 60;

        public Map? Map { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.SetDefaultView();

            this.tribe = new Tribe();

            this.calendar = new CalendarView();

            this.turnsController = TurnsController.CreateNew();

            this.InitializeAdditionalComponents();

            this.CreateSubcribtions();
        }

        private void SetDefaultView()
        {
            this.SetDefaultScreenSettings();

            ViewUtils.SetDefaultFont(this);
        }

        private void SetDefaultScreenSettings()
        {
            this.Top = 0;
            this.Left = 0;
            this.Width = ViewUtils.ScreenHeigth;
            this.Height = ViewUtils.ScreenHeigth;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CalendarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ShowCalendar();
        }

        private void CreateSubcribtions()
        {
            if (this.Map is MainMap map)
            {
                map.NearCellClicked += OnNearMapCellClick;
            }

            this.turnsController.NextTurnStarted += OnNextTurnStarted;
        }

        private void OnNextTurnStarted(object? sender, EventArgs e)
        {
            if (this.Map is MainMap map)
            {
                map.CellClicksCounter = 0;
            }
        }

        private void InitializeAdditionalComponents()
        {
            this.SetBackgroundMusicTrack();
            this.Background = new ImageBrush(ImageUtils.GetFromFile(backgroundImageDir + backgroundImageName));
            this.CreateMap(this.mapHeight, this.mapWidth);

            if (this.Map != null)
            {
                this.Map.SetCamp();
                this.Map.Tools.HideMap();
                this.Map.OpenCamp();
            }
        }

        private void SetBackgroundMusicTrack()
        {
            this.backSoundPlayer = new SoundPlayer(backgroundTracksDir + backgroundTrackName);
            this.backSoundPlayer.PlayLooping();
        }

        private void OnNearMapCellClick(object? sender, EventArgs e)
        {
            this.tribe.Inventory.View.OnMapCellClicked(sender, e);
        }

        private void ShowCalendar()
        {
            if (this.calendar != null)
            {
                this.calendar.Show();
                this.calendar.Activate();
            }
        }

        private void ShowTribeInventory()
        {
            if (this.tribe.Inventory != null)
            {
                this.tribe.Inventory.View.Show();
                this.tribe.Inventory.View.Activate();
            }
        }

        private void CreateMap(int height, int width)
        {
            this.Map = new MainMap(height, width)
            {
                RiversCount = 20,
                MaxRiversLength = 20,
                BerryBushesCount = 25
            };

            this.Map.FillMap();

            if (this.Content is Panel panel)
            {
                foreach (var cell in Map.Cells)
                {
                    panel.Children.Add(cell);
                }
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.CloseApp();
        }

        private void CloseApp()
        {
            var result = MessageBox.Show("Are you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void NextTurnBtn_Click(object sender, EventArgs e)
        {
            this.turnsController.StartNextTurn();
        }

        private void ResearchesBtn_Click(object sender, EventArgs e)
        {
            this.ShowResearches();
        }

        private void ShowResearches()
        {
            if (this.tribe.Reserches.View != null)
            {
                this.tribe.Reserches.View.Show();
                this.tribe.Reserches.View.Activate();
            }
        }

        private void InventoryBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ShowTribeInventory();
        }

        private void TribalInfoBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartMusicBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.backSoundPlayer != null)
            {
                this.backSoundPlayer.Play();
                this.StopMusicBtn.IsEnabled = true;
                this.StartMusicBtn.IsEnabled = false;
            }
        }

        private void StopMusicBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.backSoundPlayer != null)
            {
                this.backSoundPlayer.Stop();
                this.StopMusicBtn.IsEnabled = false;
                this.StartMusicBtn.IsEnabled = true;
            }
        }
    }
}
