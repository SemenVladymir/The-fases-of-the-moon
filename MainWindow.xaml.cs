using HomeWork_3_WPF.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace HomeWork_3_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;
            MoonFases moonFases = new MoonFases(selectedDate??DateTime.Now);
            ShowMoonFases(moonFases);
        }

        public void ShowMoonFases(MoonFases moonFase)
        {
            var eff = new DropShadowEffect();
            ThicknessAnimation EarthAnimation = new ThicknessAnimation();
            EarthAnimation.Duration = TimeSpan.FromMilliseconds(800);
            EarthAnimation.FillBehavior = FillBehavior.HoldEnd;

            ThicknessAnimation MoonAnimation = new ThicknessAnimation();
            MoonAnimation.Duration = TimeSpan.FromMilliseconds(800);
            MoonAnimation.FillBehavior = FillBehavior.HoldEnd;

            if (moonFase.MoonDay < 16)
            {
                eff.Direction = 0;
                eff.Opacity = 0.9;
                eff.BlurRadius = 15;
                Earth_Shadow.Direction = eff.Direction;
                EarthAnimation.To = new Thickness(-700 + (500 * (moonFase.MoonDay -1) / 14), -230, 0, 0);
                MoonAnimation.To = new Thickness(-700 + (700 * (moonFase.MoonDay-1) / 14), -230, 0, 0);
            }
            else
            {
                eff.Direction = 180;
                eff.Opacity = 0.9;
                eff.BlurRadius = 15;
                Earth_Shadow.Direction = eff.Direction;
                EarthAnimation.To = new Thickness(200 + (500 * (moonFase.MoonDay - 15) / 15), -230, 0, 0);
                MoonAnimation.To = new Thickness(700 * (moonFase.MoonDay - 15) / 15, -230, 0, 0);
            }
            Fase.Text = moonFase.MoonFase;
            Day.Text = moonFase.MoonDay.ToString();

            Storyboard.SetTarget(EarthAnimation, Earth);
            Storyboard.SetTargetProperty(EarthAnimation, new PropertyPath(MarginProperty));
            Storyboard EarthStoryboard = new Storyboard();
            EarthStoryboard.Children.Add(EarthAnimation);
            EarthStoryboard.Begin();

            Storyboard.SetTarget(MoonAnimation, Moon);
            Storyboard.SetTargetProperty(MoonAnimation, new PropertyPath(MarginProperty));
            Storyboard MoonStoryboard = new Storyboard();
            MoonStoryboard.Children.Add(MoonAnimation);
            MoonStoryboard.Begin();
        }
    }
}
