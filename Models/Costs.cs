using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostsApi.Models
{
    
    public class Costs
    {

       [Key]

        public int idCosts { get; set; }
    }
}
