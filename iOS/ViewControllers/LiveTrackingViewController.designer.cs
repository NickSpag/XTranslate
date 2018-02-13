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
	[Register ("LiveTrackingViewController")]
	partial class LiveTrackingViewController
	{
		[Outlet]
		UIKit.UIImageView cameraView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (cameraView != null) {
				cameraView.Dispose ();
				cameraView = null;
			}
		}
	}
}
