using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateland.Test2.Core
{
    public static class DataHelpers
    {
        public static T ToModel<I, T>(this I objectToConvertFrom)
             where T : I, new()
        {
            // Create a new model to return
            var modelToReturn = new T();

            // Get all properties
            var properties = typeof(I).GetProperties();

            // Get and set all the property values
            for (int index = 0; index < properties.Length; index++)
            {
                modelToReturn.GetType().GetProperty(properties[index].Name).SetValue(
                modelToReturn, objectToConvertFrom.GetType().GetProperty(properties[index].Name).GetValue(objectToConvertFrom));
            }

            // Return the model
            return modelToReturn;

        }

        /// <summary>
        /// Takes a list from the database and converts it to a viewModel
        /// </summary>
        /// <typeparam name="I">The type of interface to send in</typeparam>
        /// <typeparam name="T">The type of ViewModel to return</typeparam>
        /// <param name="modelList">List to fill from</param>
        /// <returns>a list of the new viewmodels</returns>
        public static IEnumerable<T> ToViewModel<I, T>(this IEnumerable<I> modelList)
            // interface
            where I : class
            // T has to derive from interface
            where T : I, new()
        {
            // Get the properties of sent in type
            var properties = typeof(I).GetProperties();

            // The list to return
            List<T> listToReturn = new List<T>();

            // Goes through every item in the sent in list
            modelList.ToList().ForEach(item =>
            {
                // Creates a new instance of the type to return
                var newItem = new T();

                // For every item in the sent in list
                Parallel.ForEach(modelList, (currentProperty) =>
                {
                    // Check for property names and set the values
                    for (int index = 0; index < properties.Length; index++)
                    {
                        newItem.GetType().GetProperty(properties[index].Name).SetValue(
                        newItem, item.GetType().GetProperty(properties[index].Name).GetValue(item));
                    }
                });

                // Add the item to the returning list
                listToReturn.Add(newItem);

            });

            // Returns the list
            return listToReturn;
        }
    }
}
