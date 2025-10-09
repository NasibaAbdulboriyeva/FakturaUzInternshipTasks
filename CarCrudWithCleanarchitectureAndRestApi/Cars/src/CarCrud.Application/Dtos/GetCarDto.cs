using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCrud.Application.Dtos
{
    public class GetCarDto
    {
        public long CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarNumber { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }

}
