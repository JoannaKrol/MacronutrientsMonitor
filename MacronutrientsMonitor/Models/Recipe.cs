namespace MacronutrientsMonitor.Models
{
    public class Recipe : Macronutrients
    {
        public Guid Id { get; private set; }
        public string RecipeName { get; private set; }

        public Recipe(string recipeName, decimal fat, decimal protein, decimal carbohydrates, int calories) : base(fat, protein, carbohydrates, calories)
        {
            Id = Guid.NewGuid();
            RecipeName = recipeName;
        }
    }
}
