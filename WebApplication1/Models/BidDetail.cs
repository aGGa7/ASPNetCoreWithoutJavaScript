using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BidDetail
    {
       
      //  public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя организации")]
        public string NameOrganization { get; set; }
        [Required(ErrorMessage = "Введите ФИО")]
        public string FullNameUser { get; set; }
        [Required(ErrorMessage = "Введите должность")]
        public string PostUser { get; set; }
        [Required(ErrorMessage = "Введите адресс электронной почты")]
        public string Email { get; set; }
       [Key]
        public int BidId { get; set; }
        
        public Bid Bid { get; set; }
    }
}
