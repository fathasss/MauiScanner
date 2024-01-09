using ZXing;

namespace MauiScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            cameraView.BarCodeOptions = new()
            {
                PossibleFormats = 
                {
                    ZXing.BarcodeFormat.QR_CODE,
                    ZXing.BarcodeFormat.CODE_39
                }
            };
        }

        private void cameraView_CamerasLoaded(object sender, EventArgs e)
        {
            if (cameraView.Cameras.Count > 0)
            {
                cameraView.Camera = cameraView.Cameras.First();
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await cameraView.StopCameraAsync();
                    await cameraView.StopCameraAsync();
                });

            }
        }

        private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                barcodeResult.Text = $"{args.Result[0].BarcodeFormat} : {args.Result[0].Text}";
            });
        }
    }

}
