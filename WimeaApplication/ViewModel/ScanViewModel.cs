using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WIA;
using WimeaApplication.Helpers;

namespace WimeaApplication.ViewModel
{
    class ScanViewModel : Observable
    {
        private BitmapSource _scannedImage;
        public BitmapSource ScannedImage
        {
            get { return _scannedImage; }
            set { _scannedImage = value; NotifyPropertyChanged("ScannedImage"); }
        }

        // Command for scanning
        private RelayCommand _scanCommand;
        public ICommand ScanCommand
        {
            get
            {
                if (_scanCommand == null)
                {
                    _scanCommand = new RelayCommand(param => this.Scan(), param => this.CanScan);
                }

                return _scanCommand;
            }
        }

        // implemented for the command pattern completeness. We don't currently
        // have any situations where we'd disable the ability to scan
        public bool CanScan
        {
            get { return true; }
        }

        // method to do the actual scanning
        public void Scan()
        {
            var scanner = new ScannerService();

            try
            {
                ImageFile file = scanner.Scan();

                if (file != null)
                {
                    var converter = new ScannerImageConverter();

                    ScannedImage = converter.ConvertScannedImage(file);
                }
                else
                {
                    ScannedImage = null;
                }

            }
            catch (ScannerException ex)
            {
                // yeah, I know. Showing UI from the VM. Shoot me now.
                MessageBox.Show(ex.Message, "Unable to Scan Image");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
