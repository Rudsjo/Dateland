namespace Dateland.ViewModels
{
    // Required namespaces
    using Dateland.Core;

    /// <summary>
    /// ViewModel for the EditProfile page
    /// </summary>
    public class EditProfileViewModel
    {
        /// <summary>
        /// The user selected to be shown
        /// </summary>
        public User CurrentUser { get; set; } = new User();
    }
}
