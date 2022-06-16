using UnityEngine;

public static class BuilderExtentions
{
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        if (!component)
        {
            component = gameObject.AddComponent<T>();
        }
        return component;
    }

    public static GameObject SetName(this GameObject gameObject, string name)
    {
        gameObject.name = name;
        return gameObject;
    }

    public static GameObject AddRigidbody2D(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<Rigidbody2D>();
        return gameObject;
    }

    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        return gameObject;
    }

    public static GameObject BoxCollider2D(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<BoxCollider2D>();
        return gameObject;
    }

    public static GameObject AddBulletScript(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<Bullet>();
        return gameObject;
    }
}
