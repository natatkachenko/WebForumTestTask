using System.Collections.Generic;
using WebForumTestTask.Models;

namespace WebForumTestTask.ViewModels
{
    public class ThemeViewModel
    {
        public Theme Theme { get; set; }
        public List<PostUser> Posts { get; set; }
    }
}