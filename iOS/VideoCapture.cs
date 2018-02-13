using System;
using System.Linq;
using AVFoundation;
using CoreFoundation;
using CoreVideo;
using Foundation;
namespace XTranslate.iOS
{
    public class VideoCapture : NSObject
    {
        /// <summary>
        /// The camera
        /// </summary>
        private AVCaptureDevice captureDevice;

        /// <summary>
        /// Perform the capture and image-processing pipeline on a background queue (note that 
        /// this is different than the Vision request
        /// </summary>
        DispatchQueue queue = new DispatchQueue("videoQueue");

        /// <summary>
        /// Used by `AVCaptureVideoPreviewLayer` in `ViewController`
        /// </summary>
        /// <value>The session.</value>
        public AVCaptureSession Session { get; }

        AVCaptureVideoDataOutput videoOutput = new AVCaptureVideoDataOutput();

        public IAVCaptureVideoDataOutputSampleBufferDelegate Delegate { get; }

        public VideoCapture(IAVCaptureVideoDataOutputSampleBufferDelegate delegateObject)
        {
            Delegate = delegateObject;
            Session = new AVCaptureSession();
            SetupCamera();
        }

        /// <summary>
        /// Typical video-processing code. More advanced would allow user selection of camera, resolution, etc.
        /// </summary>
        private void SetupCamera()
        {
            var deviceDiscovery = AVCaptureDeviceDiscoverySession.Create(
                new AVCaptureDeviceType[] { AVCaptureDeviceType.BuiltInWideAngleCamera }, AVMediaType.Video, AVCaptureDevicePosition.Back);

            var device = deviceDiscovery.Devices.Last();
            if (device != null)
            {
                captureDevice = device;
                BeginSession();
            }
        }

        private void BeginSession()
        {
            try
            {
                var settings = new CVPixelBufferAttributes
                {
                    PixelFormatType = CVPixelFormatType.CV32BGRA
                };
                videoOutput.WeakVideoSettings = settings.Dictionary;
                videoOutput.AlwaysDiscardsLateVideoFrames = true;
                videoOutput.SetSampleBufferDelegateQueue(Delegate, queue);

                Session.SessionPreset = AVCaptureSession.Preset1920x1080;
                Session.AddOutput(videoOutput);

                var input = new AVCaptureDeviceInput(captureDevice, out var err);
                if (err != null)
                {
                    Console.Error.WriteLine("AVCapture error: " + err);
                }
                Session.AddInput(input);

                Session.StartRunning();
                Console.WriteLine("started AV capture session");
            }
            catch
            {
                Console.Error.WriteLine("error connecting to the capture device");
            }
        }

    }
}
