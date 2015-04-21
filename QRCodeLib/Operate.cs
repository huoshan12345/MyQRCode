﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace ThoughtWorks.QRCode
{
    public static class Operate
    {
        public static class QRcodeHelper
        {
            public struct QRCodeInput
            {
                public string Source;
                public int QRCodeScale;
                public int QRCodeVersion;
                public QRCodeEncoder.ENCODE_MODE QRCodeEncodeMode;
                public QRCodeEncoder.ERROR_CORRECTION QRCodeErrorCorrect;
            };

            public static Image Encode(QRCodeInput qrCodeInput)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = qrCodeInput.QRCodeEncodeMode;
                qrCodeEncoder.QRCodeScale = qrCodeInput.QRCodeScale;
                qrCodeEncoder.QRCodeVersion = qrCodeInput.QRCodeVersion;
                qrCodeEncoder.QRCodeErrorCorrect = qrCodeInput.QRCodeErrorCorrect;
                Image image = qrCodeEncoder.Encode(qrCodeInput.Source);
                return image;
            }

            public static Image Encode(string Source)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 0;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                Image image = qrCodeEncoder.Encode(Source);
                return image;
            }

            public static string Decode(Image image)
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                Bitmap BM = new Bitmap(image);
                string result = decoder.decode(new QRCodeBitmapImage(new Bitmap(image)));
                BM.Dispose();
                return result;
            }

            public static string Decode(string FileName)
            {
                Image image = new Bitmap(FileName);
                QRCodeDecoder decoder = new QRCodeDecoder();
                Bitmap BM = new Bitmap(image);
                string result = decoder.decode(new QRCodeBitmapImage(new Bitmap(image)));
                BM.Dispose();
                image.Dispose();
                return result;
            }
        }
    }
}
