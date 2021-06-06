using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public Borders borders;
    private Camera _camera;
    public int speedPlayer;
    private Vector2 _mousePosition;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
        _camera = Camera.main;
    }

    private void Start()
    {
        ResizeBorders();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, _mousePosition, speedPlayer * Time.deltaTime); 
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, borders.minX, borders.maxX), Mathf.Clamp(transform.position.y, borders.minY, borders.maxY)); 
    }

    private void ResizeBorders()
    {
        borders.minX = _camera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = _camera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = _camera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = _camera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}
