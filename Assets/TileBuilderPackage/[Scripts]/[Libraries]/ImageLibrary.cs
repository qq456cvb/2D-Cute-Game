using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageLibrary : MonoBehaviour
{
    
		//Reference.
		private static ImageLibrary _instance;
    
		public static List<Sprite> spriteImages = new List<Sprite> ();  
		public static List<Texture> textureImages = new List<Texture> ();
    
		//SpriteList
		public static Dictionary<int, Sprite> spriteDictionary = new Dictionary<int, Sprite> ();
    
		private ImageLibrary ()
		{
		}
    
		public static ImageLibrary Instance {
				get {
						if (_instance == null) {
								_instance = new ImageLibrary ();    
						}
            
						return _instance;
				}
		}

		public static void GetSpriteData ()
		{
				Object[] spriteImageFromDataPath = Resources.LoadAll (@"[Graphics]/SourceFiles/Tilesheets/BuildingBlocks", typeof(Sprite));
        
				if (spriteImageFromDataPath == null) {
						return;
				}
        
				foreach (Object sprite in spriteImageFromDataPath) {
						Sprite s = (Sprite)sprite;
						spriteImages.Add (s);
				}
				/*
        foreach (Object sprite in spriteImageFromDataPath) {
            Resources.UnloadAsset(sprite);
        }
        */
				for (int i = 0; i < spriteImages.Count; i++) {
						spriteDictionary.Add (i, spriteImages [i]);
				}
		}
    
		public static void GetTextureData ()
		{
				Object[] textureImageFromDataPath = Resources.LoadAll (@"[Graphics]/SourceFiles/PNG_Textures", typeof(Texture));
        
				if (textureImageFromDataPath == null) {
						return;
				}
        
				foreach (Object texture in textureImageFromDataPath) {
						Texture t = (Texture)texture;
						textureImages.Add (t);
				}
				/*
        foreach (Object texture in textureImageFromDataPath) {
            Resources.UnloadAsset(texture);
        }
        */
		}
    
		public static void DestroySpriteAndTextureData ()
		{
				spriteImages.Clear ();
				textureImages.Clear ();
				spriteDictionary.Clear ();
		}
}
