using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipProcessingLib
{
    public class Config : IConfig
    {
        public int ChipWNum     {get;set;}
        public int ChipHNum     {get;set;}
        public int ChipWSize    {get;set;}
        public int ChipHSize    {get;set;}
        public int ThrsUpLimt   {get;set;}
        public int ThrsDwLimt   {get;set;}
        public int AreaUpLimt   {get;set;}
        public int AreaDwLimt   {get;set;}
        public double TLX       {get;set;}
        public double TLY       {get;set;}
        public double TRX       {get;set;}
        public double TRY       {get;set;}
        public double BLX       {get;set;}
        public double BLY       {get;set;}
        public double BRX       {get;set;}
        public double BRY       {get;set;}
    }

    public class PLConfig : IConfig
    {
        public static IConfig GetInstance()
        {
            var res = new PLConfig()
            {
                ChipWNum   = 360,
                ChipHNum   = 360,
                ChipWSize  = 24,
                ChipHSize  = 24,
                ThrsUpLimt =100000,
                ThrsDwLimt = 10,
                AreaUpLimt = 300,
                AreaDwLimt = 600,
                TLX        =0,
                TLY        =0,
                TRX        =0,
                TRY        =0,
                BLX        =0,
                BLY        =0,
                BRX        =0,
                BRY        =0
            };
            return res;
        }

        public int ChipWNum { get; set; }
        public int ChipHNum { get; set; }
        public int ChipWSize { get; set; }
        public int ChipHSize { get; set; }
        public int ThrsUpLimt { get; set; }
        public int ThrsDwLimt { get; set; }
        public int AreaUpLimt { get; set; }
        public int AreaDwLimt { get; set; }
        public double TLX { get; set; }
        public double TLY { get; set; }
        public double TRX { get; set; }
        public double TRY { get; set; }
        public double BLX { get; set; }
        public double BLY { get; set; }
        public double BRX { get; set; }
        public double BRY { get; set; }
    }

    public class ScterConfig : IConfig
    {
        public static IConfig GetInstance()
        {
            var res = new ScterConfig()
            {
                ChipWNum   = 360,
                ChipHNum   = 360,
                ChipWSize  = 24,
                ChipHSize  = 24,
                ThrsUpLimt =100000,
                ThrsDwLimt = 10,
                AreaUpLimt = 300,
                AreaDwLimt = 600,
                TLX        =0,
                TLY        =0,
                TRX        =0,
                TRY        =0,
                BLX        =0,
                BLY        =0,
                BRX        =0,
                BRY        =0
            };
            return res;
        }

        public int ChipWNum { get; set; }
        public int ChipHNum { get; set; }
        public int ChipWSize { get; set; }
        public int ChipHSize { get; set; }
        public int ThrsUpLimt { get; set; }
        public int ThrsDwLimt { get; set; }
        public int AreaUpLimt { get; set; }
        public int AreaDwLimt { get; set; }
        public double TLX { get; set; }
        public double TLY { get; set; }
        public double TRX { get; set; }
        public double TRY { get; set; }
        public double BLX { get; set; }
        public double BLY { get; set; }
        public double BRX { get; set; }
        public double BRY { get; set; }

    }

}
