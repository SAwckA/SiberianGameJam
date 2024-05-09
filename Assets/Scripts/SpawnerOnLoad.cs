using UnityEngine;

public class SpawnerOnLoad : SingletonBase<SpawnerOnLoad>
{
    private Vector3 _position;
    private bool _isSpawnable = false;
    public void SetPosition(Vector3 position)
    {
        _position = position;
        _isSpawnable = true;
    }

    public void TrySpawn(GameObject obj)
    {
        if (!_isSpawnable) return;

        CameraFollow camera = Camera.main.GetComponent<CameraFollow>();

        obj.transform.position = _position;
        camera.transform.position = new Vector3()
        {
            x = _position.x,
            y = _position.y + camera.OffSetY,
            z = _position.z,
        };
        _isSpawnable = false;
        
    }
}
