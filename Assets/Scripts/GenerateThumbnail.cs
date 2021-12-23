using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateThumbnail : MonoBehaviour
{
    public GameObject obj;
    public string savePath;
    public string fileName;

    void Start()
    {
        //Texture2D texture = AssetPreview.GetAssetPreview(obj);
        //byte[] bytes = texture.EncodeToPNG();
        //File.WriteAllBytes(savePath + fileName + ".png", bytes);
    }
}
