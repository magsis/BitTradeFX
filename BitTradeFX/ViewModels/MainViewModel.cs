using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTradeFX.ViewModels {
    using System.ComponentModel;
    using BitTradeFX.Models;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged member
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged member

        protected void RaisePropertyChanged(string propertyName) {
            var h = PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

        private string text;
        public string Text {
            get { return text; }
            set {
                if (text != value) {
                    text = value;
                    Result = text.ToUpper();
                    RaisePropertyChanged("Text");
                }
            }
        }

        private string result;
        public string Result {
            get { return result; }
            set {
                if (result != value) {
                    result = value;
                    RaisePropertyChanged("Result");
                }
            }
        }

        private DelegateCommand clearCommand;
        public DelegateCommand ClearCommand {
            get {
                if (clearCommand == null)
                    clearCommand = new DelegateCommand(
                        _ => Text = string.Empty,
                        _ => !string.IsNullOrEmpty(Text)
                    );
                return clearCommand;
            }
        }
    }
}
