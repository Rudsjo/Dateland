using System;

namespace RequestFunctions
{
    class Requests
    {
        #region Request functions


        /// <summary>
        /// Action to send a friendrequest to a user
        /// </summary>
        /// <param name="id">the identifier for the person recieving the request</param>
        /// <returns></returns>
        public async Task<IActionResult> SendFriendRequest(string id)
        {
            // Get the current user
            var currentUser = await UserManager.FindByEmailAsync(User.Identity.Name);

            // Create a new pending relation between two users
            var relation = new UserRelations() { User1Id = currentUser.Id, User2Id = id, RelationID1 = (int)EnumRelations.Pending };

            // Check to se if they are already friends or friendinvite pending
            if ((await Repository.GetRelation<UserRelations>(currentUser.Id)).Where(x => x.User2Id == id).FirstOrDefault() == null)
            {
                // Create the new relation
                await Repository.CreateRelation<UserRelations>(relation);
            }

            else relation = null;
            // Set the relation to null
            //else relation = null;

            return RedirectToAction("Index", controllerName: "Account");
        }

        ///// <summary>
        ///// Action to choose what to to with a request
        ///// Accept, Deny or Leave for later
        ///// </summary>
        ///// <param name="userId">The identifier for the user</param>
        ///// <param name="userRequesting">the user who sent the request</param>
        ///// <param name="choice">the choice of what to do with the request</param>
        ///// <returns></returns>
        //public async Task<IActionResult> AnswerFriendRequests(string userId, User userRequesting, string choice) // string choice för tydligeheten. byts ut mot lämpligt.
        //{
        //    // Gets a specified request based on which user gets sent in the function
        //    var requests = (await Repository.GetRelation<UserRelations>(userId)).Where(x => x.User1Id == userRequesting.Id).FirstOrDefault();

        //    // If the user presses yes
        //    if (choice == "YES")
        //    {
        //        // Sets the relationID to friends
        //        requests.RelationID1 = (int)EnumRelations.Friends;

        //        // Updates the relation between the users
        //        await Repository.Update<UserRelations>(requests);
        //    }
        //    // If the user presses no
        //    else if (choice == "NO")
        //    {
        //        // Sets the relationID to unmatched
        //        requests.RelationID1 = (int)EnumRelations.Unmatched;

        //        // Updates the relation between the users
        //        await Repository.Update<UserRelations>(requests);
        //    }
        //    // If the user does not want to answer, maybe saving for later, or has not decided
        //    else
        //    {
        //        // Sets the relationID to none
        //        requests.RelationID1 = (int)EnumRelations.None;

        //        // Updates the relation between the users
        //        await Repository.Update<UserRelations>(requests);
        //    }

        //    // Should be changed
        //    return RedirectToAction("Index", controllerName: "Account");
        //}

        public async Task<IActionResult> AcceptFriendRequest(string userRequestingId)
        {
            // Get the current user
            var currentUser = await UserManager.FindByEmailAsync(User.Identity.Name);

            // Gets a specified request based on which user gets sent in the function
            var requests = (await Repository.GetRelation<UserRelations>(currentUser.Id)).Where(x => x.User1Id == userRequestingId).FirstOrDefault();

            // Sets the relationID to friends
            requests.RelationID1 = (int)EnumRelations.Friends;

            // Updates the relation between the users
            await Repository.Update<UserRelations>(requests);

            // Should be changed
            return RedirectToAction("Index", controllerName: "Account");

        }

        public async Task<IActionResult> DenyFriendRequest(string userRequestingId)
        {
            // Get the current user
            var currentUser = await UserManager.FindByEmailAsync(User.Identity.Name);

            // Gets a specified request based on which user gets sent in the function
            var requests = (await Repository.GetRelation<UserRelations>(currentUser.Id)).Where(x => x.User1Id == userRequestingId).FirstOrDefault();

            // Sets the relationID to unmatched
            requests.RelationID1 = (int)EnumRelations.Unmatched;

            // Updates the relation between the users
            await Repository.Update<UserRelations>(requests);

            // Should be changed
            return RedirectToAction("Index", controllerName: "Account");
        }

        public async Task<IActionResult> RemoveFriendRequest(string userRequestingId)
        {
            // Get the current user
            var currentUser = await UserManager.FindByEmailAsync(User.Identity.Name);

            // Gets a specified request based on which user gets sent in the function
            var requests = (await Repository.GetRelation<UserRelations>(currentUser.Id)).Where(x => x.User1Id == userRequestingId).FirstOrDefault();

            // Sets the relationID to none
            requests.RelationID1 = (int)EnumRelations.None;

            // Updates the relation between the users
            await Repository.Update<UserRelations>(requests);

            // Should be changed
            return RedirectToAction("Index", controllerName: "Account");
        }

        /// <summary>
        /// Action to remove someone from friendslist
        /// </summary>
        /// <param name="userId">the identifier for the user</param>
        /// <param name="userToRemove">the user that is to be removed</param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveFriend(string userToRemoveId)
        {
            // Get the current user
            var currentUser = await UserManager.FindByEmailAsync(User.Identity.Name);

            // Get the relation between the two users sent in in function
            var remove = (await Repository.GetRelation<UserRelations>(currentUser.Id)).Where(x => x.User1Id == userToRemoveId || x.User2Id == userToRemoveId).FirstOrDefault();

            //Checks to se if there is a relation or if. Maybe only remove the relation type friends?
            if (remove != null && remove.RelationID != (int)EnumRelations.None)
            {
                // Removes the relation
                await Repository.Delete<UserRelations>(remove);
            }

            // Should be changed
            return RedirectToAction("Index", controllerName: "Account");
        }

        ///// <summary>
        ///// Function to get a users pending requests
        ///// </summary>
        ///// <param name="id">the identifier for the user</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<UserRelations>> GetPendingRequests(string id)
        //{
        //    // To get a users pending requests
        //    return (await Repository.GetRelation<UserRelations>(id)).Where(x => x.RelationID1 == (int)EnumRelations.Pending);
        //}
        #endregion
    }
}
