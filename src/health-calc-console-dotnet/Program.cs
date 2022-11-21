
using health_calc_pack_dotnet;
using helath_calc_pack_dotnet;
using helath_calc_pack_dotnet.Models;
using System;

Console.WriteLine("Enter with your height and weight to calculate your IMC!");

Console.Write("Height (m): ");
var Height = Console.ReadLine();

Console.Write("Weight (kg): ");
var Weight = Console.ReadLine();

Console.Write("Biological Gender (f or m): ");
var Sexo = Console.ReadLine();

Console.Write("Actvity Level - ");
Console.Write("0 - Sedentay | ");
Console.Write("1 - Moderate Active | ");
Console.Write("2 - Active | ");
Console.Write("3 - Highly Active: ");
var ActiveLevel = int.Parse(Console.ReadLine());

Console.Write("Main Goal - ");
Console.Write("0 - Bucking | ");
Console.Write("1 - Cutting | ");
Console.Write("2 - Maintenance ");
var MainGoal = int.Parse(Console.ReadLine());

IMC objIMC = new IMC();
MacroNutrient objMacroNutrient = new MacroNutrient();

double Result = objIMC.Calc(double.Parse(Height), double.Parse(Weight));
string Category = objIMC.GetIMCCategory(Result);

Console.WriteLine("Your IMC result is: " + Category);

var sex = (Sexo == "f") ? health_calc_pack_dotnet.Enums.BiologicalGenderEnum.female : health_calc_pack_dotnet.Enums.BiologicalGenderEnum.male;
var macro = objMacroNutrient.Calc(sex, double.Parse(Height), double.Parse(Weight),
    (health_calc_pack_dotnet.Enums.ActivityLevelEnum)ActiveLevel,
    (health_calc_pack_dotnet.Enums.MainGoalEnum)MainGoal);


Console.WriteLine($"Your consume of macro nutrients must be =>" +
    $"Protein: {macro.Protein}, " +
    $"Carbs: {macro.Carbs}, " +
    $"Fat: {macro.Fat}");


Console.ReadKey();
