﻿using Dateland.Test2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dateland.Test2.Core
{
    /// <summary>
    /// Class used to set up the relation between User and Relationships between outher users
    /// </summary>
    public class UserRelationRelation
    {
        /// <summary>
        /// Gets or sets the user relation ID
        /// </summary>
        [Key]
        public int UserRelationID { get; set; }

        /// <summary>
        /// Gets or sets the first users ID
        /// </summary>
        public User _FirstUserID { get; set; }

        /// <summary>
        /// Gets or sets the first users ID
        /// </summary>
        public User _SecondUserID { get; set; }

        /// <summary>
        /// Gets or sets the users relation
        /// </summary>
        [ForeignKey("RelationID")]
        public Relation _Relation { get; set; }
    }
}