using UnityEngine;

public static class TransformExtension
{
    
    public static void ScaleYUpperEdge(this Transform transform , float scale)
    {
        transform.localScale += new Vector3(0f, scale*Time.deltaTime, 0f);
        transform.position += new Vector3(0f, (scale/2)*Time.deltaTime, 0f);
    }
    
    public static void ScaleYBottomEdge(this Transform transform , float scale)
    {
        scale = -scale;
        transform.localScale -= new Vector3(0f, scale*Time.deltaTime, 0f);
        transform.position += new Vector3(0f, (scale/2)*Time.deltaTime, 0f);
    }
    
    public static void ScaleXRightEdge(this Transform transform , float scale)
    {
        transform.localScale += new Vector3( scale*Time.deltaTime,0f, 0f);
        transform.position += new Vector3( (scale/2)*Time.deltaTime,0f, 0f);
    }
    
    public static void ScaleXLeftEdge(this Transform transform , float scale)
    {
        scale = -scale;
        transform.localScale -= new Vector3( (scale)*Time.deltaTime,0f, 0f);
        transform.position += new Vector3( (scale/2)*Time.deltaTime,0f, 0f);
    }
}
