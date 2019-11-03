using System;
namespace bitacorabackend.Models
{
    public class Bitacory
    {
        public int id {get; set;}
        public DateTime date {get; set;}
        public string Activity {get; set;}
        public int? CategoryId {get; set;}
        public virtual Category Category {get; set;}
        public DateTime InitialDate {get; set;}
        public DateTime FinalDate {get; set;}
    }
}