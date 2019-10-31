        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map.Interfaces;
using Mapbox.Unity.Map.Strategies;
using Mapbox.Unity.Map.TileProviders;

public class Popup : MonoBehaviour
{

    bool textDone = false;
    bool imageDone = false;
    bool mapDone  = false;


    void Start(){
    
        GameObject text = this.transform.Find("IntroText").gameObject;
        GameObject image = this.transform.Find("IntroImage").gameObject;
        GameObject map  = this.transform.Find("Map").gameObject;
        GameObject cube = this.transform.Find("Cube").gameObject;

    //Set Position
        var textPos = text.transform.position;
        textPos.x = 0.367f;
        textPos.y = 1.36f;
        textPos.z = 0;

        var imagePos = image.transform.position;
        imagePos.x = 0.3f;
        imagePos.y = 0.673f;
        imagePos.z = 0.05f;

        var mapPos = map.transform.position;
        mapPos.x = 0.21f;
        mapPos.y = 1.2f;
        mapPos.z = 0;

        text.transform.position = textPos;
        image.transform.position = imagePos;
        map.transform.position = mapPos;

    //Set Rotation
        text.transform.rotation = Quaternion.Euler(0.0f, -195, 0);
        image.transform.rotation = Quaternion.Euler(0.0f, -195, 0);

    //Set Scale
        text.transform.localScale = new Vector3(0.001f,0.001f,0.001f);
        image.transform.localScale = new Vector3(0.001f,0.001f,0.001f);
        
        text.SetActive(false);
        image.SetActive(false);

        var speaker = cube.GetComponent<Text2Speech> ();
        //StartCoroutine(speaker.Speak ("こんにちは"));

    }
    

   public void PopText(string textname){
        if(textDone != true){
            textDone = true;
            GameObject text = this.transform.Find("IntroText").gameObject;
            var scenarioText = Resources.Load(textname) as TextAsset;

            if(scenarioText != null){
                var targetText = text.GetComponent<Text>();
                targetText.rectTransform.sizeDelta = new Vector2(targetText.preferredWidth, targetText.preferredHeight);
                targetText.text = scenarioText.text; 

                text.SetActive(true);
            }else{
                Debug.Log("Not Found Text");
            }
        }

   }

   public void PopImage(string imagename){
       if(imageDone != true){
           imageDone = true;
           GameObject image = this.transform.Find("IntroImage").gameObject;
           var scenarioImage = Resources.Load<Sprite>(imagename);
           
           if (scenarioImage != null){
               var targetImage = image.GetComponent<Image>();
               targetImage.sprite = scenarioImage;
               
               image.SetActive(true);
            }else{
               Debug.Log("Not Found Sprite");
            }
       }
   }
   public void PopMap(){
       if(mapDone != true){
           mapDone = true;
           GameObject map = this.transform.Find("Map").gameObject;

           //map.GetComponent<AbstractMap> ().latLon = new Vector2(37.7f, -122.4f);

           map.SetActive(true);
       }

   }

    void Update(){

    }
   
}
