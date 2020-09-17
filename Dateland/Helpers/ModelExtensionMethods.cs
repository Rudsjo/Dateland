namespace Dateland.Helpers
{
    using System.Linq;
    // Required namespaces
    using System.Reflection;

    /// <summary>
    /// Extension methods to models
    /// </summary>
    public static class ModelExtensionMethods
    {
        /// <summary>
        /// Updates the in reletional to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orgModel">The org model.</param>
        /// <param name="newModel">The new model.</param>
        /// <returns></returns>
        public static T UpdateInRelationTo<T>(this T orgModel, T newModel, params string[] propertiesToSkip) where T : class, new()
        {
            // If any of the models are null
            if (orgModel == null || newModel == null) return null;

            // Get all properties from the original model
            var originalProperties = orgModel.GetType().GetProperties();

            // Get all properties from the new model
            var newProperties = newModel.GetType().GetProperties();

            // Loop through all properties in the original model
            for(int i = 0; i < originalProperties.Count(); i++)
            {
                // If the new model has an updated value on the same property and it is'nt a property to skip...
                if(originalProperties[i].GetValue(orgModel) != newProperties[i].GetValue(newModel) && newProperties[i].GetValue(newModel) != null && !propertiesToSkip.Contains(originalProperties[i].Name))
                    // update the original model's property
                    originalProperties[i].SetValue(orgModel, newProperties[i].GetValue(newModel));
            }

            // Return the final model
            return orgModel;
        }
    }
}
