using Emgu.CV;
using Emgu.CV.Structure;

namespace CascadeTest
{
    internal class Program
    {
        private const string Input = "cells.jpeg";
        private static readonly CascadeClassifier _cascadeClassifier = new CascadeClassifier("bloodcellhaar.xml");

        private static void Main()
        {
            var image = new Image<Bgr, byte>(Input);
            var gray = image.Convert<Gray, byte>();
            var cells = _cascadeClassifier.DetectMultiScale(gray);

            foreach (var cell in cells)
            {
                image.Draw(cell, new Bgr(0, 0, 1));
            }

            CvInvoke.Imshow("Result", image);
            CvInvoke.WaitKey();
        }
    }
}