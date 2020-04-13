using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dockertraining_compose_anthony_yildirim.Models
{
    /// <summary>
    /// CREATE TABLE Stocks
    /// (
    ///   Id INT unsigned NOT NULL AUTO_INCREMENT,
    ///   Symbol VARCHAR(4) NOT NULL,
    ///   Description VARCHAR(100) NULL,
    ///   PRIMARY KEY(id)
    ///   UNIQUE KEY unique_email(Symbol)
    /// );
    /// </summary>
    public class Stock
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string Symbol { get; set; }

        public string Description { get; set; }
    }
}
