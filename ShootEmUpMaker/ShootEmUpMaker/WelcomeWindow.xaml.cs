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
using System.IO;

namespace ShootEmUpMaker
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();

            try
            {
                int i = 1;
                string Docpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string finalpath = Docpath + "\\" + "ShootEmUpMaker";
                string[] filePaths = Directory.GetFiles(@finalpath, "*.xml");
                foreach (string x in filePaths)
                {
                    var border = new Border();
                    var text = new TextBlock();
                    text.HorizontalAlignment = HorizontalAlignment.Center;
                    text.VerticalAlignment = VerticalAlignment.Center;
                    text.FontSize = 36;
                    text.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
                    //text.FontWeight = FontWeight;
                    text.Text = x;
                    //<TextBlock x:Name="CreateButton" Text="+" HorizontalAlignment="Center"
                    //VerticalAlignment="Center" ToolTip="Click here to create a new game" FontSize="36" Foreground="White" FontWeight="Thin" />

                    border.Child = text;
                    border.Name = "Game"  + i.ToString();
                    border.Width = 140;
                    border.Height = 260;
                    border.Background = new SolidColorBrush(Color.FromRgb(0, 111, 111));
                    border.Margin = new Thickness(5,5,5,5);

                    this.Games.Children.Add(border);
                    i++;
                    MessageBox.Show(x);
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            

           

           // var toto = new Label();
            //toto.Content = "toto";
            //this.Games.Children.Add(toto);
        }    
    }
}
