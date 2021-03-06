// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;
using AVFoundation;
using CoreVideo;
using CoreFoundation;
using System.Threading.Tasks;
using Vision;
using CoreAnimation;
using CoreGraphics;
using CoreMedia;
using ImageIO;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace XTranslate.iOS
{
    public partial class LookViewController : UIViewController, IAVCaptureVideoDataOutputSampleBufferDelegate
    {
        #region Constructor
        public LookViewController(IntPtr handle) : base(handle)
        {

        }
        #endregion

        #region Methods: Overrides
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            ConfigureUI();

            var cameraPermissionGranted = await IsCameraPermissionGranted();

            if (!cameraPermissionGranted)
                cameraPermissionGranted = await RequestCameraPermission();

            ToggleCameraPermissionGrantedVisualState(cameraPermissionGranted);
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ToggleCameraPermissionGrantedVisualState(await IsCameraPermissionGranted());
        }
        #endregion

        #region Methods: Private
        private void ConfigureUI()
        {
            progressIndicator.Hidden = true;

            lookButton.TouchUpInside += async (sender, e) =>
            {
                await LookButton_TouchUpInside();
            };
        }

        private void ToggleCameraPermissionGrantedVisualState(bool granted)
        {
            lookButton.Hidden = !granted;
            permissionNeededLabel.Hidden = granted;
            requestPermissionsButton.Hidden = granted;
        }

        private async Task<bool> IsCameraPermissionGranted()
        {
            return (await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera) == PermissionStatus.Granted);
        }

        private async Task<bool> RequestCameraPermission()
        {
            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);

            bool status = false;

            if (results.ContainsKey(Permission.Camera))
                status = (results[Permission.Camera] == PermissionStatus.Granted);

            ToggleIndicatingVisualState(status);

            return status;
        }

        private async Task LookButton_TouchUpInside()
        {
            ToggleIndicatingVisualState(true);

            MediaFile picture = null;

            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                picture = await CrossMedia.Current.TakePhotoAsync((new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                }));
            }

            if (picture != null)
                await PushToIndicatorView(picture);

            ToggleIndicatingVisualState(false);
        }

        private async Task PushToIndicatorView(MediaFile picture)
        {
            var indicatorPage = await IndicatorViewController.WithMediaFile(picture);

            if (indicatorPage != null)
                this.NavigationController.PushViewController(indicatorPage, true);
        }

        private void ToggleIndicatingVisualState(bool enabling)
        {
            lookButton.Hidden = enabling;
            progressIndicator.Hidden = !enabling;

            if (enabling)
                progressIndicator.StartAnimating();
            else
                progressIndicator.StopAnimating();
        }
        #endregion

    }
}
