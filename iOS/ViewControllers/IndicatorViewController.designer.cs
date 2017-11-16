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
	[Register ("IndicatorViewController")]
	partial class IndicatorViewController
	{
		[Outlet]
		UIKit.UIImageView image { get; set; }

		[Outlet]
		UIKit.UILabel instructionsLabel { get; set; }

		[Outlet]
		UIKit.UILabel ocrWordLabel { get; set; }

		[Outlet]
		UIKit.UIButton translateButton { get; set; }

		[Outlet]
		UIKit.UIActivityIndicatorView translateProgressIndicator { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (image != null) {
				image.Dispose ();
				image = null;
			}

			if (instructionsLabel != null) {
				instructionsLabel.Dispose ();
				instructionsLabel = null;
			}

			if (translateButton != null) {
				translateButton.Dispose ();
				translateButton = null;
			}

			if (ocrWordLabel != null) {
				ocrWordLabel.Dispose ();
				ocrWordLabel = null;
			}

			if (translateProgressIndicator != null) {
				translateProgressIndicator.Dispose ();
				translateProgressIndicator = null;
			}
		}
	}
}
