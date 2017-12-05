using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using SpeedyCoding;
using ModelLib.Data;
using ModelLib.Monad;
using Emgu.CV.Structure;
using EmguCvExtension;
using static EmguCvExtension.Processing;
using static EmguCvExtension.Function;
using static EmguCvExtension.WPF;
using Emgu.CV.Util;
using System.Drawing;


namespace ChipProcessingLib
{
    public partial class ProcessingCore
    {
        #region 
        public event Action<Image<Bgr,byte>> evtTrsIdxImage;

        #endregion

        #region Functions
        Func<double,double,bool> InBox;
        Func<Rectangle,double> SumInsideBox;
        public Func<int, int, double> SumAreaPoint;
        ImgPResult PResult;
        int LineThickness = 2;

        Image<Bgr,byte> ProcedImg;
        #endregion


        public ProcessingCore()
        {
    
        }

        public void StartEndSet()
        { }

        public void ProcRun2( Image<Gray, byte> img, Func<Image<Gray, byte>, Image<Gray, byte>> fun, IConfig config )
        {
            evtTrsIdxImage( null );
        }

        public void ProcRun( Image<Gray, byte> img, Func<Image<Gray, byte>, Image<Gray, byte>> fun, IConfig config )
        {
            img = fun( img );

            Image < Bgr,byte> resImg = img.Convert<Bgr, byte>();

            SumInsideBox = FnSumInsideBox( img );
            SumAreaPoint = FnSumAreaPoint( config.ChipHSize, config.ChipWSize, img );

            var findContour = FnFindContour(config.AreaUpLimt , config.AreaDwLimt);
            var sortContour = FnSortcontours();
            var applyBox = FnApplyBox( config.AreaUpLimt , config.AreaDwLimt );
            var indexingImage = MatWhitePattern( config.ChipHNum, config.ChipWNum , 3);

            PResult = new ImgPResult(
                       config.AreaUpLimt,
                       config.AreaDwLimt,
                       config.ThrsUpLimt,
                       config.ThrsDwLimt );

            var contours = fun(img).Map( x => findContour(x) )
                                   .Map( x => sortContour(x) );
            var boxlist = applyBox( contours );

            var estedChipP = VisionTool.ChipUtil.FnEstChipPos_4Point(
                new double[] { config.TLY , config.TLX},
                new double[] { config.TRY , config.TRX},
                new double[] { config.BLY , config.TLX},
                new double[] { config.BRY , config.BRX})
                ( config.ChipHNum ,
                  config.ChipWNum)
                 .Act( est => DrawCenterPoint(resImg , est) )
                 .ActLoopOnChipPos( boxlist
                                   , CheckOkNg_SizeInInten(
                                                            indexingImage
                                                            , contours
                                                            , resImg));

            PResult.OutData
                 .Act( CheckLowOver(
                        estedChipP
                        , indexingImage
                        , resImg
                        , LineThickness
                        , config ) );

            DrawCenterPoint( resImg, estedChipP );
            UpdateResult( PResult )( indexingImage, resImg );
        }


        public void Create_Inbox( Rectangle box, int margin )
        {
            InBox = FnInBox( box, margin );
        }

        Action<int, int, double, double, List<System.Drawing.Rectangle>> CheckOkNg_SizeInInten(
           byte[,,] indexingImage
           , VectorOfVectorOfPoint contours
           , Image<Bgr, byte> color_visual_img )
        {
            return ( j, i, yps, xps, boxlist ) =>
            {
                bool isFail = true;
                for ( int k = 0; k < boxlist.Count; k++ )
                {
                    /* Check Ested Chip Pos in Contour*/
                    Create_Inbox( boxlist[k], APBoxTolerance );
                    if ( InBox( yps, xps ) )
                    {
                        PResult.OutData.Add(
                                new ExResult(
                                    j, i
                                    , (int)yps - (int)(boxlist[k].Y + boxlist[k].Height / 2)
                                    , (int)xps - (int)(boxlist[k].X + boxlist[k].Width / 2)
                                    , "OK"
                                    , SumInsideBox( boxlist[k] )
                                    , boxlist[k].Width * boxlist[k].Height
                                    , boxlist[k] ) );
                        isFail = false;
                        color_visual_img.Draw( boxlist[k], ApOkChipColor, 1 );
                        var cirp =  new CircleF();
                        cirp.Center = new System.Drawing.PointF(
                                                     (float)(boxlist[k].X + boxlist[k].Width / 2)
                                                     , (float)(boxlist[k].Y + boxlist[k].Height / 2) );

                        color_visual_img.Draw(
                            cirp
                            , ApCenteBoxColor, 1 );
                        break;
                    }
                }
                if ( isFail )
                {
                    double failboxInten = SumAreaPoint( (int)yps ,  (int)xps);
                    PResult.OutData.Add(
                            new ExResult(
                                j, i
                                , 0
                                , 0
                                , "NOPL"
                                , failboxInten
                                , 0 ) );
                    SetFailColor( indexingImage, j, i );
                }
            };
        }

        Action<List<ExResult>> CheckLowOver(
          double[,,] estedChipP,
          byte[,,] indexingImage,
          Image<Bgr, byte> targetimg,
          int thickness,
          IConfig config
          )
        {
            return new Action<List<ExResult>>( ( list ) =>
            {

                foreach ( var item in list )
                {
                    if ( item.OKNG == "OK" )
                    {
                        int xs = (int)estedChipP[ item.Hindex , item.Windex , 1] - 3;
                        int ys = (int)estedChipP[ item.Hindex , item.Windex , 0] - 3;

                        if ( item.Intensity < config.ThrsDwLimt )
                        {
                            //Console.WriteLine( item.Intensity );
                            item.OKNG = "LOW";
                            SetLowColor( indexingImage, item.Hindex, item.Windex );
                            targetimg.Draw( item.BoxData.ExpendRect( thickness + 1 ), ApLowColor, thickness );
                            //targetimg.Draw( item.BoxData.ExpendRect(-(thickness+1)) , ApLowColor , thickness);
                        }
                        else if ( item.Intensity > config.ThrsUpLimt )
                        {
                            item.OKNG = "OVER";
                            SetOverColor( indexingImage, item.Hindex, item.Windex );
                            targetimg.Draw( item.BoxData.ExpendRect( (thickness + 1) ), ApOverColor, thickness );
                        }
                    }
                }
            } );
        }

        Action<byte[,,], Image<Bgr, byte>> UpdateResult( ImgPResult processResult )
        {
            return new Action<byte[,,], Image<Bgr, byte>>(
            ( indeximg, procedimg ) =>
            {
                //IndexViewImg.Data = indeximg;
                ProcedImg = procedimg.Clone();


                processResult.ChipPassCount = (from item in processResult.OutData where item.OKNG == "OK" select item).Count();
                processResult.ChipNOPLCount = (from item in processResult.OutData where item.OKNG == "NOPL" select item).Count();
                processResult.ChipLowCount = (from item in processResult.OutData where item.OKNG == "LOW" select item).Count();
                processResult.ChipOverCount = (from item in processResult.OutData where item.OKNG == "OVER" select item).Count();

                //evtTrsIdxImage( IndexViewImg );
            } );
        }




    }
}
