using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForumTestTask.Models
{
    public class Post
    {
        // PostId
        public int Id { get; set; }

        // ThemeId for Post
        public int ThemeId { get; set; }

        // MessageText
        public string MessageText { get; set; }

        // PostDate
        public DateTime PostDate { get; set; }

        // CreatedByUser
        public string UserLogin { get; set; }

        // UpdateDate
        public DateTime UpdateDate { get; set; }
    }
}