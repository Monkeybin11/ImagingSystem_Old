﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationUtilTool.Communication;
using System.Diagnostics;
using System.Threading;

namespace PLImg_V2
{
    public partial class RStage
    {
        #region Base
        SerialPort Port;
        RS232 RS;
        bool PrintMode;
        public int TimeOut = 20000;
        public int WaitRecivems = 30;

        object key = new object();

        public string Home { get { return "H:"; } set { } }
        public string GoAbs { get { return "A:"; } set { } }
        public string GoRel { get { return "M:"; } set { } }
        public string SetSpeed { get { return "D:"; } set { } }
        public string Status { get { return "!:"; } set { } }
        public string StatusOK { get { return "R"; } set { } }
        public string Pos { get { return "Q:"; } set { } }
        public string Go { get { return "G:"; } set { } }
        public string Stop { get { return "L:"; } set { } }

        public RStage( string comport, bool printmsg = false )
        {
            PrintMode = printmsg;
            Port = new SerialPort()
                            .Act( x =>
                            {
                                x.PortName = comport;
                                //x.PortName = "COM7";
                                x.BaudRate = 38400;
                                x.DataBits = 8;
                                x.Parity = Parity.None;
                                x.StopBits = StopBits.One;
                                x.Handshake = Handshake.RequestToSend;
                                x.ReadTimeout = 500;
                            } );



            RS = new RS232( this.Port,
                            CommandEndStyle.CR,
                            SendStyle.String,
                            300 );

            Console.WriteLine( RS.Port.IsOpen.ToString() );
        }

        public bool Open()
        {
            if ( RS.Open() )
            {
                return RS.Query( Status ) == StatusOK
                    ? true
                    : false;
            }
            return false;
        }




        public void Close()
        => RS.Close();

        public bool Send( string cmd )
        {
            lock ( key )
            {
                if ( PrintMode ) cmd.Print( "Send" );
                return RS.Query( cmd ) == "OK"
                        ? true
                        : false;
            }

        }

        public string Query( string cmd )
        {
            lock ( key )
            {
                if ( PrintMode ) cmd.Print( "Query" );
                return RS.Query( cmd );
            }

        }

        public bool WaitReady( int timeoutSec )
        {
            lock ( key )
            {
                Stopwatch stw = new Stopwatch();
                stw.Start();
                while ( RS.Query( Status ) != StatusOK )
                {
                    Thread.Sleep( WaitRecivems );
                    if ( timeoutSec > 0 && stw.ElapsedMilliseconds / 1000 > timeoutSec ) return false;
                }
                return true;
            }

        }

        public bool SendAndReady( string cmd, int timeoutSec = 0 )
        {
            lock ( key )
            {
                if ( PrintMode ) cmd.Print( "SendAndReady" );
                var temp = RS.Query( cmd );
                Stopwatch stw = new Stopwatch();
                stw.Start();
                while ( RS.Query( Status ) != StatusOK )
                {
                    Thread.Sleep( WaitRecivems );
                    if ( timeoutSec > 0 && stw.ElapsedMilliseconds / 1000 > timeoutSec ) return false;
                }
                return true;
            }

        }



        #endregion
    }

    public static class SgmaExt
    {

        public static string ToPos(
        this int pos )
        => pos >= 0 ? ("1+P" + (Math.Abs( pos ).ToString()))
                    : ("1-P" + (Math.Abs( pos ).ToString()));


        public static string ToPos(
        this double pos )
        => pos >= 0 ? ("1+P" + (Math.Abs( pos ).ToString()))
                    : ("1-P" + (Math.Abs( pos ).ToString()));

    
        public static string ToSpeed(
            this int speed )
        {
            string sspd = ((int)(speed/50)).ToString();
            string fspd = (speed).ToString();
            return $"S{sspd}F{fspd}R300";
        }

        public static int Degree2Pulse(
            this double degree
            )
        {
            return (int)(degree / 0.001);
        }

        public static int Degree2Pulse(
        this int degree
        )
        {
            return (int)(degree * 1000);
        }

        public static int Pulse2Degree(
        this double pulse
        )
        {
            return (int)(pulse / 1000);
        }

      


    }

}

