using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Bounds _cameraBounds;
    private SpriteRenderer _spriteRenderer;

    public float speed = 10.0f;

    private IMovementController _movementController;
    private IGunController _gunController;

    public void SetMovementController(IMovementController movementController){
        _movementController = movementController;
    }

    public void SetGunController(IGunController gunController){
        _gunController = gunController;
    }

    public void MoveHorizontally(float x){
        _movementController.MoveHorizontally(x*GetSpeed());
    }

    public float GetSpeed(){
        //todo: controlar a velocidade baseado no estado da nave
        return speed;
    }

    public void MoveVertically(float y){
        _movementController.MoveVertically(y*GetSpeed());
    }

    public void ApplyFire(){
        //todo: Recarregar
        _gunController.Fire();
    }

    void Start(){
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;

        var size = new Vector3(width, height);

        _cameraBounds = new Bounds(Vector3.zero, size);

        _spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Log( _spriteRenderer.sprite.rect.width );
        Debug.Log( _spriteRenderer.bounds.max.x );
        Debug.Log( _spriteRenderer.bounds.max.y );
        Debug.Log( _spriteRenderer.bounds.extents.x );
        Debug.Log( _spriteRenderer.bounds.extents.y );
    }

    //void Update(){
        //if(Input.GetKeyDown(KeyCode.A)){
        //if(Input.GetKeyUp(KeyCode.A)){
        /*
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(new Vector3(-0.1f,0,0));
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(new Vector3(0.1f,0,0));
        }
        */
        /*
        if(Input.GetAxis("Horizontal") > 0 ){
            transform.Translate(new Vector3(-0.1f,0,0));
        }
        else if(Input.GetAxis("Vertical") > 0 ){
            transform.Translate(new Vector3(0.1f,0,0));
        }
        */
        /*
        if(Input.GetAxisRaw("Horizontal") > 0 ){
            transform.Translate(new Vector3(-0.1f,0,0));
        }
        else if(Input.GetAxisRaw("Vertical") > 0 ){
            transform.Translate(new Vector3(0.1f,0,0));
        }
        */
        //ApplyMovement();
        //FireProjectile();
    //}

    void LateUpdate(){
        var newPosition = transform.position;

        var spriteWidth = _spriteRenderer.sprite.bounds.extents.x;
        var spriteHeight = _spriteRenderer.sprite.bounds.extents.y;

        newPosition.x = Mathf.Clamp(newPosition.x, _cameraBounds.min.x + spriteWidth, _cameraBounds.max.x - spriteWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, _cameraBounds.min.y + spriteHeight, _cameraBounds.max.y - spriteHeight);

        transform.position = newPosition;
    }

    /*
    void ApplyMovement(){
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * speed * new Vector3(hor,ver));
    }
    */
}
