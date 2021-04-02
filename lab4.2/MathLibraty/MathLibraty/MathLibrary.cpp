#include "pch.h" 
#include "MathLibrary.h"

double __cdecl Add(double firstValue, double secondValue)
{
	return firstValue + secondValue;
}
double __cdecl Subtraction(double firstValue, double secondValue)
{
	return firstValue - secondValue;
}
double __cdecl Multiplication(double firstValue, double secondValue)
{
	return firstValue * secondValue;
}
double __cdecl Division(double firstValue, double secondValue)
{
	return firstValue / secondValue;
}
double __cdecl Abs(double firstValue)
{
	return firstValue >= 0 ? firstValue : Multiplication(firstValue, -1);
}
double __cdecl Opposite(double firstValue)
{
	return Division(1, firstValue);
}
double __cdecl Mirror(double firstValue)
{
	return Multiplication(firstValue, -1);
}
double __cdecl Minimal(double firstValue, int secondValue)
{
	return firstValue < secondValue ? firstValue : secondValue;
}
double __cdecl Maximum(double firstValue, int secondValue)
{
	return firstValue > secondValue ? firstValue : secondValue;
}
double __cdecl Pow(double firstValue, unsigned int secondValue)
{
	double tmp = firstValue;
	for (int i = 0; i < secondValue - 1; i++)
	{
		firstValue = Multiplication(tmp, firstValue);
	}
	return firstValue;
}