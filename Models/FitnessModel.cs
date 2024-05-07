namespace Shape.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class FitnessModel
    {
        // UNIT SELECTION
        public string? UnitSelection { get; set; } = "Metric";

        // METRIC
        public double HeightCm { get; set; } = 0;

        public double WeightKg { get; set; } = 0;
        public double WaistCm { get; set; } = 0;
        public double NeckCm { get; set; } = 0;

        // IMPERIAL
        public int HeightFt { get; set; } = 0;

        public double HeightIn { get; set; } = 0;
        public double WeightLb { get; set; } = 0;
        public double NeckFt { get; set; } = 0;
        public double NeckIn { get; set; } = 0;
        public double WaistFt { get; set; } = 0;
        public double WaistIn { get; set; } = 0;

        // GENDER AND AGE
        public Gender Gender { get; set; } = Gender.Male;

        public int Age { get; set; } = 0;

        // HIP MEASUREMENT, ONLY FOR FEMALES
        public double? HipCm { get; set; } = null;

        public int? HipFt { get; set; } = null;
        public int? HipIn { get; set; } = null;
    }
}
