using System;
using System.Text.RegularExpressions;

namespace lab7
{
    public class Fraction : ICloneable, IComparable<Fraction>, IFormattable, IConvertible
    {
        private long num;
        private long den;
        public long Num
        {
            get
            {
                return num;
            }
            set
            {
                SetNum(value);
            }
        }
        public long Den
        {
            get
            {
                return den;
            }
            set
            {
                SetDen(value);
            }
        }
        public Fraction()
        {
        }
        public Fraction(long num)
        {
            Num = num;
            Den = 1;
        }
        public Fraction(long num, long den)
        {
            Num = num;
            Den = den;
        }
        public Fraction(double x)
        {
            Fraction fraction = GetFraction(x.ToString());
            Num = fraction.num;
            Den = fraction.den;
            Simplify();
        }
        public void SetNum(long NewNum)
        {
            num = NewNum;
            if (num != 0 && den != 0)
            {
                Simplify();
            }
        }
        public void SetDen(long NewDen)
        {
            if (NewDen == 0)
            {
                throw new ArgumentException("Denominator can't be equal to zero.");
            }
            else if (NewDen < 0)
            {
                throw new ArgumentException("Denominator must be a natural number.");
            }
            den = NewDen;
            if (num != 0)
            {
                Simplify();
            }
        }
        private double GetDouble()
        {
            return (double)num / den;
        }
        private static long Gcd(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }
        private void Simplify()
        {
            long gcd = Gcd(Math.Abs(num), den);
            num /= gcd;
            den /= gcd;
        }
        public static Fraction GetFraction(string s)
        {
            if (TryParse(s, out Fraction fraction))
            {
                return fraction;
            }
            else
            {
                throw new FormatException("Unsupported input string format.");
            }
        }
        public static bool TryParse(string s, out Fraction fraction)
        {
            fraction = null;
            Regex firstPattern = new Regex(@"^(-?\d+)/(\d+)$");
            Regex secondPattern = new Regex(@"^(-?\d+)[,\.](\d+)$");
            Regex thirdPattern = new Regex(@"^(-?\d+)$");
            if (firstPattern.IsMatch(s))
            {
                Match match = firstPattern.Match(s);
                long num = long.Parse(match.Groups[1].Value);
                long den = long.Parse(match.Groups[2].Value);
                fraction = new Fraction(num, den);
                return true;
            }
            else if (secondPattern.IsMatch(s))
            {
                Match match = secondPattern.Match(s);
                long integer = long.Parse(match.Groups[1].Value);
                int sign = integer >= 0 ? 1 : -1;
                string dec = match.Groups[2].Value;
                long den = (long)Math.Pow(10, dec.Length);
                long num = (Math.Abs(integer) * den + long.Parse(dec)) * sign;
                fraction = new Fraction(num, den);
                return true;
            }
            else if (thirdPattern.IsMatch(s))
            {
                Match match = thirdPattern.Match(s);
                fraction = new Fraction(long.Parse(match.Groups[1].Value));
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return CompareTo((Fraction)obj) == 0;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(num, den);
        }
        public override string ToString()
        {
            return ToString("S");
        }
        public object Clone()
        {
            return new Fraction(num, den);
        }
        public int CompareTo(Fraction fraction)
        {
            long lcm = den * fraction.den / Gcd(Math.Abs(den), fraction.den);
            long num1 = num * (lcm / den);
            long num2 = fraction.num * (lcm / fraction.den);
            return num1.CompareTo(num2);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        } 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "S";
            }
            if (format == "S")
            {
                return $"{num}/{den}";
            }
            else if (format == "D")
            {
                return GetDouble().ToString();
            }
            else if (format == "I")
            {
                if (Math.Abs(num) > den)
                {
                    long integer = num / den;
                    return integer.ToString();
                }
                else
                {
                    return ToString("S");
                }
            }
            else
            {
                throw new FormatException($"The \"{format}\" format is not supported.");
            }
        }
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            return num != 0;
        }
        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(GetDouble(), provider);
        }
        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(GetDouble(), provider);
        }
        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(GetDouble(), provider);
        }
        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(GetDouble(), provider);
        }
        public double ToDouble(IFormatProvider provider)
        {
            return GetDouble();
        }
        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(GetDouble(), provider);
        }
        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(GetDouble(), provider);
        }
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(GetDouble(), provider);
        }
        public SByte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(GetDouble(), provider);
        }
        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(GetDouble(), provider);
        }
        public string ToString(IFormatProvider provider)
        {
            return ToString("S", provider);
        }
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(GetDouble(), conversionType);
        }
        public UInt16 ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(GetDouble(), provider);
        }
        public UInt32 ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(GetDouble(), provider);
        }
        public UInt64 ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(GetDouble(), provider);
        }
        public static explicit operator sbyte(Fraction x)
        {
            return x.ToSByte(null);
        }
        public static explicit operator short(Fraction x)
        {
            return x.ToInt16(null);
        }
        public static explicit operator int(Fraction x)
        {
            return x.ToInt32(null);
        }
        public static explicit operator long(Fraction x)
        {
            return x.ToInt64(null);
        }        
        public static explicit operator float(Fraction x)
        {
            return x.ToSingle(null);
        } 
        public static explicit operator double(Fraction x)
        {
            return x.ToDouble(null);
        }
        public static explicit operator decimal(Fraction x)
        {
            return x.ToDecimal(null);
        }
        public static Fraction operator +(Fraction x)
        {
            return x;
        }
        public static Fraction operator -(Fraction x)
        {
            return new Fraction(-x.num, x.den);
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + (-b);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.num, a.den * b.den);
        }
        public static Fraction operator *(Fraction a, long b)
        {
            return new Fraction(a.num * b, a.den);
        } 
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.num * b.den, a.den * b.num);
        }
        public static Fraction operator /(Fraction a, long b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.num, a.den * b);
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 0;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 1;
        }
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == -1;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != -1;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 1;
        }
    }
}