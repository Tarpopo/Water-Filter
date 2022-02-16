using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class CustomCursor : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField] private Sprite _activeCursor;
    [SerializeField] private Sprite _deactiveCursor;
    [SerializeField] private float _zPosition;
    private UserInput _userInput;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _userInput = FindObjectOfType<UserInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) _spriteRenderer.sprite = _activeCursor;
        if (Input.GetMouseButtonUp(0))_spriteRenderer.sprite = _deactiveCursor;
        if (Input.GetMouseButtonDown(2))Cursor.visible = false;
        transform.position = _userInput.GetTouchOnWorld(_zPosition);
    }
#endif
}
