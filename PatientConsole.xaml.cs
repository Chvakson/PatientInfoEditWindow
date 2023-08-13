using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using Point = System.Windows.Point;
using String = System.String;

namespace PatientConsole
{
    /// <summary>
    /// Interaction logic for PatientConsole.xaml
    /// </summary>
    public partial class PatientConsole : Window
    {
        public bool IsClosed = true;
        private string bornDateDefaultValue;
        private bool genderOnClicked;
        private bool rhOnClicked;
        private bool bloodTypeOnClicked;
        private Brush yellowBrush = new SolidColorBrush(Color.FromRgb(255, 200, 60));
        private Brush ligthBrush = new SolidColorBrush(Color.FromRgb(255, 255, 250));
        private Brush darkBrush = new SolidColorBrush(Color.FromRgb(58, 56, 62));
        private bool bornDateFormGotFocus;
        public PatientConsole()
        {
            InitializeComponent();
            bornDateDefaultValue = BornDateForm.Child.Text;
        }



        public int? CalculateAge()
        {
            var today = DateTime.Today;
            if (DateTime.TryParse($"{BornDateForm.Child.Text}", out DateTime date))
            {
                var age = today.Year - date.Year;
                if (date > today.AddYears(-age))
                    age--;
                return age;
            }
            return null;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastNameTextBox.Text == "" || genderOnClicked == false || BedTextBox.Text == "" || (rhOnClicked && bloodTypeOnClicked == false) ||
                (BornDateForm.Child.Text != bornDateDefaultValue && CalculatedAgeTextBox.Text == "") || (bloodTypeOnClicked && rhOnClicked == false))
            {
                if (LastNameTextBox.Text == "")
                {
                    LastNameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    LastNameErrorStackPanel.Visibility = Visibility.Visible;
                }

                if (genderOnClicked == false)
                {
                    GenderBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                    GenderErrorStackPanel.Visibility = Visibility.Visible;
                }

                if (BedTextBox.Text == "")
                {
                    BedTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    BedErrorStackPanel.Visibility = Visibility.Visible;
                }

                if (rhOnClicked && bloodTypeOnClicked == false)
                {
                    BloodTypeBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                    BloodTypeErrorStackPanel.Visibility = Visibility.Visible;
                }

                if (BornDateForm.Child.Text != bornDateDefaultValue && CalculatedAgeTextBox.Text == "")
                {
                    BornDateBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                    BornDateErrorStackPanel.Visibility = Visibility.Visible;
                }

                if (bloodTypeOnClicked && rhOnClicked == false)
                {
                    RhBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                    RhErrorStackPanel.Visibility = Visibility.Visible;
                }
            }

            else
            {
                MessageBox.Show("Все ОК!");
            }
        }

        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LastNameTextBox.Text != "")
            {
                LastNameTextBox.Text = LastNameTextBox.Text.Trim();
                LastNameTextBox.BorderBrush = null;
                LastNameErrorStackPanel.Visibility = Visibility.Hidden;
            }
        }

        private void MButton_Click(object sender, RoutedEventArgs e)
        {
            MButton.Background = yellowBrush;
            MButton.Foreground = darkBrush;
            WButton.Background = darkBrush;
            WButton.Foreground = ligthBrush;

            genderOnClicked = true;
            GenderBorder.BorderBrush = null;
            GenderErrorStackPanel.Visibility = Visibility.Hidden;
        }

        private void WButton_Click(object sender, RoutedEventArgs e)
        {
            WButton.Background = yellowBrush;
            WButton.Foreground = darkBrush;
            MButton.Background = darkBrush;
            MButton.Foreground = ligthBrush;

            genderOnClicked = true;
            GenderBorder.BorderBrush = null;
            GenderErrorStackPanel.Visibility = Visibility.Hidden;

        }

        private void Type1Button_Click(object sender, RoutedEventArgs e)
        {
            Type1Button.Background = yellowBrush;
            Type1Button.Foreground = darkBrush;

            Type2Button.Background = darkBrush;
            Type2Button.Foreground = ligthBrush;

            Type3Button.Background = darkBrush;
            Type3Button.Foreground = ligthBrush;

            Type4Button.Background = darkBrush;
            Type4Button.Foreground = ligthBrush;

            bloodTypeOnClicked = true;
            BloodTypeErrorStackPanel.Visibility = Visibility.Hidden;
            BloodTypeBorder.BorderBrush = null;
        }

        private void Type2Button_Click(object sender, RoutedEventArgs e)
        {
            Type2Button.Background = yellowBrush;
            Type2Button.Foreground = darkBrush;

            Type1Button.Background = darkBrush;
            Type1Button.Foreground = ligthBrush;

            Type3Button.Background = darkBrush;
            Type3Button.Foreground = ligthBrush;

            Type4Button.Background = darkBrush;
            Type4Button.Foreground = ligthBrush;

            bloodTypeOnClicked = true;
            BloodTypeErrorStackPanel.Visibility = Visibility.Hidden;
            BloodTypeBorder.BorderBrush = null;


        }

        private void Type3Button_Click(object sender, RoutedEventArgs e)
        {
            Type3Button.Background = yellowBrush;
            Type3Button.Foreground = darkBrush;

            Type2Button.Background = darkBrush;
            Type2Button.Foreground = ligthBrush;

            Type1Button.Background = darkBrush;
            Type1Button.Foreground = ligthBrush;

            Type4Button.Background = darkBrush;
            Type4Button.Foreground = ligthBrush;

            bloodTypeOnClicked = true;
            BloodTypeErrorStackPanel.Visibility = Visibility.Hidden;
            BloodTypeBorder.BorderBrush = null;


        }

        private void Type4Button_Click(object sender, RoutedEventArgs e)
        {
            Type4Button.Background = yellowBrush;
            Type4Button.Foreground = darkBrush;

            Type2Button.Background = darkBrush;
            Type2Button.Foreground = ligthBrush;

            Type3Button.Background = darkBrush;
            Type3Button.Foreground = ligthBrush;

            Type1Button.Background = darkBrush;
            Type1Button.Foreground = ligthBrush;

            bloodTypeOnClicked = true;
            BloodTypeErrorStackPanel.Visibility = Visibility.Hidden;
            BloodTypeBorder.BorderBrush = null;


        }

        private void plusFactorButton_Click(object sender, RoutedEventArgs e)
        {
            PlusFactorButton.Background = yellowBrush;
            PlusFactorButton.Foreground = darkBrush;

            MinusFactorButton.Background = darkBrush;
            MinusFactorButton.Foreground = ligthBrush;

            rhOnClicked = true;
            RhErrorStackPanel.Visibility = Visibility.Hidden;
            RhBorder.BorderBrush = null;
        }

        private void minusFactorButton_Click(object sender, RoutedEventArgs e)
        {
            MinusFactorButton.Background = yellowBrush;
            MinusFactorButton.Foreground = darkBrush;

            PlusFactorButton.Background = darkBrush;
            PlusFactorButton.Foreground = ligthBrush;

            rhOnClicked = true;
            RhErrorStackPanel.Visibility = Visibility.Hidden;
            RhBorder.BorderBrush = null;
        }

        private void ValidateBornDate()
        {
            if (BornDateForm.Child.Text != bornDateDefaultValue)
            {
                if (CalculateAge() is > 0 and <= 120)
                {
                    CalculatedAgeTextBox.Text = CalculateAge().ToString();
                    SuffixTextBox.Text = GetSuffix(CalculateAge());
                    BornDateBorder.BorderBrush = null;
                    BornDateErrorStackPanel.Visibility = Visibility.Hidden;
                }
                else
                {
                    CalculatedAgeTextBox.Text = "";
                    SuffixTextBox.Text = "";
                    BornDateBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                    BornDateErrorStackPanel.Visibility = Visibility.Visible;
                }
            }

            else
            {
                BornDateBorder.BorderBrush = null;
                BornDateErrorStackPanel.Visibility = Visibility.Hidden;
            }
        }

        private void BornDateForm_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateBornDate();
            bornDateFormGotFocus = false;
        }

        public static string GetSuffix(int? age)
            => (age % 100) switch
            {
                11 => "лет",
                12 => "лет",
                13 => "лет",
                _ => (age % 10) switch
                {
                    1 => "год",
                    2 => "года",
                    3 => "года",
                    4 => "года",
                    _ => "лет"
                }
            };

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BornDateForm_GotFocus(object sender, RoutedEventArgs e)
        {
            BornDateBorder.BorderBrush = null;
            BornDateErrorStackPanel.Visibility = Visibility.Hidden;
            BornDateBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(86, 157, 229));
            bornDateFormGotFocus = true;

        }

        private void LastNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            LastNameTextBox.BorderBrush = null;
            LastNameErrorStackPanel.Visibility = Visibility.Hidden;
        }

        private void BedTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BedTextBox.BorderBrush = null;
            BedErrorStackPanel.Visibility = Visibility.Hidden;
        }

        private void BedTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (BedTextBox.Text != "")
            {
                BedTextBox.Text = BedTextBox.Text.Trim();
                BedTextBox.BorderBrush = null;
                BedErrorStackPanel.Visibility = Visibility.Hidden;
            }
        }

        private void WeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            WeightTextBox.Text = WeightTextBox.Text.Trim();
            var result = Int32.TryParse(WeightTextBox.Text, out var number);
            if (WeightTextBox.Text != "")
            {
                if (WeightTextBox.Text != "" && result)
                {
                    if (Convert.ToInt32(WeightTextBox.Text) > 0 && Convert.ToInt32(WeightTextBox.Text) <= 700)
                    {
                        WeightErrorStackPanel.Visibility = Visibility.Hidden;
                        WeightTextBox.BorderBrush = null;
                    }
                    else
                    {
                        WeightErrorStackPanel.Visibility = Visibility.Visible;
                        WeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    WeightErrorStackPanel.Visibility = Visibility.Visible;
                    WeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void HeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            HeightTextBox.Text = HeightTextBox.Text.Trim();
            var result = Int32.TryParse(HeightTextBox.Text, out var number);
            if (HeightTextBox.Text != "")
            {
                if (HeightTextBox.Text != "" && result)
                {
                    if (Convert.ToInt32(HeightTextBox.Text) > 0 && Convert.ToInt32(HeightTextBox.Text) <= 270)
                    {
                        HeightErrorStackPanel.Visibility = Visibility.Hidden;
                        HeightTextBox.BorderBrush = null;
                    }
                    else
                    {
                        HeightErrorStackPanel.Visibility = Visibility.Visible;
                        HeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    HeightErrorStackPanel.Visibility = Visibility.Visible;
                    HeightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void WeightTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            WeightErrorStackPanel.Visibility = Visibility.Hidden;
            WeightTextBox.BorderBrush = null;
        }

        private void HeightTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HeightErrorStackPanel.Visibility = Visibility.Hidden;
            HeightTextBox.BorderBrush = null;
        }

        private void WeightTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void HeightTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!bornDateFormGotFocus)
                ValidateBornDate();
        }

        private void BornDateBorder_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!bornDateFormGotFocus)
                BornDateBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(126, 180, 234));
        }


        private void CloseButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            IsClosed = true;
            this.Close();

        }
    }
}
