using Microsoft.AspNetCore.Mvc;
using Shape.Models;
using System;

namespace Shape.Controllers
{
    public class FitnessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateFitness(FitnessModel model)
        {
            // VARIABLES FOR CALCULATING BMI AND BODY FAT
            double bmi;
            double weightKg;
            double heightCm;
            double waistCm;
            double neckCm;
            double? hipCm;

            // CONVERT METRIC UNITS TO IMPERIAL IF NEEDED
            if (model.UnitSelection == "Metric")
            {
                heightCm = model.HeightCm;
                weightKg = model.WeightKg;
                neckCm = model.NeckCm;
                waistCm = model.WaistCm;
                hipCm = model.HipCm ?? 0;
            }
            else
            {
                heightCm = model.HeightFt * 12 * 2.54 + model.HeightIn * 2.54;
                weightKg = model.WeightLb * 0.453592;
                neckCm = model.NeckFt * 12 * 2.54 + model.NeckIn * 2.54;
                waistCm = model.WaistFt * 12 * 2.54 + model.WaistIn * 2.54;
                hipCm = (model.HipFt * 12 + model.HipIn) * 2.54;
            }

            // CALCULATE BMI IN METRIC UNITS
            bmi = weightKg / ((heightCm / 100.0) * (heightCm / 100.0));

            // BODY FAT PERCENTAGE
            double bodyFatPercentage;

            // CALCULATE BODY FAT PERCENTAGE BASED ON GENDER
            if (model.Gender == Gender.Male)
            {
                bodyFatPercentage = 495 / (1.0324 - 0.19077 * Math.Log10(waistCm - neckCm) + 0.15456 * Math.Log10(heightCm)) - 450;
            }
            else // FEMALE
            {
                double hipMinusNeck = hipCm.HasValue ? (double)hipCm - neckCm : 0;
                bodyFatPercentage = 495 / (1.29579 - 0.35004 * Math.Log10(waistCm + hipMinusNeck) + 0.22100 * Math.Log10(heightCm)) - 450;
            }

            // PASS CALCULATED BMI AND BODY FAT PERCENTAGE DIRECTLY TO THE VIEW
            ViewData["BMI"] = bmi;
            ViewData["BMI Category"] = GetBmi(bmi);
            ViewData["BodyFatPercentage"] = bodyFatPercentage;
            ViewData["BodyFatCategory"] = GetBodyFat(bodyFatPercentage);
            ViewData["DietRecommendation"] = GetDietRecommendation(bmi);

            return View("FitnessResult", model);
        }

        // BMI RESULT
        private static string GetBmi(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 24.9)
                return "Normal";
            else if (bmi < 29.9)
                return "Overweight";
            else if (bmi < 34.9)
                return "Obese";
            else
                return "Very Obese";
        }

        // BODY FAT RESULT
        private static string GetBodyFat(double bodyFatPercentage)
        {
            if (bodyFatPercentage < 5)
                return "Essential fat. Essential fat is necessary for various physiological functions, including hormone regulation, vitamin absorption, and insulation. However, extremely low levels of body fat can pose health risks.";
            else if (bodyFatPercentage < 14)
                return "Athletes. Athletes typically have lower body fat percentages due to their high levels of physical activity and lean muscle mass. This range is associated with optimal performance in many sports.";
            else if (bodyFatPercentage < 20)
                return "Fitness. This range is considered healthy and is associated with an active lifestyle and good overall fitness.";
            else if (bodyFatPercentage < 24)
                return "Average. This range is typical for most individuals and is generally considered healthy.";
            else if (bodyFatPercentage < 31)
                return "Obese. Individuals in this range may face increased health risks, including cardiovascular disease, diabetes, and other obesity-related conditions. It's important to consult with a healthcare professional for personalized advice and management.";
            else
                return "Very obese. Individuals in this range are at high risk for obesity-related health problems and may require medical intervention and lifestyle changes to improve their health and reduce their risk of complications.";
        }

        // DIET RECOMMENDATION
        private static string GetDietRecommendation(double bmi)
        {
            if (bmi < 18.5)
            {
                // UNDERWEIGHT
                return "Consider increasing your carbohydrate and protein intake. Aim for a balanced diet with approximately 45-65% of calories from carbohydrates, 10-35% from protein, and 20-35% from fat. Additionally, ensure you're consuming enough calories to support healthy weight gain.";
            }
            else if (bmi < 24.9)
            {
                // NORMAL
                return "Maintain a balanced diet with approximately 45-65% of calories from carbohydrates, 10-35% from protein, and 20-35% from fat. This balanced approach ensures adequate intake of all essential nutrients.";
            }
            else if (bmi < 29.9)
            {
                // OVERWEIGHT
                return "Consider a lower-carb, higher-protein approach such as a Low Carb High Fat (LCHF) or ketogenic (keto) diet. These diets typically involve around 5-10% of calories from carbohydrates, 20-30% from protein, and 60-75% from fat.";
            }
            else if (bmi < 35)
            {
                // OBESE
                return "For obesity, a Low Carb High Fat (LCHF) or ketogenic (keto) diet may be beneficial. Aim for around 5-10% of calories from carbohydrates, 20-30% from protein, and 60-75% from fat. These diets can promote fat loss and improve metabolic health. Additionally, consider creating a caloric deficit by reducing overall calorie intake while maintaining adequate nutrient intake.";
            }
            else
            {
                // VERY OBESE
                return "For severe obesity, a Low Carb High Fat (LCHF) or ketogenic (keto) diet may be beneficial. Aim for around 5-10% of calories from carbohydrates, 20-30% from protein, and 60-75% from fat. These diets can promote fat loss and improve metabolic health. Additionally, consider creating a caloric deficit by reducing overall calorie intake while maintaining adequate nutrient intake. It's advisable to consult with a healthcare professional or a registered dietitian for personalized guidance and support.";
            }
        }
    }
}
