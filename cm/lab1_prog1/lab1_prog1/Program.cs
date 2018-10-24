using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_prog1
{
    class Program
    {
        static T CalcuteMachineEpsilon<T>(T startValue)
            where T : struct
        {
            if(typeof(T) == typeof(float))
            {
                float currentValue = Convert.ToSingle(startValue);
                float prevCurrentValue = default(float);

                while (!float.IsInfinity(currentValue) && currentValue != 0)
                {
                    prevCurrentValue = currentValue;
                    currentValue = prevCurrentValue / 2;
                }

                return (T)Convert.ChangeType(prevCurrentValue, typeof(T));
            }

            if (typeof(T) == typeof(double))
            {
                double currentValue = Convert.ToDouble(startValue);
                double prevCurrentValue = default(double);

                while (!double.IsInfinity(currentValue) && currentValue != 0)
                {
                    prevCurrentValue = currentValue;
                    currentValue = prevCurrentValue / 2;
                }

                return (T)Convert.ChangeType(prevCurrentValue, typeof(T));
            }

            throw new NotSupportedException(nameof(T));
        }
        static T CalcuteMachineInfinity<T>(T startValue, int factorPrecision)
            where T : struct
        {
            if (typeof(T) == typeof(float))
            {
                float currentValue = Convert.ToSingle(startValue);
                float prevCurrentValue = default(float);

                float factorValue = 1.0f;

                while (!float.IsInfinity(currentValue))
                {
                    prevCurrentValue = currentValue;
                    currentValue = prevCurrentValue * (factorValue + (1 / (Convert.ToSingle(Math.Pow(10, factorPrecision)))));
                }

                return (T)Convert.ChangeType(prevCurrentValue, typeof(T));
            }

            if (typeof(T) == typeof(double))
            {
                double currentValue = Convert.ToDouble(startValue);
                double prevCurrentValue = default(double);

                double factorValue = 1.0;

                while (!double.IsInfinity(currentValue))
                {
                    prevCurrentValue = currentValue;
                    currentValue = prevCurrentValue * (factorValue + (1 / (Math.Pow(10, factorPrecision))));
                }

                return (T)Convert.ChangeType(prevCurrentValue, typeof(T));
            }

            throw new NotSupportedException(nameof(T));
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"My Float Machine Epsilon: {CalcuteMachineEpsilon(1.0f)} \n.NET Float Machine Epsilon {float.Epsilon} \n");

            Console.WriteLine($"My Double Machine Epsilon: {CalcuteMachineEpsilon(1.0)} \n.NET Double Machine Epsilon {double.Epsilon} \n");

            Console.WriteLine($"My Float Machine Infinity: {CalcuteMachineInfinity(1.0f, 3)} \n.NET Float Machine Infinity {float.MaxValue} \n");

            Console.WriteLine($"My Double Machine Infinity: {CalcuteMachineInfinity(1.0, 3)} \n.NET Double Machine Infinity {double.MaxValue} \n");
        }
    }
}
