#pragma once

#ifdef MATHLIBRARY_EXPORTS
#define MATHLIBRARY_API __declspec(dllexport)
#else
#define MATHLIBRARY_API __declspec(dllimport)
#endif
extern "C" MATHLIBRARY_API double __cdecl Add(double firstValue, double secondValue);
extern "C" MATHLIBRARY_API double __cdecl Subtraction(double firstValue, double secondValue);
extern "C" MATHLIBRARY_API double __cdecl Multiplication(double firstValue, double secondValue);
extern "C" MATHLIBRARY_API double __cdecl Division(double firstValue, double secondValue);
extern "C" MATHLIBRARY_API double __cdecl Abs(double firstValue);
extern "C" MATHLIBRARY_API double __cdecl Opposite(double firstValue);
extern "C" MATHLIBRARY_API double __cdecl Mirror(double firstValue);
extern "C" MATHLIBRARY_API double __cdecl Minimal(double firstValue, int secondValue);
extern "C" MATHLIBRARY_API double __cdecl Maximum(double firstValue, int secondValue);
extern "C" MATHLIBRARY_API double __cdecl Pow(double firstValue, unsigned int secondValue);
