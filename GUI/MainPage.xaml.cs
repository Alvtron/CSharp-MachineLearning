using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AI;
using AI.TrainingSamples;
using Library;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Random Random { get; } = new Random();
        public NeuralNetwork NeuralNetwork { get; private set; }
        public IList<char> Letters => Alphabet.All.Keys.ToList();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void TrainNetworkBtn_OnClick(object sender, RoutedEventArgs e)
        {
            await TrainNetwork();
        }

        public async Task TrainNetwork()
        {
            // CODE REMOVED
        }

        public void Guess(Character character)
        {
            var result = NeuralNetwork.Solve(character.Serialized);
            GuessOutput.Text = result.ToString();
        }

        private void Guess_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(LetterList.SelectedItem is char c)) return;

            var character = Alphabet.All[c];
            var lines = character.Data.SplitInParts(7);
            GuessLetterOutput.Text = "";
            foreach (var line in lines)
                GuessLetterOutput.Text += Environment.NewLine + line;
            Guess(character);
        }
    }
}
