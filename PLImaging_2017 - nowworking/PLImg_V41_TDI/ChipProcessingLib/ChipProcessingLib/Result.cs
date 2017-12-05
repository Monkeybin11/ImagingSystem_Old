﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionTool;

namespace ChipProcessingLib
{
    class Result
    {
    }

    public class ImgPResult
    {
        public int ChipTotalCount { get { return ChipPassCount + ChipLowCount + ChipOverCount + ChipNOPLCount; } }
        public int ChipPassCount = 0;
        public int ChipLowCount = 0;
        public int ChipOverCount = 0;
        public int ChipNOPLCount = 0;
        public int ChipTotalNgCount { get { return ChipLowCount + ChipOverCount + ChipNOPLCount; } }

        public int AreaUpLimit;
        public int AreaDwLimit;
        public int IntenUpLimit;
        public int IntenDwLimit;

        public List<ExResult> OutData = new System.Collections.Generic.List<ExResult>();
        public List<int> SizeHist = new System.Collections.Generic.List<int>();
        public List<int> ChipIntensityHist = new System.Collections.Generic.List<int>();

        public ImgPResult(
            int areaup,
            int areadw,
            int intenup,
            int intendw )
        {
            AreaUpLimit = areaup;
            AreaDwLimit = areadw;
            IntenUpLimit = intenup;
            IntenDwLimit = intendw;

        }
    }

    public class ExResult
    {
        public int Hindex;
        public int Windex;
        public int HindexError;
        public int WindexError;
        public string OKNG;
        public double Intensity;
        public double ContourSize;
        public System.Drawing.Rectangle BoxData;
        public System.Drawing.Point PositionError;
        public ExResult(
            int hindex
            , int windex
            , int hindexError
            , int windexError
            , string passfail
            , double inten
            , double contsize
            , Rectangle boxData = new Rectangle() )
        {
            Hindex = hindex;
            Windex = windex;
            HindexError = hindexError;
            WindexError = windexError;
            OKNG = passfail;
            Intensity = inten;
            ContourSize = contsize;
            BoxData = boxData;
        }
    }
}
