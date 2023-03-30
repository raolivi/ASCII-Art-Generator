using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFY_Project
{
    internal class BitmapASCII
    {

        public string Asciitize(Bitmap newPic, int kernelWidth, int kernelHeight) 
        {
            //Creates string for ASCii characters to go into and a color list
            string AsciiString = "";
            List<Color> colors = new List<Color>();

            //Determines if kernal is above or equal to 1
            if (kernelHeight >= 1 && kernelWidth >= 1)
            {
                //Loops through pixel columns and rows
                for (int j = 0; j < newPic.Height; j += kernelHeight)
                {
                    for (int k = 0; k < newPic.Width; k+= kernelWidth)
                    {
                        //Loops through kernal columns and rows
                        for (int kernalY = 0; kernalY < kernelHeight; kernalY++)
                        {
                            for (int kernalX = 0; kernalX < kernelWidth; kernalX++) 
                            {
                                //Gets pixel color and adds to list
                                Color colCurrent = newPic.GetPixel(k, j);
                                colors.Add(colCurrent);

                                //Gets pixel color, finds the associated ascii character and adds to string
                                AsciiString += GrayToString(AveragePixel(newPic.GetPixel(k, j)));
                            }
                        }
                        //Converts to grayscale and clears list
                        double grayscale = AverageColor(colors);
                        colors.Clear();
                        
                    }
                    AsciiString += "\n";
                }
            }
            //Returns the string
            return AsciiString;
        }

        public double AveragePixel(int Red, int Green, int Blue)
        {
            //Calculates average pixel and returns value
            double grayVal = (Red + Green + Blue) / 3;

            return grayVal;
        }

        public double AveragePixel(Color colCurrent)
        {
            //Returns normalized value of grey value after being calculated from the RGB values
            double grayVal = (colCurrent.R + colCurrent.G + colCurrent.B) / 3;

            return grayVal;
        }

        public double AverageColor(List<Color> colors)
        {
            //Creates variables for red, green, and blue
            double r = 0;
            double g = 0;
            double b = 0;

            double total = 0;

            //Makes each double equal to their color structure
            foreach (Color c in colors)
            {
                r += c.R;
                g += c.G;
                b += c.B;
            }

            //Divides the color variables by how many times those color elements are present in the list
            //The operator then assigns the floating-point result of that operation to each color variable
            r /= colors.Count;
            g /= colors.Count;
            b /= colors.Count;

            //Calculates average of the floating-points and returns a value
            total = (r + g + b) / 3;

            return total;
        }

        public string GrayToString(double grayVal)
        {
            //Accepts gray value and returns an ascii character based on the range the value falls in
            
            if (grayVal >= 0 && grayVal < 42.5)
            {
                return "@";
            }
            else if (grayVal >= 42.5 && grayVal < 85)
            {
                return "%";
            }
            else if (grayVal >= 85 && grayVal < 127.5)
            {
                return "+";
            }
            else if (grayVal >= 127.5 && grayVal < 170)
            {
                return "#";
            }
            else if (grayVal >= 170 && grayVal < 212.5)
            {
                return "-";
            }
            else
            {
                return " ";
            }
        }

        public override string ToString() 
        {
            //returns ascii string of image

            //return string;

            //clear.list;

            return "Error! Help!"; 
        }
    }
}
