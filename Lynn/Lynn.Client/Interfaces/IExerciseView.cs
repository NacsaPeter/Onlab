using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.Interfaces
{
    interface IExerciseView
    {
        bool CheckIsCorrect();
        UIElement GetUIElement();
    }
}
