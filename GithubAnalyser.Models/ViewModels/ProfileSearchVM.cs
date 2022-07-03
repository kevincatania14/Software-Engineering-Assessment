using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubAnalyser.Models.ViewModels
{
    /// <summary>
    /// Model class for validating search term
    /// </summary>
    public class ProfileSearchVM
    {
        [Required(ErrorMessage = "Enter GitHub username to analyse")]
        [DisplayName("Username")]
        public string username { get; set; }
    }
}