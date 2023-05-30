using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.General
{
    public enum GameMathOperationType
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }


    public class GameMaths
    {
        #region General
        /// <summary>
        /// Проверяет будет ли число параметр меньше, чем случайное число от 0 до 100. Если параметр меньше случайного, то true
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckRandom(float value)
        {
            float rnd = Random.Range(0f, 100f);
            return (value < rnd);
        }
        #endregion

        #region Angles, Radians, Degrees Operations

        /// <summary>
        /// Вычисляет угол начального вектора и поворачивает его на угол вектора направления
        /// </summary>
        /// <param name="initialVector"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public static Vector2 RotateVector2(Vector2 initial, Vector2 direction)
        {
            float initialDegree = Vector2ToDegree(initial);
            float directionDegree = Vector2ToDegree(direction);
            initialDegree += directionDegree;
            Vector2 result = DegreeToVector2(initialDegree) * initial.magnitude;
            return result;
        }
        /// <summary>
        /// Вычисляет угол начального вектора и поворачивает его в противоположную сторону на угол вектора направления
        /// </summary>
        /// <param name="initialVector"></param>
        /// <param name="directionVector"></param>
        /// <returns></returns>
        public static Vector2 CounterRotateVector2(Vector2 initial, Vector2 direction)
        {
            float initialDegree = Vector2ToDegree(initial);
            float directionDegree = Vector2ToDegree(direction);
            initialDegree -= directionDegree;
            Vector2 result = DegreeToVector2(initialDegree) * initial.magnitude;
            return result;
        }

        /// <summary>
        /// Преобразует радианы в вектор.
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Sin(radian), Mathf.Cos(radian));
        }

        /// <summary>
        /// Преобразует угол в градусах в нормализованный вектор.
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        public static float DegreeBetweenVectors(Vector2 vector1, Vector2 vector2)
        {
            Vector2 newVector = vector2 - vector1;
            return Vector2ToDegree(newVector);
        }

        /// <summary>
        /// Преобразует вектор в угол в градусах.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float Vector2ToDegree(Vector2 vector)
        {
            float result = (float)((Mathf.Atan2(vector.x, vector.y) / Mathf.PI) * 180f);
            return NormalizeDegree(result);
        }


        /// <summary>
        /// Вычисляет угол, который получится при попытке повернуться из заданного угла в заданном направлении на заданное количество градусов.
        /// </summary>
        /// <param name="startDegree">Начальный угол</param>
        /// <param name="targetDegree">Нужный угол</param>
        /// <param name="degreeValue">максимальное кол-во градусов, на которое можно повернуться</param>
        /// <returns></returns>
        public static float DirectDegree(float startDegree, float targetDegree, float degreeValue)
        {
            float result = 0;

            startDegree = NormalizeDegree(startDegree);
            targetDegree = NormalizeDegree(targetDegree);
            if (degreeValue < 0) degreeValue = NormalizeDegree(degreeValue);

            float direction = 1;
            float maxValue = 0;

            if (targetDegree > startDegree)
            {
                if (targetDegree - startDegree <= 180)
                {
                    direction = 1;
                    maxValue = targetDegree - startDegree;
                }
                if (targetDegree - startDegree > 180)
                {
                    direction = -1;
                    maxValue = 360 - targetDegree + startDegree;
                }
            }

            if (targetDegree < startDegree)
            {
                if (startDegree - targetDegree <= 180)
                {
                    direction = -1;
                    maxValue = startDegree - targetDegree;
                }
                if (startDegree - targetDegree > 180)
                {
                    direction = 1;
                    maxValue = 360 - startDegree + targetDegree;
                }
            }

            if (degreeValue > maxValue) degreeValue = maxValue;

            result = startDegree + degreeValue * direction;
            result = NormalizeDegree(result);

            return result;
        }

        /// <summary>
        /// Нормализует угол в градусах.
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static float NormalizeDegree(float degree)
        {
            degree = degree % 360;

            while (degree < 0)
                degree += 360;

            return degree;
        }

        /// <summary>
        /// Нормализует угол в градусах к величине от -180 до 180.
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static float NormalizeDegreeToAbs180(float degree)
        {
            degree = degree % 360;

            while (degree < 180)
                degree += 360;

            while (degree > 180)
                degree -= 360;

            return degree;
        }

        /// <summary>
        /// Вычисляет разницу в градусах без знака между двумя углами.
        /// </summary>
        /// <param name="degree1"></param>
        /// <param name="degree2"></param>
        /// <returns></returns>
        public static float DeltaAngleNoSign(float degree1, float degree2)
        {
            float result = 0;


            result = Mathf.Abs(Mathf.DeltaAngle(degree1, degree2));

            return result;
        }
        #endregion

        #region Curves Functions
        /// <summary>
        /// Функция в промежутке от 0 до 1. Функция в виде подъёма, сглаживание в начале и конце. При 0 = 0, при 0.5 = 0.5, при 1 = 1
        /// </summary>
        /// <param name="number"></param>
        public static float RiseSmoothNumber1(float number)
        {
            float result = (Mathf.Sin((3.14f * number) - 1.5705f) + 1f) / 2f; // (sin((3.14 * x) - 1.5705) + 1) / 2
            return result;
        }

        /// <summary>
        /// Функция в промежутке от 0 до 1. Функция в виде подъёма, сглаживание в конце. При 0 = 0, при 0.5 = 0.75, при 1 = 1
        /// </summary>
        /// <param name="number"></param>
        public static float RiseSmoothNumber2(float number)
        {
            float result = number * (2 - number * 1); // x * (2 - x * 1)
            return result;
        }

        /// <summary>
        /// Функция в промежутке от 0 до 1. Функция в виде холма, сглаживание в центре. При 0 = 0, при 0.5 = 1, при 1 = 0, для расчета прыжка / падения
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float HillSmoothNumber(float number)
        {
            float result = number * (4 - number * 4); // x * (4 - x * 4)
            return result;
        }

        /// <summary>
        /// Функция в промежутке от 0 до 1. Функция в виде высокого плато, по краям крайне резкие подъем и спуск. При 0 = 0, при 0.1, 0.5, 0.9 = 1, при 1 = 0, для плавного перехода, например при анимации
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float HighPlaneSmoothNumber(float number)
        {
            float result = number * (16 - number * 16); // x * (16 - x * 16)
            if (result > 1) result = 1;
            return result;
        }
        #endregion

        #region Math Operations
        public static float MathOperation(float value1, float value2, GameMathOperationType operationType)
        {
            switch (operationType)
            {
                case GameMathOperationType.Add:
                    return Add(value1, value2);
                case GameMathOperationType.Subtract:
                    return Subtract(value1, value2);
                case GameMathOperationType.Multiply:
                    return Multiply(value1, value2);
                case GameMathOperationType.Divide:
                    return Divide(value1, value2);
                default:
                    return Add(value1, value2);
            }
        }

        public static float Add(float value1, float value2)
        {
            return value1 + value2;
        }
        public static float Subtract(float value1, float value2)
        {
            return value1 - value2;
        }
        public static float Multiply(float value1, float value2)
        {
            return value1 * value2;
        }

        public static float Divide(float value1, float value2)
        {
            return value1 / value2;
        }
        #endregion

        #region Segments, Rays & Lines intersection operations
        public static float CrossProduct(Vector2 directionA, Vector2 directionB)
        {
            return directionA.x * directionB.y - directionA.y * directionB.x;
        }

        public static bool TryGetLineIntersectionPoint(Vector2 offsetA, Vector2 directionA, Vector2 offsetB, Vector2 directionB, out Vector2 result)
        {
            float crossProduct = CrossProduct(directionA, directionB);

            if (Mathf.Approximately(crossProduct, 0f))
            {
                // Прямые параллельны
                result = default;
                return false;
            }

            float xMultiplierA = directionA.y / directionA.x;
            float xMultiplierB = directionB.y / directionB.x;
            float yOffsetA = offsetA.y - xMultiplierA * offsetA.x; // offset with x = 0
            float yOffsetB = offsetB.y - xMultiplierB * offsetB.x; // offset with x = 0
            float x = (yOffsetB - yOffsetA) / (xMultiplierA - xMultiplierB);
            float y = xMultiplierA * x + yOffsetA;

            /*
              m1 * x + c1 = m2 * x + c2
              m1 * x - m2 * x = c2 - c1
              (m1 - m2) * x = c2 - c1
              x =  (c2 - c1) / (m1 - m2)
              y = m1 * x + c1
            */

            result = new Vector2(x, y);
            return true;
        }

        public static bool TryGetLineIntersectionPoint(Vector2 directionA, Vector2 directionB, out Vector2 result)
        {
            float crossProduct = CrossProduct(directionA, directionB);
            if (crossProduct == 0)
            {
                result = default;
                return false;
            }
            float intersectionPointX = (directionA.y - directionB.y) / crossProduct;
            float intersectionPointY = (directionA.x - directionB.x) / crossProduct;
            result = new Vector2(intersectionPointX, intersectionPointY);
            return true;
        }

        public static bool TryGetSegmentIntersectionPoint(Vector2 segmentStartA, Vector2 segmentEndA, Vector2 segmentStartB, Vector2 segmentEndB, out Vector2 result)
        {
            Vector2 directionA = segmentEndA - segmentStartA;
            Vector2 directionB = segmentEndB - segmentStartB;
            float crossProduct = CrossProduct(directionA, directionB);
            if (crossProduct == 0)
            {
                result = default;
                return false;
            }
            float intersectionPositionOnSegmentA = ((segmentStartB.x - segmentStartA.x) * (segmentStartB.y - segmentEndB.y) - (segmentEndB.y - segmentStartA.y) * (segmentStartB.x - segmentEndB.x)) / crossProduct;
            float intersectionPositionOnSegmentB = ((segmentStartA.x - segmentEndA.x) * (segmentEndB.y - segmentStartA.y) - (segmentStartA.y - segmentEndA.y) * (segmentStartB.x - segmentStartA.x)) / crossProduct;
            if (intersectionPositionOnSegmentA < 0 || intersectionPositionOnSegmentA > 1 ||
                intersectionPositionOnSegmentB < 0 || intersectionPositionOnSegmentB > 1)
            {
                result = default;
                return false;
            }
            float intersectionPointX = segmentStartA.x + intersectionPositionOnSegmentA * (segmentEndA.x - segmentStartA.x);
            float intersectionPointY = segmentStartA.y + intersectionPositionOnSegmentA * (segmentEndA.y - segmentStartA.y);
            result = new Vector2(intersectionPointX, intersectionPointY);
            return true;
        }

        public static bool TryGetRayIntersectionPoint(Vector2 rayStartA, Vector2 rayDirectionA, Vector2 rayStartB, Vector2 rayDirectionB, out Vector2 result)
        {
            Vector2 directionA = rayDirectionA - rayStartA;
            Vector2 directionB = rayDirectionB - rayStartB;
            float crossProduct = CrossProduct(directionA, directionB);
            if (crossProduct == 0)
            {
                result = default;
                return false;
            }
            float intersectionPositionOnRayA = ((rayStartB.x - rayStartA.x) * (rayStartB.y - rayDirectionB.y) - (rayDirectionB.y - rayStartA.y) * (rayStartB.x - rayDirectionB.x)) / crossProduct;
            float intersectionPositionOnRayB = ((rayStartA.x - rayDirectionA.x) * (rayDirectionB.y - rayStartA.y) - (rayStartA.y - rayDirectionA.y) * (rayStartB.x - rayStartA.x)) / crossProduct;
            if (intersectionPositionOnRayA < 0 ||
                intersectionPositionOnRayB < 0)
            {
                result = default;
                return false;
            }
            float intersectionPointX = rayStartA.x + intersectionPositionOnRayA * (rayDirectionA.x - rayStartA.x);
            float intersectionPointY = rayStartA.y + intersectionPositionOnRayA * (rayDirectionA.y - rayStartA.y);
            result = new Vector2(intersectionPointX, intersectionPointY);
            return true;
        }
        #endregion

        #region Vector3 <-> Vector2 axis dependant convertations

        public static List<Vector2> Vector3ToVector2(List<Vector3> value, Axis ignoredAxis)
        {
            List<Vector2> resultPoints = new List<Vector2>();
            switch (ignoredAxis)
            {
                case Axis.X:
                    for (int i = 0; i < value.Count; i++)
                        resultPoints.Add(Vector3ToVector2X(value[i]));
                    return resultPoints;
                case Axis.Y:
                    for (int i = 0; i < value.Count; i++)
                        resultPoints.Add(Vector3ToVector2Y(value[i]));
                    return resultPoints;
                case Axis.Z:
                    for (int i = 0; i < value.Count; i++)
                        resultPoints.Add(Vector3ToVector2Z(value[i]));
                    return resultPoints;
                default:
                    return resultPoints;
            }
        }
        public static Vector2 Vector3ToVector2(Vector3 value, Axis ignoredAxis)
        {
            switch (ignoredAxis)
            {
                case Axis.X:
                    return Vector3ToVector2X(value);
                case Axis.Y:
                    return Vector3ToVector2Y(value);
                case Axis.Z:
                    return Vector3ToVector2Z(value);
                default:
                    return default;
            }
        }
        private static Vector2 Vector3ToVector2X(Vector3 value)
        {
            return new Vector2(value.z, value.y);
        }
        private static Vector2 Vector3ToVector2Y(Vector3 value)
        {
            return new Vector2(value.x, value.z);
        }
        private static Vector2 Vector3ToVector2Z(Vector3 value)
        {
            return new Vector2(value.x, value.y);
        }
        public static List<Vector3> Vector2ToVector3(List<Vector2> value, Axis ignoredAxis)
        {
            List<Vector3> resultPoints = new List<Vector3>();
            switch (ignoredAxis)
            {
                case Axis.X:
                    for (int i = 0; i < value.Count; i++)
                        resultPoints.Add(Vector2ToVector3X(value[i]));
                    return resultPoints;
                case Axis.Y:
                    for (int i = 0; i < value.Count; i++)
                        resultPoints.Add(Vector2ToVector3Y(value[i]));
                    return resultPoints;
                case Axis.Z:
                    for (int i = 0; i < value.Count; i++)
                        resultPoints.Add(Vector2ToVector3Z(value[i]));
                    return resultPoints;
                default:
                    return resultPoints;
            }
        }
        public static Vector3 Vector2ToVector3(Vector2 value, Axis ignoredAxis)
        {
            switch (ignoredAxis)
            {
                case Axis.X:
                    return Vector2ToVector3X(value);
                case Axis.Y:
                    return Vector2ToVector3Y(value);
                case Axis.Z:
                    return Vector2ToVector3Z(value);
                default:
                    return default;
            }
        }
        private static Vector3 Vector2ToVector3X(Vector2 value)
        {
            return new Vector3(0, value.y, value.x);
        }
        private static Vector3 Vector2ToVector3Y(Vector2 value)
        {
            return new Vector3(value.x, 0, value.y);
        }
        private static Vector3 Vector2ToVector3Z(Vector2 value)
        {
            return new Vector3(value.x, value.y, 0);
        }
        #endregion

        #region GeometryFuncs
        public static Vector2 GetNormal(Vector2 value)
        {
            return new Vector2(-value.y, value.x);
        }

        public static List<Vector2> SmoothAngle(Vector2 pointA, Vector2 pointB, Vector2 pointC, float smoothDistance, float smoothPower, bool addPositionToResult)
        {
            List<Vector2> result = new List<Vector2>();
            Vector2 directionAB = pointB - pointA;
            Vector2 directionBC = pointC - pointB;
            Vector2 directionABNormalized = directionAB.normalized;
            Vector2 directionBCNormalized = directionBC.normalized;
            float directionsDistance = Vector2.Distance(directionABNormalized, directionBCNormalized);
            Vector2 pointANormalized = -directionABNormalized * smoothDistance;
            Vector2 pointBNormalized = directionBCNormalized * smoothDistance;
            Vector2 normalToAB = GetNormal(directionABNormalized);
            Vector2 normalToBC = GetNormal(directionBCNormalized);

            Vector2 intersectionPoint;
            TryGetLineIntersectionPoint(pointANormalized, pointANormalized + normalToAB, pointBNormalized, pointBNormalized + normalToBC, out intersectionPoint);


            int pointsCount = (int)(directionsDistance * smoothPower);
            if (pointsCount >= 2)
            {
                result.Add(pointANormalized);

                if (pointsCount >= 3)
                {
                    Vector2[] additionalPoints = GetIntermediatePoints(intersectionPoint, pointANormalized, pointBNormalized, pointsCount - 2);
                    result.AddRange(additionalPoints);
                    DebugFunctions.DrawPoint(pointB + intersectionPoint, 0.05f, Color.red, 2);
                }
                result.Add(pointBNormalized);
            }
            else
            {
                result.Add(Vector2.zero);
            }


            if (addPositionToResult)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] += pointB;
                }
            }

            return result;
        }

        public static Vector2[] GetIntermediatePoints(Vector2 center, Vector2 pointA, Vector2 pointB, int count)
        {
            Vector2[] intermediatePoints = new Vector2[count];

            // Вычисляем радиус и угол между точками A и B
            float radius = Vector2.Distance(center, pointA);
            float angle = Mathf.Atan2(pointA.y - center.y, pointA.x - center.x);

            // Вычисляем длину дуги между точками A и B
            float arcLength = GetArcLength(center, pointA, pointB, radius);

            // Вычисляем расстояние между промежуточными точками
            float stepSize = arcLength / (count + 1);

            // Вычисляем координаты промежуточных точек
            for (int i = 0; i < count; i++)
            {
                angle += stepSize / radius;
                float x = center.x + radius * Mathf.Cos(angle);
                float y = center.y + radius * Mathf.Sin(angle);
                intermediatePoints[i] = new Vector2(x, y);
            }

            return intermediatePoints;
        }

        private static float GetArcLength(Vector2 center, Vector2 pointA, Vector2 pointB, float radius)
        {
            float angleA = Mathf.Atan2(pointA.y - center.y, pointA.x - center.x);
            float angleB = Mathf.Atan2(pointB.y - center.y, pointB.x - center.x);

            float multiplier = 1;
            // Обрабатываем случай, когда точки A и B находятся по разные стороны окружности
            if (Mathf.Abs(angleB - angleA) > Mathf.PI)
            {
                angleA += Mathf.Sign(angleB - angleA) * 2 * Mathf.PI;
            }
            multiplier = Mathf.Sign(angleB - angleA);

            return Mathf.Abs(angleB - angleA) * radius * multiplier;
        }
        #endregion
    }
}
