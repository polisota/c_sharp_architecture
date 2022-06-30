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

    public static GameObject SetTag(this GameObject gameObject, string tag)
    {
        gameObject.tag = tag;
        return gameObject;
    }

    public static GameObject AddRigidbody2D(this GameObject gameObject, float gravity)
    {
        var comp = gameObject.GetOrAddComponent<Rigidbody2D>();
        comp.gravityScale = gravity;
        return gameObject;
    }

    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        return gameObject;
    }

    public static GameObject BoxCollider2D(this GameObject gameObject, bool trigger)
    {
        var col = gameObject.GetOrAddComponent<BoxCollider2D>();
        col.isTrigger = trigger;
        return gameObject;
    }

    public static GameObject AddBulletScript(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<Bullet>();
        return gameObject;
    }

    public static GameObject AddBulletUfoScript(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<UfoBullet>();
        return gameObject;
    }
}
