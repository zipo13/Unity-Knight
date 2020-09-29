using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxMulitplier;
    private Transform cameraTranform;
    private Vector3 lastCameraPos;
    private float textureUnitSizeX;

    // Start is called before the first frame update
    void Start()
    {
        cameraTranform = Camera.main.transform;
        lastCameraPos = cameraTranform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        print("Sprite width = " + sprite.rect.width);
        print("Sprite texture width = " + sprite.texture.width);
        print("Sprite texture width calc = " + sprite.texture.width/sprite.pixelsPerUnit);
        print("Sprite texture real width = " + spriteRenderer.bounds.size.x);
        print("Sprite texture real width calc = " + spriteRenderer.bounds.size.x / sprite.pixelsPerUnit);
        print("Sprite texture scale = " + transform.localScale);
        textureUnitSizeX = (sprite.texture.width / sprite.pixelsPerUnit)* transform.localScale.x;
        //Texture2D texture = 
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            print("Camera pos: " + cameraTranform.transform.position.x);
            print("my pos: " + transform.position.x);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovment = cameraTranform.position - lastCameraPos;
        transform.position +=  new Vector3(parallaxMulitplier.x * deltaMovment.x, parallaxMulitplier.y * deltaMovment.y);
        lastCameraPos = cameraTranform.position;
        if (Mathf.Abs(cameraTranform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offset = (cameraTranform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTranform.position.x + offset, transform.position.y);
            //transform.position = new Vector3(transform.position.x + textureUnitSizeX, transform.position.y);
        }
    }
}
