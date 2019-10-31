using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class Text2Speech : MonoBehaviour{


    [System.Serializable]
    public class postData{
        public string Command;
        public string SpeakerID;
        public string StyleID;
        public string SpeechRate;
        public string VoiceType;
        public string TextData;
        public string AudioFileFormat;
    }

    AudioClip audioClip;

    void Start(){
    }

    public IEnumerator Speak(string text){
        string apikey = "574d2e7369414131537a42783455734c73696c575870434262616373483252382e71466c6d587446776738";
        //string url = "https://api.apigw.smt.docomo.ne.jp/aiTalk/v1/textToSpeech?APIKEY=" + apikey;
        string url = "https://api.apigw.smt.docomo.ne.jp/crayon/v1/textToSpeechSsml?APIKEY=" + apikey;

        string path = Application.dataPath;
        

        Dictionary<string, string> aiTalksParams = new Dictionary<string, string>();  

        postData postdata = new postData();
        postdata.Command = "AP_Synth";
        postdata.StyleID = "1";
        postdata.SpeakerID = "1";
        postdata.SpeechRate = "1.00";
        postdata.VoiceType = "1";
        postdata.AudioFileFormat = "2";
        postdata.TextData = createSSML(text);

        string data = JsonUtility.ToJson(postdata);

        var PostData = System.Text.Encoding.UTF8.GetBytes(data);
        

        UnityWebRequest www = new UnityWebRequest(url,"POST");
		www.uploadHandler = (UploadHandler)new UploadHandlerRaw (PostData);
		www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer ();
		www.SetRequestHeader ("Content-Type", "application/json");
		yield return www.Send ();

        if(File.Exists(path+"/Voice/Speak.wav")){
            yield return textSave(www.downloadHandler.data, text);
        }
         
        using (WWW ww = new WWW("file:///"+path+"/Voice/Speak.wav")){
            yield return ww;
            audioClip = ww.GetAudioClip();
            if(audioClip == null){ 
                Debug.Log("Not exit");
            }else{
                AudioSource audioSource = this.GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.Play ();
            }
        }

        yield return null;
        //InitSaveData(); 
    }

    public IEnumerator textSave(byte[] data, string text){
        //var fs = new FileStream("Assets/Resources/"+text+".wav", FileMode.Create);
	    var sw = new BinaryWriter(new FileStream("Assets/Voice/Speak.wav", FileMode.Create));
	    sw.Write(data);

	    sw.Close();
        
        yield return null;
        
    }

    public string createSSML(string text){
        return "<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE speak SYSTEM \"ssml.dtd\"><speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"japanese\">"+ text +"</speak>";
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(Speak("こんにちは。"));
        }
    }
}