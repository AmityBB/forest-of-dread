using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector2 moveDis;
    [SerializeField] private Sprite[] idleSprites;
    [SerializeField] private Sprite[] moveSprites;
    private int activeSprite = 0;

    private void Start()
    {
        StartCoroutine(Anim());
    }
    public void PlayerMovement(CallbackContext context)
    {
        if (context.performed)
        {
            moveDis = context.ReadValue<Vector2>();
            if (!_isMoving)
            {
                activeSprite = 0;
                _isMoving = true;
            }
        }
        if(context.canceled)
        {
            moveDis = Vector2.zero;
            if (_isMoving)
            {
                activeSprite = 0;
                _isMoving = false;
            } 
        }
    }

    private void FixedUpdate()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseScreenPosition.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (mouseScreenPosition.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
            if (_isMoving)
        {
            if(activeSprite > 5)
            {
                activeSprite = 0;
            }
            
            if (mouseScreenPosition.x < transform.position.x)
            {
                transform.Translate(new Vector2(-moveDis.x * 0.2f,0));
            }
            transform.Translate(moveDis.normalized * 0.1f);

            gameObject.GetComponent<SpriteRenderer>().sprite = moveSprites[activeSprite];
        }
        else
        {
            if (activeSprite > 3)
            {
                activeSprite = 0;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = idleSprites[activeSprite];
        }
    }

    IEnumerator Anim()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        activeSprite++;
        StartCoroutine(Anim());
    }
}
