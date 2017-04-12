using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
public class GameModelLoader{

    //Get data from xml file
    public static int row,col,square_size,wall_density;
    public static float game_speed;
    public static int health;
    static GameModelLoader() { 
        XmlDocument doc = new XmlDocument();
        doc.Load("Assets\\Models\\GameModel.xml");

        //setting tags
        XmlNodeList elemList = doc.GetElementsByTagName("row");
        foreach(XmlNode x in elemList)
        {
            row =XmlConvert.ToInt32( x.InnerText);
        }
        elemList = doc.GetElementsByTagName("col");

        foreach (XmlNode x in elemList)
        {
            col = XmlConvert.ToInt32(x.InnerText);
        }
        elemList = doc.GetElementsByTagName("squaresize");

        foreach (XmlNode x in elemList)
        {
            square_size = XmlConvert.ToInt32(x.InnerText);
        }
        elemList = doc.GetElementsByTagName("wallDensity");
       
        foreach(XmlNode x in elemList)
        {
            wall_density =XmlConvert.ToInt32( x.InnerText);
        }
        elemList = doc.GetElementsByTagName("gamespeed");

        foreach (XmlNode x in elemList)
        {
            game_speed = (float)XmlConvert.ToDouble(x.InnerText);
        }
        elemList = doc.GetElementsByTagName("health");
        foreach (XmlNode x in elemList)
        {
            health = (int)XmlConvert.ToDouble(x.InnerText);
        }


    }
}
