using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Blob;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp.Util;
using OpenCvSharp.Extensions;

namespace MrRobot
{
    class videoRecognition : Modules
    {
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        static bool faceSave = false;
        public void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            //CamerasForm frm1 = new CamerasForm();
            //frm1.Show();
            var window = new Window("capture");
            
            capture = new VideoCapture();
            capture.Fps = 30.0f;
            int sleepTime = (int)(1000 / capture.Fps);
            capture.FrameHeight = 720;
            capture.FrameWidth = 1280;
            capture.Open(0);
            capture.XI_Timeout = 1.0;
            if (capture.IsOpened())
            {
                while (true)
                {
                    frame = new Mat();
                    capture.Read(frame);
                    if (frame.Empty())
                    {
                        break;
                    }
                    else
                    {
                        window.ShowImage(frame);
                        if (faceSave == true)
                        {
                            frame.SaveImage("X:/myFace.jpg");
                            faceSave = false;
                            Console.WriteLine("Сохранено");
                        }
                        //Cv2.Equals(frame, frame);
                        //
                        var haarCascade = new CascadeClassifier("X:/haarcascade_frontalface_alt.xml");
                        var lbpCascade = new CascadeClassifier("X:/haarcascade_eye_tree_eyeglasses.xml");

                        // Detect faces
                        Mat img = frame;
                        Mat haarResult = DetectFace(haarCascade, img);
                        //Mat lbpResult = DetectFace(lbpCascade, img);//Не работает почему то

                        Cv2.ImShow("Faces by Haar", haarResult);
                        //Cv2.ImShow("Faces by LBP", lbpResult);//Не рабтает почему то
                        //Cv2.WaitKey(0);
                        //Cv2.DestroyAllWindows();
                        //image = BitmapConverter.ToBitmap(frame);
                        //frm1.pictureBox1.Image = image;
                        //image = null;
                        Cv2.WaitKey(sleepTime);
                    }
                }
            }

        }
        public static void imgSave()
        {
            faceSave = true;
        }

        public static void start()
        {
            videoRecognition vd = new videoRecognition();
            vd.CaptureCamera();
            /*
            Mat src = new Mat("X:/lena.jpg", ImreadModes.Grayscale);
            // Mat src = Cv2.ImRead("lenna.png", ImreadModes.Grayscale);
            Mat dst = new Mat();

            Cv2.Canny(src, dst, 50, 200);
            using (new Window("src image", src))
            using (new Window("dst image", dst))
            {
                Cv2.WaitKey();
            }
            ////////////////////////////////////////////////////
            Mat src = new Mat("X:/lena.jpg", ImreadModes.Color);

            Mat normconv = new Mat(), recursFildered = new Mat();
            Cv2.EdgePreservingFilter(src, normconv, EdgePreservingMethods.NormconvFilter);
            Cv2.EdgePreservingFilter(src, recursFildered, EdgePreservingMethods.RecursFilter);

            Mat detailEnhance = new Mat();
            Cv2.DetailEnhance(src, detailEnhance);

            Mat pencil1 = new Mat(), pencil2 = new Mat();
            Cv2.PencilSketch(src, pencil1, pencil2);

            Mat stylized = new Mat();
            Cv2.Stylization(src, stylized);

            using (new Window("src", src))
            using (new Window("edgePreservingFilter - NormconvFilter", normconv))
            using (new Window("edgePreservingFilter - RecursFilter", recursFildered))
            using (new Window("detailEnhance", detailEnhance))
            using (new Window("pencilSketch grayscale", pencil1))
            using (new Window("pencilSketch color", pencil2))
            using (new Window("stylized", stylized))
            {
                Cv2.WaitKey();
            }*/
            // Load the cascades
            
            
        }
        private static Mat DetectFace(CascadeClassifier cascade, Mat photo)
        {
            Mat result;
            //Mat src = photo;
            using (var src = photo)
            using (var gray = new Mat())
            {
                result = src.Clone();
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

                // Detect faces
                Rect[] faces = cascade.DetectMultiScale(
                    gray, 1.08, 2, HaarDetectionType.ScaleImage, new OpenCvSharp.Size(30, 30));

                // Render all detected faces
                foreach (Rect face in faces)
                {
                    var center = new OpenCvSharp.Point
                    {
                        X = (int)(face.X + face.Width * 0.5),
                        Y = (int)(face.Y + face.Height * 0.5)
                    };
                    var axes = new OpenCvSharp.Size
                    {
                        Width = (int)(face.Width * 0.5),
                        Height = (int)(face.Height * 0.5)
                    };
                    Cv2.Ellipse(result, center, axes, 0, 0, 360, new Scalar(255, 0, 255), 4);
                }
            
            return result;
        }
        }
    }
}
