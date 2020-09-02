using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AI
{
    public class TrainingResult
    {
        public ObservableCollection<double> History { get; set; } = new ObservableCollection<double>();
    }
}
