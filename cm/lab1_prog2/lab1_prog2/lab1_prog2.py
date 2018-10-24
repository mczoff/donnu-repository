import math
import sys

def erfWithFactorialInt(erf):
    currentSum = 0.0
    n = 0
    while(True): 
        numerator = ((-1) ** n) * erf ** (2 * n + 1)
        denumerator = math.factorial(n) * ( 2 * n + 1)
        valueFraction = numerator / denumerator
        currentSum+=valueFraction

        if(valueFraction == 0.0):
            break

        n+=1
    return 2 / math.sqrt(math.pi) * currentSum, n

def erfWithFactorialFloat(erf):
    currentSum = 0.0
    n = 0
    while(True): 
        numerator = ((-1) ** n) * erf ** (2 * n + 1)
        denumerator = math.gamma(n + 1) * ( 2 * n + 1)
        valueFraction = numerator / denumerator
        currentSum+=valueFraction

        if(valueFraction == 0.0):
            break

        n+=1
    return 2 / math.sqrt(math.pi) * currentSum, n


def erfWithNoFactorialInt(erf):
    currentSum = erf
    prevvalue = erf
    n = 1
    while(True): 
        numerator = (-1) * (erf ** 2) * (2 * n - 1)
        denumerator = n * (2 * n + 1)
        valueFraction = numerator / denumerator        
        prevvalue = prevvalue * valueFraction       
        currentSum += prevvalue

        if(prevvalue == 0.0):
            break

        n+=1
    return (2 / math.sqrt(math.pi) * currentSum, n)


print('Alrorithm which not include factorial - {}'.format(erfWithNoFactorialInt(3)))
print('Alrorithm which include int - {}'.format(erfWithFactorialInt(3)))
print('Alrorithm which include float - {}'.format(erfWithFactorialFloat(3)))
   