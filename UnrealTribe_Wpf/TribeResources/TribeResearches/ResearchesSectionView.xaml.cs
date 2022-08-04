using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ResearchesSectionView.xaml
    /// </summary>
    public partial class ResearchesSectionView : Window
    {
        public ResearchesSectionView()
        {
            InitializeComponent();
            ViewUtils.SetDefaultFont(this);

            this.CreateResearcheButtons();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void CreateResearcheButtons()
        {
            int buttonsCount = 8;
            int columnsCount = 2;
            int rowsCount = buttonsCount / columnsCount;
            int baseHeigth = 100;
            int baseWidth = 200;
            int grap = 50;

            List<Button> buttons = new List<Button>(buttonsCount);

            for (int col = 0; col < columnsCount; col++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    buttons.Add(
                        new Button()
                        {
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top,
                            Height = baseHeigth,
                            Width = baseWidth,
                            Margin = new Thickness((baseWidth + grap) * col, (baseHeigth + grap) * row, 0, 0),
                            Content = "My number is " + (col + row)
                        });
                }
            }

            if (this.Content is Panel panel)
            {
                foreach (var button in buttons)
                {
                    panel.Children.Add(button);
                }
            }
        }
    }
}
