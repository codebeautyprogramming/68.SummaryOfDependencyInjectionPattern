using CookBook.UI;
using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using System.Configuration;

namespace CookBook
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IIngredientsRepository ingredientsRepository=null;

            if (ConfigurationManager.AppSettings["repositoryType"] == "txt")
                ingredientsRepository = new IngredientsTxtRepository();
            else
                ingredientsRepository = new IngredientsRepository();

            Application.Run(new IngredientsForm(ingredientsRepository));
        }
    }
}