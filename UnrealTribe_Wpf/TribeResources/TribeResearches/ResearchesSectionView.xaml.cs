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
        }
    }
}
