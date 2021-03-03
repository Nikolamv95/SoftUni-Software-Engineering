--START
--Like in C# if you subtract 2 integeres the result will be int. If we want to avoid that use:
--(1.0 * (Table name WITH integers)) */ (Table name with integers)
--You can use CAST() also
SELECT ID,
1.0 * (A*H)/2.0 AS AREA
FROM Triangles2
--END

--START
--ABS – absolute value -> ABS(Value)
--END

--START
--SQRT – square root (the result will be float) - SQRT(Value)
--END

--START
--POWER like in c# Power(value, power)
SELECT  Id, 
		X1,
		Y1,
		X2,
		Y2,
		SQRT( Power(X1 - X2, 2) + Power(Y1 + Y2, 2))
	FROM Lines
--END

--START
--ROUND – obtains the desired precision - Math.Round in C# ROUND(Value, Precision) + value if we want
--END

--START
--FLOOR & CEILING – return the nearest integer
--FLOOR(Value) -> 1.99 = 1
--CEILING(Value) -> 1.0001 = 2
--END

SELECT *, 
CEILING(1.0 * Quantity / (BoxCapacity * PalletCapacity)) AS [Number of pallets]
FROM Products



