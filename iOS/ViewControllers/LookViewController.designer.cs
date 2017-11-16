// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XTranslate.iOS
{
    [Register("LookViewController")]
    partial class LookViewController
    {
        [Outlet]
        UIKit.UIImageView cameraView { get; set; }

        [Outlet]
        UIKit.UIButton lookButton { get; set; }

        [Outlet]
        UIKit.UILabel permissionNeededLabel { get; set; }

        [Outlet]
        UIKit.UIActivityIndicatorView progressIndicator { get; set; }

        [Outlet]
        UIKit.UIButton requestPermissionsButton { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (cameraView != null)
            {
                cameraView.Dispose();
                cameraView = null;
            }

            if (lookButton != null)
            {
                lookButton.Dispose();
                lookButton = null;
            }

            if (progressIndicator != null)
            {
                progressIndicator.Dispose();
                progressIndicator = null;
            }

            if (permissionNeededLabel != null)
            {
                permissionNeededLabel.Dispose();
                permissionNeededLabel = null;
            }

            if (requestPermissionsButton != null)
            {
                requestPermissionsButton.Dispose();
                requestPermissionsButton = null;
            }
        }
    }
}
