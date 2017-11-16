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
    [Register("SettingsViewController")]
    partial class SettingsViewController
    {
        [Outlet]
        UIKit.UITextField languageTextField { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (languageTextField != null)
            {
                languageTextField.Dispose();
                languageTextField = null;
            }
        }
    }
}
