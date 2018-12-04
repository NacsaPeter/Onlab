using Lynn.Client.Enums;
using Lynn.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public abstract class ExerciseBaseViewModel : Observable
    {
        public void CheckAnswer(
            ContentDialog resultDialog,
            string rightAnswer,
            string userAnswer,
            ref bool isCorrect
          )
        {
            TextBlock text = new TextBlock
            {
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold
            };
            if (rightAnswer?.ToUpper() == userAnswer?.ToUpper())
            {
                isCorrect = true;
                text.Text = "A válasz helyes.";
                resultDialog.Content = text;
                resultDialog.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                isCorrect = false;
                text.Text = $"A helyes válasz: { rightAnswer }";
                text.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                resultDialog.Content = text;
                resultDialog.Background = new SolidColorBrush(Colors.Red);
            }
            resultDialog.ShowAsync();
        }
    }
}
