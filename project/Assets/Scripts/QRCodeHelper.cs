using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRCodeHelper
{
    static public Texture2D CreateQRCode(string str, int w, int h)
    {
        var tex = new Texture2D(w, h, TextureFormat.ARGB32, false);
        var content = Write(str, w, h);
        tex.SetPixels32(content);
        tex.Apply();
        return tex;
    }

    static Color32[] Write(string content, int w, int h)
    {
        Debug.Log(content + " / " + w + " / " + h);

        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = w,
                Height = h
            }
        };
        return writer.Write(content);
    }
}