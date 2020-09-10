using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
