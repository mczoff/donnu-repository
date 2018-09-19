from decimal import Decimal

print("Calculate value from float data type")

currentFloat = 1.0
prevcurrentFloat = 0.0

while (currentFloat != 0.0):
    prevcurrentFloat = currentFloat
    currentFloat = currentFloat / 2

print("Epsilon float = {0}".format(prevcurrentFloat))

print("Calculate value from float data type")

currentDecimal = Decimal("1.0")
prevcurrentDecimal = Decimal("0.0")

while (currentDecimal != 0.0):
    prevcurrentDecimal = currentDecimal
    currentDecimal = currentDecimal / 2

print("Epsilon decimal = {0}".format(prevcurrentDecimal))