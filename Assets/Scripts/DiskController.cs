using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskController : MonoBehaviour
{
    public float DiskSize;
    public Color DiskColor;

    private GameObject _diskSprite;
    private SpriteRenderer _diskSprite_SpriteRenderer;
    void Start()
    {
        _diskSprite = gameObject.transform.Find("DiskSprite").gameObject;
        _diskSprite_SpriteRenderer = _diskSprite.GetComponent<SpriteRenderer>();

        DiskColor.a = 1f;
        _diskSprite_SpriteRenderer.color = DiskColor;
        // gameObject.transform.localScale = GetScaleFromDiskSize();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = GetScaleFromDiskSize;
    }

    private Vector3 GetScaleFromDiskSize => new Vector3((DiskSize * 3) + 10f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

    public void SetDiskSize(int size) => DiskSize = size;
}
