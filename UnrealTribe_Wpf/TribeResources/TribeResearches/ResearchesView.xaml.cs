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
using UnrealTribe_Wpf.Utils;

namespace UnrealTribe_Wpf.TribeResources.TribeResearches
{
    /// <summary>
    /// Логика взаимодействия для ReasearchesView.xaml
    /// </summary>
    public partial class ResearchesView : Window
    {
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private readonly string wayBack = @"\..\..\..\";
        private readonly string targetFolder = @"\Images\Researches\";

        private ResearchesSectionView constructionResearchesView;
        private ResearchesSectionView farmingResearchesView;
        private ResearchesSectionView militaryResearchesView;

        public ResearchesView()
        {
            InitializeComponent();

            ViewUtils.SetDefaultFont(this);

            this.constructionResearchesView = new ResearchesSectionView();
            this.farmingResearchesView = new ResearchesSectionView();
            this.militaryResearchesView = new ResearchesSectionView();

            this.ConstructionResearchesImg.Source = ImageUtils.GetFromFile(this.currentDirectory + this.wayBack + this.targetFolder + "ConstructionResearches.png");
            this.FarmingResearchesImg.Source = ImageUtils.GetFromFile(this.currentDirectory + this.wayBack + this.targetFolder + "FarmingResearches.png");
            this.MilitaryResearchesImg.Source = ImageUtils.GetFromFile(this.currentDirectory + this.wayBack + this.targetFolder + "MilitaryResearches.png");
        }

        private void ResearchesView_Leave(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ConstructionResearchesShowBtn_Click(object sender, EventArgs e)
        {
            this.ShowResearchesView(constructionResearchesView);
        }

        private void FarmingResearchesShowBtn_Click(object sender, EventArgs e)
        {
            this.ShowResearchesView(farmingResearchesView);
        }

        private void MilitaryResearchesShowBtn_Click(object sender, EventArgs e)
        {
            this.ShowResearchesView(militaryResearchesView);
        }

        private void ShowResearchesView(ResearchesSectionView view)
        {
            if (view != null)
            {
                view.Show();
                view.Activate();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
