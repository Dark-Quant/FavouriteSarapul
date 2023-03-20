using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Tour
{
    public string slug;
    public int version;
    public string title;
    public string description;
    public Texture image;
    public string nameScene;

    public Tour(string slug, int version, string title, string description, Texture image, string nameScene)
    {
        this.slug = slug;
        this.version = version;
        this.title = title;
        this.description = description;
        this.image = image;
        this.nameScene = nameScene;
    }
}