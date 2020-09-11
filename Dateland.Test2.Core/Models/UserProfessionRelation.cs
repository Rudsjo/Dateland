using Dateland.Test2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    /// <summary>
    /// Class used to set up the relation between User and Profession
    /// </summary>
    public class UserProfessionRelation
    {
        /// <summary>
        /// Gets or sets the user profession ID
        /// </summary>
        [Key]
        public int UserProfessionID { get; set; }

        /// <summary>
        /// Gets or sets the users ID
        /// </summary>
        [ForeignKey("UserID")]
        public User _User { get; set; }

        /// <summary>
        /// Gets or sets the users profession
        /// </summary>
        [ForeignKey("ProfessionID")]
        public Profession _Profession { get; set; }
    }
}
