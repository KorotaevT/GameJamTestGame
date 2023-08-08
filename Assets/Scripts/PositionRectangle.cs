using UnityEngine;

public class PositionRectangle : MonoBehaviour
{
    public Vector2 startCoordinate; // Начальная координата (один конец)
    public Vector2 endCoordinate;   // Конечная координата (другой конец)
    
    private void Update()
    {
        // Получаем размеры прямоугольного объекта (предполагается, что его центр - начальная точка)
        Vector2 rectangleSize = GetComponent<SpriteRenderer>().bounds.size;
        
        // Рассчитываем позицию центра прямоугольного объекта
        Vector2 centerPosition = (startCoordinate + endCoordinate) / 2f;
        
        // Устанавливаем позицию центра прямоугольного объекта
        transform.position = centerPosition;
        
        // Рассчитываем направление, в котором прямоугольный объект будет размещаться
        Vector2 direction = (endCoordinate - startCoordinate).normalized;
        
        // Вычисляем угол между направлением и вектором (1, 0)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Устанавливаем угол поворота объекта
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
        // Изменяем масштаб объекта по обеим осям в соответствии с расстоянием между начальной и конечной точками
        float distance = Vector2.Distance(startCoordinate, endCoordinate);
        transform.localScale = new Vector3(distance / rectangleSize.x, distance / rectangleSize.y, 1f);
    }
}