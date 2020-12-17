

else if (unit == "cm" && convertedUnit == "mm")
{
    number = number / 10;
}
else if (unit == "m" && convertedUnit == "cm")
{
    number = number / 100;
}
else if (unit == "m" && convertedUnit == "mm")
{
    number = number * 1000;
}