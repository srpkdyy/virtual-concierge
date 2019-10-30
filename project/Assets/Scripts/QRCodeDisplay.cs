using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class QRCodeDisplay : MonoBehaviour
{

    void QrDisplay(string text ){
        Popup popup = GetComponent<Popup>();
        int size = 256;
        string savePath = Application.dataPath + "QRCode.png";

        var tex = QRCodeHelper.CreateQRCode(text,size,size);
        var _picture = Sprite.Create(tex, new Rect(0,0,size,size), Vector2.zero);

        /*
        using (var fs = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                //var _picture = tex.EncodeToPNG();
                fs.Write(_picture, 0, _picture.Length);
            } 
        */
        var image = GetComponent<Image>();
        image.sprite = _picture;
              
    }
    void Start(){
        // QrDisplay("https://youtube.com");
        // Debug.Log(Application.dataPath);
    }
}
