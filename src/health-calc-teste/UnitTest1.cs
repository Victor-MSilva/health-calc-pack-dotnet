using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet;
using helath_calc_pack_dotnet.Models;
using helath_calc_pack_dotnet.Interfaces;

namespace health_calc_test_xunit
{
    public class MacronutrienteTest
    {
        [Fact]
        public void When_RequestMacronutrientsCalcWithValidDataForCutting_ThenReturnResult()
        {
            //Arrange
            var MacronutrienteObj = new MacroNutrient();
            var Sexo = BiologicalGenderEnum.male;
            var Height = 1.80;
            var Weight = 90;
            var NivelAtividadeFisica = ActivityLevelEnum.Active;
            var ObjetivoFisico = MainGoalEnum.Maintenance;

            var Expected = new MacroNutrientsModel()
            {
                Carbs = 180,
                Protein = 180,
                Fat = 90


            };


            //Act
            var Result = MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico);

            //Assert

            Assert.Equal(Expected.Carbs, Result.Carbs);
            Assert.Equal(Expected.Protein, Result.Protein);
            Assert.Equal(Expected.Fat, Result.Fat);


        }


        [Theory]
        [InlineData(ActivityLevelEnum.Sedentary, 340)]
        [InlineData(ActivityLevelEnum.ModerateActive, 340)]
        [InlineData(ActivityLevelEnum.Active, 595)]
        [InlineData(ActivityLevelEnum.HighlyActive, 595)]

        public void When_RequestMacronutrientsCalcWithValidDataForBuking_TheReturnResult(
            ActivityLevelEnum NivelAtividadeFisica,
            int Carboitrados)
        {
            //Arrange
            var MacronutrienteObj = new MacroNutrient();
            var Sexo = BiologicalGenderEnum.male;
            var Height = 1.80;
            var Weight = 90;
            var ObjetivoFisico = MainGoalEnum.Bucking;

            var Expected = new MacroNutrientsModel()
            {
                Carbs = Carboitrados,
                Protein = 180,
                Fat = 180
            };


            //Act
            var Result = MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Carbs, Result.Carbs);
            Assert.Equal(Expected.Protein, Result.Protein);
            Assert.Equal(Expected.Fat, Result.Fat);


        }

        [Fact]
        public void When_RequestMacronutrientsCalcWithValidDataForMaintenance_ThenReturnResult()
        {
            //Arrange
            var MacronutrienteObj = new MacroNutrient();
            var Sexo = BiologicalGenderEnum.male;
            var Height = 1.68;
            var Weight = 85;
            var NivelAtividadeFisica = ActivityLevelEnum.Sedentary;
            var ObjetivoFisico = MainGoalEnum.Maintenance;

            var Expected = new MacroNutrientsModel()
            {
                Carbs = 425,
                Protein = 170,
                Fat = 85
            };


            //Act
            var Result = MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Carbs, Result.Carbs);
            Assert.Equal(Expected.Protein, Result.Protein);
            Assert.Equal(Expected.Fat, Result.Fat);


        }

        [Fact]
        public void When_RequestMacronutrientsCalcWithInvalidData_ThenThrowsException()
        {
            //Arrange
            var MacronutrienteObj = new MacroNutrient();
            var Sexo = BiologicalGenderEnum.male;
            var Height = 1.78;
            var Weight = 50;
            var NivelAtividadeFisica = ActivityLevelEnum.Sedentary;
            var ObjetivoFisico = MainGoalEnum.Maintenance;


            //Act & Assert
            Assert.Throws<Exception>(() => MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico));

        }
    }
}